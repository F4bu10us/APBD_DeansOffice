CREATE SCHEMA apbd;

GO

-- tables
-- Table: Student
CREATE TABLE apbd.Student (
    IdStudent int  NOT NULL IDENTITY,
    FirstName nvarchar(100)  NOT NULL,
    LastName nvarchar(100)  NOT NULL,
    Address nvarchar(100)  NOT NULL,
	IndexNumber nvarchar(50) NOT NULL,
    IdStudies int  NOT NULL,
    CONSTRAINT Student_pk PRIMARY KEY  (IdStudent)
);

-- Table: Student_Subject
CREATE TABLE apbd.Student_Subject (
    IdStudentSubject int  NOT NULL IDENTITY,
    IdStudent int  NOT NULL,
    IdSubject int  NOT NULL,
    CreatedAt nvarchar(100)  NOT NULL,
    CONSTRAINT Student_Subject_pk PRIMARY KEY  (IdStudentSubject,IdStudent,IdSubject)
);

-- Table: Studies
CREATE TABLE apbd.Studies (
    IdStudies int  NOT NULL IDENTITY,
    Name nvarchar(100)  NOT NULL,
    CONSTRAINT Studies_pk PRIMARY KEY  (IdStudies)
);

-- Table: Subject
CREATE TABLE apbd.Subject (
    IdSubject int  NOT NULL IDENTITY,
    Name nvarchar(100)  NOT NULL,
    CONSTRAINT Subject_pk PRIMARY KEY  (IdSubject)
);

-- End of file.
SET IDENTITY_INSERT apbd.Student ON;
SET IDENTITY_INSERT apbd.Student OFF;

SET IDENTITY_INSERT apbd.Studies ON; 
SET IDENTITY_INSERT apbd.Studies OFF;  

SET IDENTITY_INSERT apbd.Subject ON; 
SET IDENTITY_INSERT apbd.Subject OFF;

SET IDENTITY_INSERT apbd.Student_Subject ON; 
SET IDENTITY_INSERT apbd.Student_Subject OFF;

INSERT into apbd.Studies(IdStudies, Name)
	VALUES (1, 'Database'),
	(2, 'AI'),
	(3,'CyberSecurity'),
	(4, 'Computer Technology'),
	(5, 'Robotics'),
	(6,'Mobile applications');
GO

DELETE FROM apbd.Studies
WHERE IdStudies <50; 

INSERT into apbd.Student(IdStudent, FirstName, LastName, Address, IndexNumber, IdStudies)
	VALUES (1, 'John', 'Smith', 'Green Street', 's1', 1),
	(2, 'Jane', 'Red', 'Markart', 's1234', 2),
	(3, 'Jessy', 'Pink', 'Riverdail', 's44332', 3),
	(4, 'Will', 'Blue', 'Petersug', 's3422', 4),
	(5, 'Walter', 'White', 'Rosenburg', 's125455', 5),
	(6, 'Julia', 'Peg', 'Josefa', 's324', 6),
	(7, 'Lolly', 'Grey', 'Franks Street', 's2112', 4),
	(8, 'Roman', 'Chavs', 'Rudno', 's5234', 3),
	(9, 'Oleg', 'Decik', 'Zalizn', 's455', 5)
GO

DELETE FROM apbd.Student
WHERE IdStudent <50; 

INSERT into apbd.Subject(IdSubject, Name)
	VALUES (1, 'Math'),
	(2, 'Science'),
	(3,'C++'),
	(4, 'Pure C'),
	(5, 'Java'),
	(6,'Python'),
	(7, 'C#'),
	(8,'Ruby'),
	(9, 'JS'),
	(10, 'HTML\CSS'),
	(11,'Dart'),
	(12, 'Perl'),
	(13,'Statistics'),
	(14, 'Simulations'),
	(15,'Internet Technologies'),
	(16, 'Multimedia'),
	(17, 'Reading'),
	(18,'Writing');
GO

DELETE FROM apbd.Subject
WHERE IdSubject <50; 

DELETE FROM apbd.Student_Subject
WHERE IdSubject <50; 


INSERT into apbd.Student_Subject(IdStudentSubject, IdStudent, IdSubject, CreatedAt)
	VALUES (1, 1, 1,'20-01-2015'),
	(2, 1, 2,'20-03-2015'),
	(3, 2, 3,'20-01-2015'),
	(4, 2, 4,'25-02-2015'),
	(5, 3, 5,'20-05-2016'),
	(6, 3, 6,'22-02-2015'),
	(7, 4, 7,'10-11-2015'),
	(8, 4, 8,'21-02-2014'),
	(9, 5, 9,'22-05-2015'),
	(10, 5, 10,'20-01-2014'),
	(11, 6, 11,'27-02-2015'),
	(12, 6, 12,'20-05-2018'),
	(13, 7, 13,'12-04-2015'),
	(14, 7, 14,'01-01-2015'),
	(15, 8, 15, '23-01-2015'),
	(16, 8, 16,'21-03-2015'),
	(17, 9, 17,'23-01-2015'),
	(18, 9, 18,'20-04-2012');
GO

SELECT * FROM apbd.Student;