
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
    Rstate Char(1) DEFAULT '0',--等待、进行、结束
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
