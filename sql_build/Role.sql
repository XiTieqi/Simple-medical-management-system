



CREATE LOGIN Medical_Data_Management WITH PASSWORD = '666666',DEFAULT_DATABASE=Medical_Data_Management_System
EXEC SP_ADDLOGIN 'Register','Doctor','Pharmacy','Mnagement'

USE MASTER 
GO
CREATE USER LOGIN Medical_Data_Management FOR LOGIN Management
GO
   EXEC SP_GRANTDBACCESS 'Medical_Data_Management','Management'
   EXEC SP_ADDROLEMEMBER 'db_owner','Management'
