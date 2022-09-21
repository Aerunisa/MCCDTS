CREATE DATABASE MCCDTS;

CREATE TABLE REGIST(
	 IDRegist INT NOT NULL IDENTITY (1,1), -- track record aja biar kalo diapus ketawan
	 EmailPegawai VARCHAR (100) NOT NULL,
	 CONSTRAINT PK_REGIST PRIMARY KEY (EmailPegawai),
	 Passwords VARCHAR (100) NOT NULL, 
	 DateJoin DATETIME NOT NULL,
);
CREATE TABLE LOGINHISTORY (
	IDHistory INT NOT NULL IDENTITY (1,1), -- track record aja biar kalo diapus ketawan
	EmailPegawai VARCHAR (100) NOT NULL,
	CONSTRAINT FK_LOGINHISTORY_EmailPegawai FOREIGN KEY (EmailPegawai)
		REFERENCES REGIST(EmailPegawai),
	Passwords  VARCHAR (100) NOT NULL,
	DateLogin DATETIME NOT NULL
);
CREATE TABLE Location (
	IDLoc INT NOT NULL IDENTITY (1,1), -- track record  +untuk department
	CONSTRAINT PK_Location Primary key (IDLoc),
	LocAdress VARCHAR (100) NOT NULL,
	LocPostCode Varchar (5) NOT NULL, --karena dibaca doang, buat limitasi data error
	LocCity  VARCHAR (100) NOT NULL
);
CREATE TABLE Position(
	IDPosition INT NOT NULL IDENTITY (1,1), -- Nyambung Pegawai, salary, history
	CONSTRAINT PK_Position PRIMARY KEY (IDPosition),
	Position VARCHAR (50) NOT NULL,
	Duty TEXT NOT NULL,
	Auth VARCHAR (100) NOT NULL
);
CREATE TABLE Salary(
	IDSalary INT NOT NULL IDENTITY (1,1), -- Nyambung Pegawai,
	CONSTRAINT PK_IDSalary PRIMARY KEY (IDSalary),
	Amount INT NOT NULL,
	IDPosition INT NOT NUll,
	CONSTRAINT FK_Salary_IDPosition FOREIGN KEY (IDPosition)
		REFERENCES Position(IDPosition),
);
CREATE TABLE Keterangan (
	IDKet INT NOT NULL IDENTITY (1,1),-- Nyambung history
	CONSTRAINT PK_IDKet PRIMARY KEY (IDKet),
	Penjelasan VARCHAR (100) NOT NULL,
	Keterangan VARCHAR (100) NOT NULL,
);
CREATE TABLE Department(
	IDDept INT NOT NUll IDENTITY (1,1), -- Nyambung Pegawai, history
	CONSTRAINT PK_Department Primary key (IDDept),
	DeptName VARCHAR (50) NOT NULL,
	IDLoc INT NOT NULL,
	CONSTRAINT FK_Department_IDLoc FOREIGN KEY (IDLoc)
		REFERENCES Location(IDLoc),
	Manager INT NOT NULL,
);
CREATE TABLE CutiPegawai (
	IDCuti INT NOT NULL IDENTITY (1,1), -- track record aja biar kalo diapus ketawan
	IDPegawai INT NOT NULL,
	IDDept int NOT NULL,
	CONSTRAINT FK_CutiPegawai_IDDept FOREIGN KEY (IDDept)
		REFERENCES Department(IDDept),
	IDPosition INT NOT NUll,
	CONSTRAINT FK_CutiPegawai_IDPosition FOREIGN KEY (IDPosition)
		REFERENCES Position(IDPosition),
	AwalCuti Date NOT NULL,
	AkhirCuti Date NOT NULL,
	IDKet INT NOT NULL,
	CONSTRAINT FK_CutiPegawai_IDKet FOREIGN KEY (IDKet)
		REFERENCES Keterangan(IDKet)
);
CREATE TABLE AttendanceHis (
	IDHistory INT NOT NULL IDENTITY (1,1), -- track record aja biar kalo diapus ketawan
	CONSTRAINT PK_AttendanceHis Primary key (IDHistory),
	IDPegawai INT NOT NULL,
	IDDept int NOT NULL,
	CONSTRAINT FK_AttendanceHis_IDDept FOREIGN KEY (IDDept)
		REFERENCES Department(IDDept),
	IDPosition INT NOT NUll,
	CONSTRAINT FK_AttendanceHis_IDPosition FOREIGN KEY (IDPosition)
		REFERENCES Position(IDPosition),
	Tanggal Date NOT NULL,
	WaktuDatang Time NOT NULL,
	WaktuPulang Time NOT NULL,
	IDKet INT NOT NULL,
	CONSTRAINT FK_AttendanceHis_IDKet FOREIGN KEY (IDKet)
		REFERENCES Keterangan(IDKet)
);
CREATE TABLE Pegawai(
	IDPegawai INT NOT NULL IDENTITY (1,1),
	CONSTRAINT PK_Pegawai PRIMARY KEY (IDPegawai),
	PegawaiName VARCHAR (100) NOT NULL,
	IDDept int NOT NULL,
	CONSTRAINT FK_Pegawai_IDDept FOREIGN KEY (IDDept)
		REFERENCES Department(IDDept),
	IDPosition INT NOT NUll,
	CONSTRAINT FK_Pegawai_IDPosition FOREIGN KEY (IDPosition)
		REFERENCES Position(IDPosition),
	Phone VARCHAR (15) NOT NULL, --karena dibaca doang, buat limitasi data error
	Addres VARCHAR (200) NOT NULL,
	EmailPegawai VARCHAR (100) NOT NULL,
	CONSTRAINT FK_Pegawai_EmailPegawai FOREIGN KEY (EmailPegawai)
		REFERENCES REGIST(EmailPegawai),
	IDSalary INT NOT NULL
);

