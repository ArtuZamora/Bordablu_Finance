--Database Creation
USE MASTER

CREATE DATABASE Bordablu
GO
USE Bordablu
GO
CREATE TABLE Finance_Details
(
	ID_FD char(5) NOT NULL, --Code to generate: FDXXX
	Entity varchar(30) NOT NULL,
	Balance money NOT NULL
	CONSTRAINT PK_Finance_Details PRIMARY KEY (ID_FD)
)

CREATE TABLE Payment_Methods
(
	ID_PM char(4) NOT NULL, --Code to generate: PMXX
	Method varchar(25) NOT NULL,
	Balance money NOT NULL
	CONSTRAINT PK_Payment_Methods PRIMARY KEY (ID_PM)
)

CREATE TABLE Products
(
	ID_P char(5) NOT NULL, --Code to generate: PXXX
	Name varchar(35) NOT NULL
	CONSTRAINT PK_Products PRIMARY KEY (ID_P)
)

CREATE TABLE Specifications
(
	ID_S char(5) NOT NULL, --Code to generate: SXXX
	Property varchar(40) NOT NULL,
	ID_P char(5) NOT NULL,
	Data_Type varchar(30)
	CONSTRAINT PK_Specifications PRIMARY KEY (ID_S),
	CONSTRAINT FK_Spec_Prod FOREIGN KEY (ID_P) REFERENCES Products(ID_P)
)

CREATE TABLE Orders
(
	ID_O char(8) NOT NULL, --Code to generate: OXXXXXXX
	Order_Date date NOT NULL,
	Delivery_Date date NOT NULL,
	Client varchar(50) NOT NULL,
	Order_Amount money NOT NULL,
	Delivery_Amount money NOT NULL,
	Labor_Amount money NOT NULL,
	Total_Amount money NOT NULL,
	Earned_Amount money NOT NULL,
	ID_PM char(4) NOT NULL,
	Description nvarchar(300) NOT NULL,
	Status char(30) NOT NULL
	CONSTRAINT PK_Orders PRIMARY KEY (ID_O),
	CONSTRAINT FK_Orders_Payment_Method FOREIGN KEY (ID_PM) REFERENCES Payment_Methods(ID_PM)
)

CREATE TABLE Order_Details
(
	ID_OD char(9) NOT NULL, --Code to generate: ODXXXXXXX
	ID_O char(8) NOT NULL,
	ID_S char(5) NOT NULL,
	Detail varchar(50) NOT NULL
	CONSTRAINT PK_Orders_Details PRIMARY KEY (ID_OD),
	CONSTRAINT FK_Orders_Details_Orders FOREIGN KEY (ID_O) REFERENCES Orders(ID_O),
	CONSTRAINT FK_Orders_Details_Specification FOREIGN KEY (ID_S) REFERENCES Specifications(ID_S)
)

CREATE TABLE Raw_Material
(
	ID_RM char(5) NOT NULL, --Code to generate: RMXXX
	Name varchar(30) NOT NULL,
	Stock int NOT NULL,
	Cost money NOT NULL,
	Supplier varchar(50) NOT NULL,
	Description nvarchar(300) NOT NULL
	CONSTRAINT PK_Raw_Material PRIMARY KEY (ID_RM)
)

CREATE TABLE Expenses
(
	ID_E char(8) NOT NULL, --Code to generate: EXXXXXXX
	Purchase_Date date NOT NULL,
	Amount money NOT NULL,
	Quantity int NOT NULL,
	ID_RM char(5) NOT NULL
	CONSTRAINT PK_Expenses PRIMARY KEY (ID_E)
	CONSTRAINT FK_Expenses_Raw_Material FOREIGN KEY (ID_RM) REFERENCES Raw_Material(ID_RM)
)

--Triggers for primary keys
GO
CREATE TRIGGER TG_PK_Finance_Details
ON Finance_Details
FOR INSERT
AS
	DECLARE @identity int
	SET @identity = 0
	SELECT TOP 1 @identity = CONVERT(int, SUBSTRING(ID_FD, 3, LEN(ID_FD))) 
		FROM Finance_Details ORDER BY ID_FD DESC;
	SET @identity = @identity + 1;
	UPDATE Finance_Details 
	SET ID_FD = CONCAT('FD', REPLICATE('0',3 - LEN(RTRIM(@identity))) + RTRIM(@identity))
	WHERE ID_FD = 'FD000'
