IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'dbMedicalInstitution')
CREATE DATABASE dbMedicalInstitution;
GO
USE dbMedicalInstitution
--dropping tables
IF OBJECT_ID('vwSickLeaveRequirements') IS NOT NULL
DROP VIEW vwSickLeaveRequirements;

IF OBJECT_ID('vwDoctor') IS NOT NULL
DROP VIEW vwDoctor;

IF OBJECT_ID('vwPatient') IS NOT NULL
DROP VIEW vwPatient;

IF OBJECT_ID('vwSickLeaveRequirements') IS NOT NULL
DROP VIEW vwSickLeaveRequirements;

IF OBJECT_ID('tblSickLeaveRequirements') IS NOT NULL 
DROP TABLE tblSickLeaveRequirements;

IF OBJECT_ID('tblPatient') IS NOT NULL 
DROP TABLE tblPatient;

IF OBJECT_ID('tblDoctor') IS NOT NULL 
DROP TABLE tblDoctor;

IF OBJECT_ID('tblUsers') IS NOT NULL 
DROP TABLE tblUsers;

CREATE TABLE tblUsers(
	userId INT PRIMARY KEY IDENTITY(1,1),
	fullname VARCHAR(35) NOT NULL,
	JMBG CHAR(13) NOT NULL,
	username VARCHAR(20) NOT NULL,
	password VARCHAR(20) NOT NULL
);

CREATE TABLE tblDoctor(
	doctorId INT PRIMARY KEY IDENTITY(1,1),
	account VARCHAR(20),
	userId INT FOREIGN KEY REFERENCES tblUsers(userId) ON DELETE SET NULL,
);  

CREATE TABLE tblPatient(
	patientId INT PRIMARY KEY IDENTITY(1,1),
	cardNumber VARCHAR(20),
	userId INT FOREIGN KEY REFERENCES tblUsers(userId) ON DELETE SET NULL,
	doctorId INT FOREIGN KEY REFERENCES tblDoctor(doctorId) ON DELETE SET NULL
);  

CREATE TABLE tblSickLeaveRequirements(
	id INT PRIMARY KEY IDENTITY(1,1),
	date DATE not null,
	description VARCHAR(50),
	firm VARCHAR(25),
	urgent BIT not null,
	patientId INT FOREIGN KEY REFERENCES tblPatient(patientId) ON DELETE SET NULL
);  

GO
CREATE VIEW vwPatient
as
select u.userId, u.username, u.fullname, u.JMBG, p.cardNumber , p.doctorId
from tblPatient p
inner join tblUsers u
on u.userId = p.userId
inner join tblDoctor d
on p.doctorId = d.doctorId

GO
CREATE VIEW vwDoctor
as
select u.userId, u.username, u.fullname, u.JMBG, d.account ,d.doctorId
from tblUsers u
inner join tblDoctor d
on u.userId = d.userId;

GO
CREATE VIEW vwSickLeaveRequirements
as
select r.date, r.description, r.firm, r.id, r.patientId, r.urgent, p.doctorId
from tblSickLeaveRequirements r
inner join tblPatient p
on r.patientId = p.patientId
order by r.urgent, r.date desc
OFFSET 0 ROWS