ALTER TABLE AttendanceHis
ADD CONSTRAINT FK_AttendanceHis_IDPegawai FOREIGN KEY (IDPegawai)
	REFERENCES Pegawai (IDPegawai);
ALTER TABLE CutiPegawai
ADD CONSTRAINT FK_CutiPegawai_IDPegawai FOREIGN KEY (IDPegawai)
	REFERENCES Pegawai(IDPegawai);
ALTER TABLE Pegawai
ADD CONSTRAINT FK_Pegawai_IDSalary FOREIGN KEY (IDSalary)
	REFERENCES Salary (IDSalary);


INSERT INTO REGIST 
	(EmailPegawai,Passwords,DateJoin)
VALUES
	('Admin@mail.com','Admin','20010912 11:00:00 AM'),
	('Pegawai0@mail.com', 'Randompass','20020101 10:30:09 AM'),
	('Pegawai1@mail.com', 'Randompass','20120202 10:30:09 AM'),
	('Pegawai2@mail.com', 'Randompass','20120303 10:32:09 AM'),
	('Pegawai3@mail.com', 'Randompass','20220404 10:32:09 AM'),
	('Pegawai4@mail.com', 'Randompass','20221212 10:32:09 AM'),
	('Pegawai5@mail.com', 'Randompass','20221212 10:33:09 AM'),
	('Pegawai6@mail.com', 'Randompass','20221212 10:33:09 AM'),
	('Pegawai7@mail.com', 'Randompass','20221212 10:33:09 AM'),
	('Pegawai8@mail.com', 'Randompass','20221212 10:34:09 AM'),
	('Pegawai9@mail.com', 'Randompass','20221212 10:34:09 AM'),
	('Pegawai10@mail.com', 'Randompass','20221212 10:34:09 AM'),
	('Pegawai11@mail.com', 'Randompass','20020101 10:35:09 AM'),
	('Pegawai12@mail.com', 'Randompass','20120202 10:35:09 AM'),
	('Pegawai13@mail.com', 'Randompass','20120303 10:36:09 AM'),
	('Pegawai14@mail.com', 'Randompass','20220404 10:36:09 AM'),
	('Pegawai15@mail.com', 'Randompass','20221212 10:37:09 AM');

