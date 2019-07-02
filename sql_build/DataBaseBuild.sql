USE master
GO
CREATE DATABASE Medical_Data_Management_System
ON
(	
	NAME = medical_Data,
	FILENAME = 'D:\DB\Simple-medical-management-system\Medical_Data_Management_System\Medical_Data.mdf',
	SIZE = 40,
	MAXSIZE = 200,
	FILEGROWTH = 5 
)
LOG ON
(	
	NAME ='medicalData_log',
	FILENAME = 'D:\DB\Simple-medical-management-system\Medical_Data_Management_System\Medical_Log.ldf',
	SIZE = 20MB,
	MAXSIZE = 100MB,
	FILEGROWTH = 5MB
) 
GO
