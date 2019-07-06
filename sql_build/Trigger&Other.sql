
CREATE TRIGGER  Dschedule_worknum_alter AFTER UPDATE OF Rtime_end ON Register
REFERECING NEWROW AS NewTuple
UPDATE Dschedule SET Dworknum = Dworknum + 1 
WHERE (Dno=NewTuple.Dno) AND (Dworkdate=NewTuple.Rdate) AND (Dworktime<=NewTuple.Rtime_begin);


--加医生
go
CREATE TRIGGER Doctor_insert 
ON Doctor		
for insert
AS
BEGIN
	UPDATE Dept 
	SET Dnum=Dnum+1
WHERE Dept.Deptno=Deptno
END

--开除医生
go
CREATE TRIGGER Doctor_delete 
on Doctor 
for delete
as
begin
UPDATE Dept 
SET Dnum=Dnum-1
WHERE Dept.Deptno=Deptno
END


go
CREATE TRIGGER Doctor_account 
ON Doctor		
for insert
AS
BEGIN
	insert Dno
	into Account
END