INSERT INTO Location
	(LocAdress,LocPostCode,LocCity)
VALUES
	('Jalan bersama mu namun hanya mimpi', 13860,'Jakarta Keras'),
	('Jalan panjang dan menanjak', 12260,'Bandung Dingin'),
	('Jalan membuat hati iri dengki', 13260,'Surabaya Panas'),
	('Jalan yang membuat kakak terpaksa menjalani', 18260,'Papua Surga');

INSERT INTO Position
	(Position,Duty,Auth)
VALUES
	('CEO', 'Membuat keputusan','All Access'),
	('Vice President', 'Pengawas pelaksana, Melaporkan hasil, Kebijakan sementara','All Access'),
	('PMO Directory', 'Membuat keputusan from department ','Marketing, Bussines development, Human resource'),
	('Executive Chief', 'Pemegang Project','Project'),
	('Project Manager', 'Menjalankan project','Project'),
	('Developer senior level', 'Mendevelop project','project'),
	('Developer junior level', 'Mendevelop project','project'),
	('Finance Manager', 'Melaporkan laporan seluruh keuangan','Finance'),
	('Accountant senior level', 'Membuat laporan keuangan','Finance'),
	('Accountant junior level', 'Membuat laporan keuangan','Finance'),
	('Audithor', 'Membuat laporan keuangan','Finance, Maketing, BD'),
	('Intern developer', 'training','project'),
	('Intern Finance', 'training','finance'),
	('TU', 'Mengorganisir lingkungan kerja','No Acces')
	;

INSERT INTO Salary
	(Amount,IDPosition)
VALUES
	(50000000, 1),
	(35000000, 2),
	(25000000, 3),
	(25000000, 4),
	(15000000, 5),
	(10000000, 6),
	(7000000, 7),
	(15000000, 8),
	(10000000, 9),
	(7000000, 10),
	(12000000, 11),
	(5000000, 12),
	(4000000, 13),
	(4500000, 14);

INSERT INTO Keterangan
	(Penjelasan,Keterangan)
VALUES
	('Datang dan Pulang tepat waktu', 'Hadir'),
	('Datang telambat dan Pulang tepat waktu ', 'Terlambat'),
	('Datang Namun Pulang lebih awal', 'Half Day'),
	('Sakit ringan', 'Home Sick'),
	('Dirawat dirumah sakit', 'Bedrest'),
	('Keperluan', 'Izin'),
	('Izin durasi 7-20 hari', 'Cuti'),
	('Kerja Dari Rumah', 'WFH'),
	('Libur 1 bulan setelah melahirkan', 'Cuti Melahirkan'),
	('ABSENT','ABSENT');


INSERT INTO Department
	(DeptName,IDLoc,Manager)
VALUES
	('FINNACE', 1,1),
	('DEVELOPER', 1,1),
	('MARKETING', 1,1),
	('BUSINESS', 1,1),
	('ACADEMY',1,1),
	('FINNACE', 2,2),
	('DEVELOPER', 2,2),
	('MARKETING', 2,2),
	('BUSINESS', 2,2),
	('ACADEMY',2,2),
	('FINNACE', 3,3),
	('DEVELOPER', 3,3),
	('MARKETING', 3,3),
	('BUSINESS', 3,3),
	('ACADEMY',3,3),
	('FINNACE',4,4),
	('DEVELOPER', 4,4),
	('MARKETING', 4,4),
	('BUSINESS', 4,4),
	('ACADEMY',4,4)
	;

INSERT INTO Pegawai
	(PegawaiName,IDDept,IDPosition,Phone,Addres,EmailPegawai,IDSalary)
