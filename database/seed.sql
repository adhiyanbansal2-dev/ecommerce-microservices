CREATE DATABASE ProductDb;
GO
USE ProductDb;
GO
CREATE TABLE Products(
    Id INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(200) NOT NULL,
    Category NVARCHAR(100) NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    Stock INT NOT NULL
);
INSERT INTO Products(Name, Category, Price, Stock) VALUES
('Laptop', 'Electronics', 75000, 10),
('Mouse', 'Electronics', 900, 100),
('Keyboard', 'Electronics', 1500, 60),
('Monitor', 'Electronics', 12000, 25);
