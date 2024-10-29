
											/*  PRIMARY KEY */

CREATE TABLE Employees (
  EmployeeID INT NOT NULL,
  FirstName VARCHAR(50),
  LastName VARCHAR(50),
  Department VARCHAR(50),
  PRIMARY KEY (EmployeeID)
);

											/* Foreign Key */

CREATE TABLE Departments (
  DepartmentID INT NOT NULL,
  DepartmentName VARCHAR(50),
  PRIMARY KEY (DepartmentID)
);

ALTER TABLE Employees
ADD FOREIGN KEY (Department) REFERENCES Departments(DepartmentID);


CREATE TABLE EmployeeDetails (
  EmployeeID INT,
  [Address] VARCHAR(100),
  Phone VARCHAR(20),
  PRIMARY KEY (EmployeeID),
  FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);


										/* One-To-One RelationShip */

						--->Example: A table of EmployeeDetails linked to the Employees table, where each employee has only one detailed record. --->

/*CREATE TABLE EmployeeDetails (
  EmployeeID INT,
  Address VARCHAR(100),
  Phone VARCHAR(20),
  PRIMARY KEY (EmployeeID),
  FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);
*/


												/* One-To-Many*/
										
									---> Example: A department can have multiple employees <---

/*CREATE TABLE Employees (
  EmployeeID INT NOT NULL,
  FirstName VARCHAR(50),
  LastName VARCHAR(50),
  DepartmentID INT,
  PRIMARY KEY (EmployeeID),
  FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);
*/
	

											----> Many-to-Many <---
	
	--	Example: If an employee can work on multiple projects and each project can have multiple employees.

CREATE TABLE Projects (
  ProjectID INT,
  ProjectName VARCHAR(50),
  PRIMARY KEY (ProjectID)
);
											
CREATE TABLE EmployeeProjects (
  EmployeeID INT,
  ProjectID INT,
  PRIMARY KEY (EmployeeID, ProjectID),
  FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID),
  FOREIGN KEY (ProjectID) REFERENCES Projects(ProjectID)
);



INSERT INTO Departments (DepartmentID, DepartmentName) VALUES
(1, 'HR'),
(2, 'IT'),
(3, 'Finance');

INSERT INTO Employees (EmployeeID, FirstName, LastName, DepartmentID) VALUES
(101, 'John', 'Doe', 1),
(102, 'Jane', 'Smith', 2),
(103, 'Mike', 'Johnson', 2),
(104, 'Sara', 'Williams', 3);


INSERT INTO EmployeeProjects (EmployeeID, ProjectID) VALUES
(101, 1001),
(102, 1001),
(102, 1002),
(103, 1002);