VALUES
	('Andrew', 1,4, '+6285887173252', 'JALAN SALAMUN JAKARTA','Pegawai0@mail.com',4),
	('Barnie', 7,4, '+6285887173252', 'JALANIN AJA DULU','Pegawai1@mail.com',4),
	('Chaeri', 13,4, '+6285887173252', 'JALAN SAMA KAMU MAUNYA','Pegawai2@mail.com',4),
	('Dzaqi', 17,4, '+6285887173252', 'GANG DIMANA KITA BERTEMU','Pegawai3@mail.com',4),

	('Aerunisa', 1,5, '+6285887173252', 'JALAN SALAMUN JAKARTA','Pegawai4@mail.com',5),
	('Barren', 2,6, '+6285887173252', 'JALANIN AJA DULU','Pegawai5@mail.com',6),
	('Clarisa', 12,6, '+6285887173252', 'JALAN SAMA KAMU MAUNYA','Pegawai6@mail.com',6),
	('Dwiangga', 17,7, '+6285887173252', 'GANG DIMANA KITA BERTEMU','Pegawai7@mail.com',7),
	('Erlangga', 7,7, '+6285887173252', 'JALANIN AJA DULU','Pegawai8@mail.com',7),
	('Ficco', 12,7, '+6285887173252', 'JALANIN AJA DULU','Pegawai9@mail.com',7),
	('Gerrad', 7,6, '+6285887173252', 'JALANIN AJA DULU','Pegawai10@mail.com',6)
	;



INSERT INTO AttendanceHis
	(IDPegawai,IDDept,IDPosition,Tanggal,WaktuDatang,WaktuPulang,IDKet)
VALUES
	(1,1,4,'20220911', '09:34:09 AM','10:34:09 PM', 1),
	(2,7,4,'20220911', '09:34:09 AM','10:34:09 PM', 1),
	(3,13,4,'20220911', '09:34:09 AM','10:34:09 PM', 1),
	(4,17,4,'20220911', '09:34:09 AM','10:34:09 PM', 1),
	(6,2,6,'20220911', '09:34:09 AM','10:34:09 PM', 1),
	(8,17,7,'20220911', '09:34:09 AM','10:34:09 PM', 1),
	(9,7,7,'20220911', '09:34:09 AM','10:34:09 PM', 1),
	(10,12,7,'20220911', '09:34:09 AM','10:34:09 PM', 1),
	(11,7,6,'20220911', '09:34:09 AM','10:34:09 PM', 1),
	(1,1,4,'20220912', '09:34:09 AM','10:34:09 PM', 1),
	(5,1,5,'20220912', '09:34:09 AM','10:34:09 PM', 1),
	(2,7,4,'20220912', '09:34:09 AM','10:34:09 PM', 1),
	(3,13,4,'20220912', '09:34:09 AM','10:34:09 PM', 1),
	(6,2,6,'20220912', '09:34:09 AM','10:34:09 PM', 1),
	(7,12,6,'20220912', '09:34:09 AM','10:34:09 PM', 1),
	(9,7,7,'20220912', '09:34:09 AM','10:34:09 PM', 1),
	(10,12,7,'20220912', '09:34:09 AM','10:34:09 PM', 1),
	(11,7,6,'20220912', '09:34:09 AM','10:34:09 PM', 1)
	;
Select * from CutiPegawai;
INSERT INTO CutiPegawai
	(IDPegawai,IDDept,IDPosition,AwalCuti,AkhirCuti,IDKet)
VALUES
	(4,17,4,'20220912', '20220915', 4),
	(8,17,7,'20220912', '20220920', 7),
	(5,1,5,'20220911', '20220919', 5),
	(7,12,6,'20220911', '20220917', 4);

-- Dijalnkan setelah data nya masuk
ALTER TABLE Department
ADD CONSTRAINT FK_Department_Manager FOREIGN KEY (Manager)
	REFERENCES Pegawai(IDPegawai);

