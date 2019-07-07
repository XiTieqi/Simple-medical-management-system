
CREATE TABLE Account
(
    username VARCHAR(10) PRIMARY KEY,
    password VARCHAR(32) DEFAULT '666666',
    Permission INT DEFAULT 1,--0人事部 、1挂号程序、2医生界面、3药房界面
)

CREATE TABLE Dept
(
    Deptno CHAR(6) PRIMARY KEY,
    Deptname VARCHAR(40) NOT NULL,
    Dnum INT,
);

CREATE TABLE Doctor
(   
    Dno CHAR(8) PRIMARY KEY,
    Dname VARCHAR(20) NOT NULL,
    Dsex CHAR(2) CHECK (Dsex in('男','女')),
    Dbirth DATE,
    Dprot CHAR(16),--职称 
    Deptno CHAR(6) NOT NULL,
        FOREIGN KEY (Deptno) REFERENCES Dept(Deptno)
            ON UPDATE CASCADE,  
    Pnum INT DEFAULT 0,
);
/*
CREATE TABLE Dschedule
(
    Dno CHAR(9),
        FOREIGN KEY (Dno) REFERENCES Doctor(Dno)
            ON DELETE CASCADE
            ON UPDATE CASCADE,
    Dworkdate DATE,
    Dworktime TIME,
    Dworkstate BIT,--布尔值
    Dworknum INT,
    PRIMARY KEY (Dno,Dworkdate,Dworktime),
);

CREATE TABLE Drelexdate
(
    Dno CHAR(9),
        FOREIGN KEY (Dno) REFERENCES Doctor(Dno)
            ON DELETE CASCADE
            ON UPDATE CASCADE,
    Drelexdate DATE,
    PRIMARY KEY (Dno,Drelexdate),
);
*/
CREATE TABLE Patient
(   
    Pno CHAR(6)  PRIMARY KEY,
    Pname VARCHAR(20),
    Psex CHAR(2) CHECK (Psex in('男','女')),
    Pbirth DATE ,
    Pbal NUMERIC(8,2) default 0
);


CREATE TABLE Prescription
(   
    RXno CHAR(26) PRIMARY KEY,
    Dno CHAR(8),
        FOREIGN KEY (Dno) REFERENCES Doctor(Dno),
    Pno CHAR(6),
        FOREIGN KEY (Pno) REFERENCES Patient(Pno)
            ON DELETE CASCADE
            ON UPDATE CASCADE,
    RXdate DATE,
    RXtime TIME,
    Paystate BIT DEFAULT 0,--布尔
    Price INT,
    Intro VARCHAR(200),
);

CREATE TABLE Medicine
(
    Mno CHAR(9) PRIMARY KEY,
    Mtype VARCHAR(20),
    Mname VARCHAR(40),
    Mprice NUMERIC(8,2),
    Mdescrip VARCHAR(50),
    Mnum INT,
);
/*
CREATE TABLE Pharmacy --药房
(
    PMno SMALLINT PRIMARY KEY,
    Picksite CHAR(20),
);

CREATE TABLE PMM --药房中有的药
(
    PMno SMALLINT,
        FOREIGN KEY (PMno) REFERENCES Pharmacy(PMno)
            ON DELETE CASCADE
            ON UPDATE CASCADE,
    Mno CHAR(9),
        FOREIGN KEY (Mno) REFERENCES Medicine(Mno)
            ON DELETE CASCADE
            ON UPDATE CASCADE,
    Mnum SMALLINT NOT NULL,
);*/


CREATE TABLE Register --挂号
(
    Dno CHAR(8),
        FOREIGN KEY (Dno) REFERENCES Doctor(Dno),
    Pno CHAR(6),
        FOREIGN KEY (Pno) REFERENCES Patient(Pno)
            ON DELETE CASCADE
            ON UPDATE CASCADE,
    Rno CHAR(26),
    --Rtype CHAR(4) CHECK (Rtype IN ('专家','普通')),
    Rdate DATE,
    Rtime_begin TIME,
    Rtime_end TIME,
    Rstate TINYINT CHECK(Rstate IN(0,1,2)) DEFAULT 0,--等待、进行、结束
    PRIMARY KEY(Rno),
);

CREATE TABLE RXM --处方中开的药
(
    RXno CHAR(26),
        FOREIGN KEY (RXno) REFERENCES Prescription(RXno)
            ON DELETE CASCADE
            ON UPDATE CASCADE,
    Mno CHAR(9),
        FOREIGN KEY(Mno) REFERENCES Medicine(Mno)
             ON UPDATE CASCADE,
    Mnum SMALLINT,
    Mstate BIT DEFAULT 0,--是否取药
    PRIMARY KEY (RXno,Mno),
);


--��ҽ��
go
CREATE or alter TRIGGER Doctor_insert 
ON Doctor		
for insert
AS
BEGIN
	declare @Deptno CHAR(6);

	select @Deptno=Deptno
	from inserted

	UPDATE Dept 
	SET Dnum=Dnum+1
	WHERE Dept.Deptno=@Deptno

	Declare @id CHAR(8);
	select @id=Dno 
	from inserted;
	insert into 
	Account(username) values(@id)
END

--����ҽ��
go
CREATE or alter TRIGGER Doctor_delete 
on Doctor 
for delete
as
begin
	declare @Deptno CHAR(6)
	select @Deptno=Deptno
	from deleted

	UPDATE Dept 
	SET Dnum=Dnum-1
	WHERE Dept.Deptno=@Deptno

	Declare @id CHAR(8);
	select @id=Dno 
	from deleted;

	delete from Account
	where Account.username=@id
