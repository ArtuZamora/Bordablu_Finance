--Database Creation
USE MASTER

CREATE DATABASE Bordablu
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
	Method varchar(25) NOT NULL
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
	ID_P char(5) NOT NULL
	CONSTRAINT PK_Specifications PRIMARY KEY (ID_S),
	CONSTRAINT FK_Spec_Prod FOREIGN KEY (ID_P) REFERENCES Products(ID_P)
)

CREATE TABLE Orders
(
	ID_O_Auto int identity(1,1) NOT NULL,
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
	Description nvarchar(300) NOT NULL
	CONSTRAINT PK_Orders PRIMARY KEY (ID_O_Auto),
	CONSTRAINT FK_Orders_Payment_Method FOREIGN KEY (ID_PM) REFERENCES Payment_Methods(ID_PM)
)

CREATE TABLE Order_Details
(
	ID_OD char(9) NOT NULL, --Code to generate: ODXXXXXXX
	ID_O_Auto int NOT NULL,
	ID_S char(5) NOT NULL,
	Detail varchar(50) NOT NULL,
	CONSTRAINT PK_Orders_Details PRIMARY KEY (ID_OD),
	CONSTRAINT FK_Orders_Details_Orders FOREIGN KEY (ID_O_Auto) REFERENCES Orders(ID_O_Auto),
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
	SELECT @identity = (COUNT(*) - 1) FROM Finance_Details;
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
	SELECT @identity = (COUNT(*) - 1) FROM Payment_Methods;
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
	SELECT @identity = (COUNT(*) - 1) FROM Products;
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
	SELECT @identity = (COUNT(*) - 1) FROM Specifications;
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
	SELECT @identity = (COUNT(*) - 1) FROM Raw_Material;
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
	SELECT @identity = (COUNT(*) - 1) FROM Expenses;
	SET @identity = @identity + 1;
	UPDATE Expenses 
	SET ID_RM = CONCAT('E', REPLICATE('0',7 - LEN(RTRIM(@identity))) + RTRIM(@identity))
	WHERE ID_RM = 'E0000000'
GO
CREATE TRIGGER TG_PK_Order_Details
ON Expenses
FOR INSERT
AS
	DECLARE @identity int
	SET @identity = 0
	SELECT @identity = (COUNT(*) - 1) FROM Order_Details;
	SET @identity = @identity + 1;
	UPDATE Order_Details 
	SET ID_OD = CONCAT('OD', REPLICATE('0',7 - LEN(RTRIM(@identity))) + RTRIM(@identity))
	WHERE ID_OD = 'OD0000000'
GO