-- melihat jumlah gaji dari tiap posisi
SELECT 
	Salary.Amount,
	Position.Position
FROM
	Position JOIN Salary
On
	Position.IDPosition = Salary.IDPosition
;

-- SELECT MELIHAT DARI URUTAN
SELECT PegawaiName, IDDept FROM Pegawai ORDER BY IDDept ASC;
SELECT PegawaiName, IDDept FROM Pegawai ORDER BY PegawaiName ASC;
SELECT PegawaiName, IDDept FROM Pegawai ORDER BY IDDept DESC;
SELECT PegawaiName, IDDept FROM Pegawai ORDER BY PegawaiName DESC;

-- melihat  posisi + Gaji 
SELECT 
	Salary.Amount,
	Pegawai.PegawaiName,
	Position.Position,
	Department.DeptName
FROM
	Pegawai JOIN Salary 
On
	Pegawai.IDSalary = Salary.IDSalary JOIN Position
on
	Pegawai.IDPosition = Position.IDPosition JOIN Department
on
	Pegawai.IDDept = Department.IDDept
;

-- Menampilkan Nama pegawai posisi dan keterangan tidak hadir/Cuti
Select 
	CutiPegawai.IDPegawai,
	Pegawai.PegawaiName,
	Position.Position,
	Keterangan.Keterangan
FROM
	CutiPegawai JOIN Pegawai
ON
	Pegawai.IDPegawai = CutiPegawai.IDPegawai JOIN Position
ON 
	Position.IDPosition = Pegawai.IDPosition JOIN Keterangan
ON 
	Keterangan.IDKet = CutiPegawai.IDKet 
	;

--
SELECT 
	Salary.Amount,
	Pegawai.PegawaiName,
	Position.Position,
	Department.DeptName, 
	REGIST.EmailPegawai,
	Pegawai.Phone 
FROM
	Pegawai JOIN Salary 
On
	Pegawai.IDSalary = Salary.IDSalary JOIN Position
on
	Pegawai.IDPosition = Position.IDPosition JOIN Department
on
	Pegawai.IDDept = Department.IDDept JOIN REGIST
on
	REGIST.EmailPegawai= Pegawai.EmailPegawai
;

-- URUTAN NGEDROP
 ALTER TABLE Department DROP CONSTRAINT FK_Department_DeptManager;
 ALTER TABLE AttendanceHis DROP CONSTRAINT FK_AttendanceHis_IDPegawai;
 ALTER TABLE AttendanceHis DROP CONSTRAINT FK_AttendanceHis_PositionID ;
 ALTER TABLE AttendanceHis DROP CONSTRAINT FK_AttendanceHis_DeptID;
 ALTER TABLE CutiPegawai DROP CONSTRAINT FK_CutiPegawai_DeptID;
 ALTER TABLE CutiPegawai DROP CONSTRAINT FK_CutiPegawai_PositionID;
 ALTER TABLE Salary DROP CONSTRAINT FK_Salary_PositionID;
 ALTER TABLE LOGINHISTORY DROP CONSTRAINT FK_LOGINHISTORY_EmailPegawai;
 ALTER TABLE CutiPegawai DROP CONSTRAINT FK_CutiPegawai_JenisCuti;
 DROP TABLE Pegawai;
 DROP TABLE Salary;
 DROP TABLE Position;
 DROP TABLE Department;
 DROP TABLE AttendanceHis;
 DROP TABLE Keterangan;
 DROP TABLE Location;
 DROP TABLE LOGINHISTORY;
 DROP TABLE REGIST;
 DROP TABLE CutiPegawai;

 SELECT * FROM REGIST;
SELECT * FROM Pegawai;
SELECT * FROM Salary;
SELECT * FROM Position;
SELECT * FROM Department;
SELECT * FROM AttendanceHis;
SELECT * FROM Keterangan;
SELECT * FROM CutiPegawai;
SELECT * FROM Location;
SELECT * FROM LOGINHISTORY;