CREATE TABLE Departments (
Id int identity(1,1) PRIMARY KEY,
DepartmentName nvarchar(500)
);

insert into Departments values ('.NET')
insert into Departments values ('Frontend')
insert into Departments values ('Mobile')

CREATE TABLE Employees (
Id int identity(1, 1) PRIMARY KEY,
EmployeeName nvarchar(500),
DepartmentId int,
DateOfJoining datetime,
PhotoProfileName nvarchar(500),
FOREIGN KEY (DepartmentId) REFERENCES Departments(Id)
);

INSERT INTO Employees VALUES ('Yan Pershay', 1, '2021.07.21', '1.jpg')
INSERT INTO Employees VALUES ('Andrey', 2, '2021.07.29', '1.jpg')
INSERT INTO Employees VALUES ('Semen', 3, '2021.08.03', '1.jpg')

SELECT * FROM Departments
SELECT * FROM Employees
