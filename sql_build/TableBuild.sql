
CREATE TABLE Dept
(
    Deptno INT PRIMARY KEY,
    Deptname CHAR(40) NOT NULL,
    Dnum INT,
);

CREATE TABLE Doctor
(   
    Dno CHAR(9) PRIMARY KEY,
    Dname CHAR(20) NOT NULL,
    Dsex CHAR(2) CHECK (Dsex in('男','女')),
    Dage SMALLINT,
    Dprot CHAR(16),--职称 
    Deptno INT NOT NULL,
        FOREIGN KEY (Deptno) REFERENCES Dept(Deptno)
            ON UPDATE CASCADE,  
    Drelexdate INT,
);

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

CREATE TABLE Patient
(   
    Pno CHAR(9)  PRIMARY KEY,
    Pname CHAR(20),
    Psex CHAR(2) CHECK (Psex in('男','女')),
    Page SMALLINT ,
    Pbal NUMERIC(8,2)
);

CREATE TABLE Prescription
(   
    RXno CHAR(9) PRIMARY KEY,
    Dno CHAR(9),
        FOREIGN KEY (Dno) REFERENCES Doctor(Dno),
    Pno CHAR(9),
        FOREIGN KEY (Pno) REFERENCES Patient(Pno)
            ON DELETE CASCADE
            ON UPDATE CASCADE,
    RXdate DATE,
    RXtime TIME,
    Paystate BIT,--布尔
    Price INT,
    Intro VARCHAR(200),
);

CREATE TABLE Medicine
(
    Mno CHAR(9) PRIMARY KEY,
    Mtype CHAR(20),
    Mname CHAR(40),
    Mprice NUMERIC(8,2),
    Mdescrip CHAR(50),
    Mnum INT,
);

CREATE TABLE Pharmacy --药房
(
    PMno CHAR(2) PRIMARY KEY,
    Picksite CHAR(20),
);

CREATE TABLE PMM --药房中有的药
(
    PMno CHAR(2),
        FOREIGN KEY (PMno) REFERENCES Pharmacy(PMno)
            ON DELETE CASCADE
            ON UPDATE CASCADE,
    Mno CHAR(9),
        FOREIGN KEY (Mno) REFERENCES Medicine(Mno)
            ON DELETE CASCADE
            ON UPDATE CASCADE,
    Mnum SMALLINT NOT NULL,
);

CREATE TABLE Register --挂号
(
    Dno CHAR(9),
        FOREIGN KEY (Dno) REFERENCES Doctor(Dno),
    Pno CHAR(9),
        FOREIGN KEY (Pno) REFERENCES Patient(Pno)
            ON DELETE CASCADE
            ON UPDATE CASCADE,
    Rno CHAR(6),
    Rtype CHAR(4) CHECK (Rtype IN ('专家','普通')),
    Rtime1 DATE,
    Rtime2_begin TIME,
    Rtime2_end TIME,
    PRIMARY KEY(Dno,Pno),
);

CREATE TABLE RXM --处方中开的药
(
    RXno CHAR(9),
        FOREIGN KEY (RXno) REFERENCES Prescription(RXno)
            ON DELETE CASCADE
            ON UPDATE CASCADE,
    Mno CHAR(9),
        FOREIGN KEY(Mno) REFERENCES Medicine(Mno)
             ON UPDATE CASCADE,
    Mnum SMALLINT,
    PRIMARY KEY (RXno,Mno),
);

--CREATE TABLE Stock--库房 可不用
--(
--  Mno CHAR(9),
--      FOREIGN KEY (Mno) REFERENCES Medicine(Mno), 
 --  PMno CHAR(10),
 --       FOREIGN KEY (PMno) REFERENCES Pharmacy(PMno),
--    Snum INT,
 --   PRIMARY KEY (Mno,PMno),
--);
 
