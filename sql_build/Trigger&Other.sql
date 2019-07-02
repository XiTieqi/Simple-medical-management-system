
CREATE TRIGGER  Dschedule_worknum_alter AFTER UPDATE OF Rtime_end ON Register
REFERECING NEWROW AS NewTuple
UPDATE Dschedule SET Dworknum = Dworknum + 1 
WHERE (Dno=NewTuple.Dno) AND (Dworkdate=NewTuple.Rdate) AND (Dworktime<=NewTuple.Rtime_begin);