END





go
CREATE or alter TRIGGER Price_add
on  RXM--������ҩ
	for insert
AS 
BEGIN

	Declare @addition_price NUMERIC(8,2),@RXno CHAR(26);

	select @Rxno=RXno
	from inserted

	select @addition_price=Medicine.Mprice 
	from Medicine,inserted
	where Medicine.Mno=inserted.Mno 

	UPDATE Prescription
	set price=price+ @addition_price
	where Prescription.RXno=@RXno
	
	

end

go 
CREATE or alter TRIGGER Price_decrease
on  RXM--������ҩ
	for delete
AS 
BEGIN

	Declare @decrease_price NUMERIC(8,2), @RXno CHAR(26);

	select @RXno=RXno
	from deleted

	select @decrease_price=Medicine.Mprice 
	from deleted ,Medicine
	where Medicine.Mno=deleted.Mno

	UPDATE Prescription
	set price=price- @decrease_price
	where Prescription.RXno=@RXno

end






go
CREATE or alter Trigger Prescription_init
on Register
	for insert
as
begin 

	declare @Dno CHAR(8),@Pno CHAR(6),@RXno char(26),@RXdate smalldatetime,@RXtime time

	select @Dno=inserted.Dno,@Pno=inserted.Pno ,@RXno=Rno
	from inserted

	select @RXdate=cast(GETDATE()as smalldatetime) ,@RXtime=cast(GETDATE()as time)

	insert 
	into Prescription(RXno,Dno,Pno,RXdate,RXtime, Paystate,Price, Intro)
	values(@RXno,@Dno,@Pno,@RXdate,@RXtime,0,0,NULL)

	UPDATE Doctor
	set Pnum=Pnum+1
	where Doctor.Dno=@Dno

end


go
CREATE or alter Trigger Medicine_storage
on RXM
	after update
as
begin 

	declare @old_Mstate BIT,@new_Mstate BIT,@Mnum SMALLINT;

	select @old_Mstate=Mstate  
	from deleted
	select @new_Mstate=Mstate ,@Mnum=Mnum
	from inserted

	if @old_Mstate=0 and @new_Mstate =1
	begin
	update Medicine
	set Mnum=Mnum-@Mnum
	end 

end

go
CREATE or alter Trigger Medicine_storage
on RXM
	after update
as
begin 

	declare @old_Mstate BIT,@new_Mstate BIT,@Mnum SMALLINT;

	select @old_Mstate=Mstate  
	from deleted
	select @new_Mstate=Mstate ,@Mnum=Mnum
	from inserted

	if @old_Mstate=0 and @new_Mstate =1
	begin
	update Medicine
	set Mnum=Mnum-@Mnum
	end 

end



INSERT INTO Account(username,Permission) VALUES('000',0);
INSERT INTO Account(username,Permission) VALUES('001',1);
INSERT INTO Account(username,Permission) VALUES('002',2);
INSERT INTO Account(username,Permission) VALUES('003',3);


--Ddept
INSERT INTO Dept VALUES('310011','�����ڿ�',0);
INSERT INTO Dept VALUES('310012','�����ڿ�',0);
INSERT INTO Dept VALUES('310021','��ͨ���',0);
INSERT INTO Dept VALUES('310022','�����',0);
INSERT INTO Dept VALUES('310031','����',0);

--Docter
INSERT INTO Doctor VALUES('20150001','���پ�','��','1988-03-15','����ҽʦ','310011',0)
INSERT INTO Doctor VALUES('20090001','��٢','��','1972-08-09','����ҽʦ','310012',0)
INSERT INTO Doctor VALUES('20100001','��˼��','��','1975-10-23','������ҽʦ','310021',0)
INSERT INTO Doctor VALUES('20130001','�����','��','1983-07-08','����ҽʦ','310022',0)
INSERT INTO Doctor VALUES('20120001','��ʱ��','��','1980-01-29','������ҽʦ','310031',0)

--Patient
INSERT INTO Patient VALUES('330101','��Ǯ����','Ů','1990-04-01',0)
INSERT INTO Patient VALUES('330102','����֣��','��','1993-09-20',0)
INSERT INTO Patient VALUES('330103','�������','��','1997-01-26',0)
INSERT INTO Patient VALUES('330104','������','Ů','1995-12-09',0)
INSERT INTO Patient VALUES('330105','��������','��','1994-08-30',0)
INSERT INTO Patient VALUES('330106','����ʩ��','Ů','1999-06-05',0)

--Medicine
INSERT INTO Medicine VALUES('109830301','����ҩ','ͷ�߿��彺��',26.39,'����ĳЩ���о�������ĸ�Ⱦ',200)
INSERT INTO Medicine VALUES('200101151','�Ǵ���ҩ','��������Ƭ��̩ŵ��',13.48,'������ͨ��ð����ķ��ȡ�ͷʹ',300)
INSERT INTO Medicine VALUES('109300101','�Ǵ���ҩ','�忪�����',29.59,'������з���ʱ��������ʢ���¸��Ȳ���',150)
INSERT INTO Medicine VALUES('200641231','�Ǵ���ҩ','ͨ�ϱ���Ƭ',20.58,'���ڷ����̷Ρ����鲻�����µı���',100)
INSERT INTO Medicine VALUES('200632231','�Ǵ���ҩ','���̽ⶾ����',15.69,'���ڷ��ȸ�ð',200)


