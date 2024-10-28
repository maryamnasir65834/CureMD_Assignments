CREATE TABLE Customers
(      
    CustomerID INTEGER PRIMARY KEY IDENTITY(1,1),
    CustomerName VARCHAR(50),
    ContactName VARCHAR(50),
    Address VARCHAR(50),
    City VARCHAR(20),
    PostalCode VARCHAR(10),
    Country VARCHAR(15)
);


INSERT INTO Customers (CustomerName, ContactName, Address, City, PostalCode, Country)
VALUES ('John Doe', 'Jane Smith', '123 Elm St', 'Springfield', '12345', 'USA');


UPDATE Customers
SET City = 'New York'
WHERE CustomerID = 1;



DELETE FROM Customers
WHERE CustomerID = 1;






INSERT INTO Customers (CustomerName, ContactName, Address, City, PostalCode, Country)
VALUES ('Alice Brown', 'Tom Hardy', '456 Oak St', 'Chicago', '60610', 'USA');

INSERT INTO Customers (CustomerName, ContactName, Address, City, PostalCode, Country)
VALUES ('Emily Clark', 'Chris Evans', '789 Pine St', 'Los Angeles', '90001', 'USA');




UPDATE Customers
SET City = 'San Francisco'
WHERE CustomerID = 2;


DELETE FROM Customers
WHERE CustomerID = 3;