GO
CREATE TRIGGER TG_PK_Payment_Methods
ON Payment_Methods
FOR INSERT
AS
	DECLARE @identity int
	SET @identity = 0
	SELECT TOP 1 @identity = CONVERT(int, SUBSTRING(ID_PM, 3, LEN(ID_PM))) 
		FROM Payment_Methods ORDER BY ID_PM DESC;
	SET @identity = @identity + 1;
	UPDATE Payment_Methods 
	SET ID_PM = CONCAT('PM', REPLICATE('0',2 - LEN(RTRIM(@identity))) + RTRIM(@identity))
	WHERE ID_PM = 'PM00'
GO
CREATE TRIGGER TG_PK_Products
ON Products
FOR INSERT
AS
	DECLARE @identity int
	SET @identity = 0
	SELECT TOP 1 @identity = CONVERT(int, SUBSTRING(ID_P, 2, LEN(ID_P))) 
		FROM Products ORDER BY ID_P DESC;
	SET @identity = @identity + 1;
	UPDATE Products 
	SET ID_P = CONCAT('P', REPLICATE('0',3 - LEN(RTRIM(@identity))) + RTRIM(@identity))
	WHERE ID_P = 'P000'
GO
CREATE TRIGGER TG_PK_Specifications
ON Specifications
FOR INSERT
AS
	DECLARE @identity int
	SET @identity = 0
	SELECT TOP 1 @identity = CONVERT(int, SUBSTRING(ID_S, 2, LEN(ID_S))) 
		FROM Specifications ORDER BY ID_S DESC;
	SET @identity = @identity + 1;
	UPDATE Specifications 
	SET ID_S = CONCAT('S', REPLICATE('0',3 - LEN(RTRIM(@identity))) + RTRIM(@identity))
	WHERE ID_S = 'S000'
GO
CREATE TRIGGER TG_PK_Raw_Material
ON Raw_Material
FOR INSERT
AS
	DECLARE @identity int
	SET @identity = 0
	SELECT TOP 1 @identity = CONVERT(int, SUBSTRING(ID_RM, 2, LEN(ID_RM))) 
		FROM Raw_Material ORDER BY ID_RM DESC;
	SET @identity = @identity + 1;
	UPDATE Raw_Material 
	SET ID_RM = CONCAT('RM', REPLICATE('0',3 - LEN(RTRIM(@identity))) + RTRIM(@identity))
	WHERE ID_RM = 'RM000'
GO
CREATE TRIGGER TG_PK_Expenses
ON Expenses
FOR INSERT
AS
	DECLARE @identity int
	SET @identity = 0
	SELECT TOP 1 @identity = CONVERT(int, SUBSTRING(ID_E, 2, LEN(ID_E))) 
		FROM Expenses ORDER BY ID_E DESC;
	SET @identity = @identity + 1;
	UPDATE Expenses 
	SET ID_RM = CONCAT('E', REPLICATE('0',7 - LEN(RTRIM(@identity))) + RTRIM(@identity))
	WHERE ID_RM = 'E0000000'
GO
CREATE TRIGGER TG_PK_Order_Details
ON Order_Details
FOR INSERT
AS
	DECLARE @identity int
	SET @identity = 0
	SELECT TOP 1 @identity = CONVERT(int, SUBSTRING(ID_OD, 3, LEN(ID_OD))) 
		FROM Order_Details ORDER BY ID_OD DESC;
	SET @identity = @identity + 1;
	UPDATE Order_Details 
	SET ID_OD = CONCAT('OD', REPLICATE('0',7 - LEN(RTRIM(@identity))) + RTRIM(@identity))
	WHERE ID_OD = 'OD0000000'
GO
CREATE TRIGGER TG_PK_Order
ON Orders
FOR INSERT
AS
	DECLARE @identity int
	SET @identity = 0
	SELECT TOP 1 @identity = CONVERT(int, SUBSTRING(ID_O, 2, LEN(ID_O))) 
		FROM Orders ORDER BY ID_O DESC;
	SET @identity = @identity + 1;
	UPDATE Orders
	SET ID_O = CONCAT('O', REPLICATE('0',7 - LEN(RTRIM(@identity))) + RTRIM(@identity))
	WHERE ID_O = 'O0000000'
GO

--Inserción de datos iniciales
INSERT INTO Payment_Methods VALUES
	('PM00', 'Efectivo', 0.00);
INSERT INTO Payment_Methods VALUES
	('PM00', 'Agrícola', 0.00);
INSERT INTO Payment_Methods VALUES
	('PM00', 'BIM', 0.00);

INSERT INTO Finance_Details VALUES
	('FD000', 'Negocio', 0.00);
INSERT INTO Finance_Details VALUES
	('FD000', 'Margarita', 0.00);
INSERT INTO Finance_Details VALUES
	('FD000', 'Andrea', 0.00);