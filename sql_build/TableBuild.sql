
CREATE TABLE ACCOUNT
(
    username CHAR(10) PRIMARY KEY,
    password CHAR(10),
    Permission INT,--0人事部 、1挂号程序、2医生界面
)


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
    Dpassword VARCHAR(10),
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

/*CREATE TABLE Drelexdate
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
    Pno CHAR(9)  PRIMARY KEY,
    Pname CHAR(20),
    Psex CHAR(2) CHECK (Psex in('男','女')),
    P_age SMALLINT ,
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
    Rdate DATE,
    Rtime_begin TIME,
    Rtime_end TIME,
    Rstate TINYINT CHECK(Rstate IN(0,1,2)) --等待、进行、结束
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
    Mstate BIT,--是否取药
    PMno SMALLINT,--可去药房（ TO DO: 增加可去多个药房的方案 ）
        FOREIGN KEY (PMno) REFERENCES Pharmacy(PMno)
            ON UPDATE CASCADE,
    PRIMARY KEY (RXno,Mno),
);

