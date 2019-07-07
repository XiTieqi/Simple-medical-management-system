
--加医生
go
CREATE or alter TRIGGER Doctor_insert 
ON Doctor		
for insert
AS
BEGIN
	declare @Deptno CHAR(3);

	select @Deptno=Deptno
	from inserted

	UPDATE Dept 
	SET Dnum=Dnum+1
	WHERE Dept.Deptno=@Deptno

END

--开除医生
go
CREATE or alter TRIGGER Doctor_delete 
on Doctor 
for delete
as
begin
	declare @Deptno CHAR(3)
	select @Deptno=Deptno
	from deleted

	UPDATE Dept 
	SET Dnum=Dnum-1
	WHERE Dept.Deptno=@Deptno
END



go
CREATE or alter TRIGGER Doctor_account 
ON Doctor		
	for insert
AS
BEGIN
	Declare @id CHAR(9);

	select @id=Dno 
	from inserted;

	insert into 
	Account(username) values(@id)

END

go 
CREATE or alter TRIGGER Price_add
on  RXM--处方开药
	for insert
AS 
BEGIN

	Declare @addition_price NUMERIC(8,2),@RXno CHAR(9);

	select @Rxno=RXno
	from deleted

	select @addition_price=Medicine.Mprice 
	from Medicine,inserted
	where Medicine.Mno=inserted.Mno 

	UPDATE Prescription
	set price=price+ @addition_price
	where Prescription.RXno=@RXno
	
	

end

go 
CREATE or alter TRIGGER Price_decrease
on  RXM--处方开药
	for delete
AS 
BEGIN

	Declare @decrease_price NUMERIC(8,2), @RXno CHAR(9);

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

	declare @Dno CHAR(9),@Pno CHAR(9)

	select @Dno=inserted.Dno,@Pno=inserted.Pno
	from inserted

	insert 
	into Prescription(RXno,Dno,Pno,RXdate,RXtime, Paystate,Price, Intro)
	values(000,@Dno,@Pno,0,0,0,0,NULL)

	UPDATE Doctor
	set Pnum=Pnum+1
	where Doctor.Dno=@Dno

end



