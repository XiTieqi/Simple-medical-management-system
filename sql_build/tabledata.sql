INSERT INTO Account(username,Permission) VALUES('000',0);
INSERT INTO Account(username,Permission) VALUES('001',1);
INSERT INTO Account(username,Permission) VALUES('002',2);
INSERT INTO Account(username,Permission) VALUES('003',3);


--Ddept
INSERT INTO Dept VALUES('310011','呼吸内科',0);
INSERT INTO Dept VALUES('310012','消化内科',0);
INSERT INTO Dept VALUES('310021','普通外科',0);
INSERT INTO Dept VALUES('310022','骨外科',0);
INSERT INTO Dept VALUES('310031','儿科',0);

--Docter
INSERT INTO Doctor VALUES('20150001','张仲景','男','1988-03-15','主治医师','310011',0)
INSERT INTO Doctor VALUES('20090001','华佗','男','1972-08-09','主任医师','310012',0)
INSERT INTO Doctor VALUES('20100001','孙思邈','男','1975-10-23','副主任医师','310021',0)
INSERT INTO Doctor VALUES('20130001','王叔和','男','1983-07-08','主治医师','310022',0)
INSERT INTO Doctor VALUES('20120001','李时珍','男','1980-01-29','副主任医师','310031',0)

--Patient
INSERT INTO Patient VALUES('330101','赵钱孙李','女','1990-04-01',0)
INSERT INTO Patient VALUES('330102','周吴郑王','男','1993-09-20',0)
INSERT INTO Patient VALUES('330103','冯陈褚卫','男','1997-01-26',0)
INSERT INTO Patient VALUES('330104','蒋沈韩杨','女','1995-12-09',0)
INSERT INTO Patient VALUES('330105','朱秦尤许','男','1994-08-30',0)
INSERT INTO Patient VALUES('330106','何吕施张','女','1999-06-05',0)

--Medicine
INSERT INTO Medicine VALUES('109830301','处方药','头孢克洛胶囊',26.39,'用于某些敏感菌株引起的感染',200)
INSERT INTO Medicine VALUES('200101151','非处方药','酚麻美敏片（泰诺）',13.48,'用于普通感冒引起的发热、头痛',300)
INSERT INTO Medicine VALUES('109300101','非处方药','清开灵颗粒',29.59,'用于外感风热时毒、火毒内盛所致高热不退',150)
INSERT INTO Medicine VALUES('200641231','非处方药','通窍鼻炎片',20.58,'用于风热蕴肺、表虚不固所致的鼻塞',100)
INSERT INTO Medicine VALUES('200632231','非处方药','银翘解毒胶囊',15.69,'用于风热感冒',200)

