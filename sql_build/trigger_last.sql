
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

	Declare @id CHAR(9);
	select @id=Dno 
	from inserted;
	insert into 
	Account(username,Permission) values(@id,2)
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
