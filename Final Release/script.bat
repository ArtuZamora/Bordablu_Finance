@ECHO OFF
echo USE MASTER> C:\script.sql
echo IF EXISTS(select * from sys.databases where name='Bordablu')>> C:\script.sql
echo DROP DATABASE Bordablu>> C:\script.sql
echo CREATE DATABASE Bordablu>> C:\script.sql
echo GO>> C:\script.sql
echo USE Bordablu>> C:\script.sql
echo GO>> C:\script.sql
echo CREATE TABLE Finance_Details>> C:\script.sql
echo (>> C:\script.sql
echo 	ID_FD char(5) NOT NULL, --Code to generate: FDXXX>> C:\script.sql
echo 	Entity varchar(30) NOT NULL,>> C:\script.sql
echo 	Balance money NOT NULL>> C:\script.sql
echo 	CONSTRAINT PK_Finance_Details PRIMARY KEY (ID_FD)>> C:\script.sql
echo )>> C:\script.sql
echo CREATE TABLE Payment_Methods>> C:\script.sql
echo (>> C:\script.sql
echo 	ID_PM char(4) NOT NULL, --Code to generate: PMXX>> C:\script.sql
echo 	Method varchar(25) NOT NULL,>> C:\script.sql
echo 	Balance money NOT NULL>> C:\script.sql
echo 	CONSTRAINT PK_Payment_Methods PRIMARY KEY (ID_PM)>> C:\script.sql
echo )>> C:\script.sql
echo CREATE TABLE Products>> C:\script.sql
echo (>> C:\script.sql
echo 	ID_P char(5) NOT NULL, --Code to generate: PXXX>> C:\script.sql
echo 	Name varchar(35) NOT NULL>> C:\script.sql
echo 	CONSTRAINT PK_Products PRIMARY KEY (ID_P)>> C:\script.sql
echo )>> C:\script.sql
echo CREATE TABLE Specifications>> C:\script.sql
echo (>> C:\script.sql
echo 	ID_S char(5) NOT NULL, --Code to generate: SXXX>> C:\script.sql
echo 	Property nvarchar(MAX) NOT NULL,>> C:\script.sql
echo 	ID_P char(5) NOT NULL,>> C:\script.sql
echo 	Data_Type varchar(30)>> C:\script.sql
echo 	CONSTRAINT PK_Specifications PRIMARY KEY (ID_S),>> C:\script.sql
echo 	CONSTRAINT FK_Spec_Prod FOREIGN KEY (ID_P) REFERENCES Products(ID_P)>> C:\script.sql
echo )>> C:\script.sql
echo CREATE TABLE Orders>> C:\script.sql
echo (>> C:\script.sql
echo 	ID_O char(8) NOT NULL, --Code to generate: OXXXXXXX>> C:\script.sql
echo 	Order_Date date NOT NULL,>> C:\script.sql
echo 	Delivery_Date date NOT NULL,>> C:\script.sql
echo 	Client varchar(50) NOT NULL,>> C:\script.sql
echo 	Order_Amount money NOT NULL,>> C:\script.sql
echo 	Delivery_Amount money NOT NULL,>> C:\script.sql
echo 	Labor_Amount money NOT NULL,>> C:\script.sql
echo 	Total_Amount money NOT NULL,>> C:\script.sql
echo 	Earned_Amount money NOT NULL,>> C:\script.sql
echo 	ID_PM char(4) NOT NULL,>> C:\script.sql
echo 	Description nvarchar(MAX),>> C:\script.sql
echo 	Status char(30) NOT NULL DEFAULT 'En Proceso',>> C:\script.sql
echo 	Help bit NOT NULL DEFAULT 0,>> C:\script.sql
echo 	Given_Amount money NOT NULL>> C:\script.sql
echo 	CONSTRAINT PK_Orders PRIMARY KEY (ID_O),>> C:\script.sql
echo 	CONSTRAINT FK_Orders_Payment_Method FOREIGN KEY (ID_PM) REFERENCES Payment_Methods(ID_PM)>> C:\script.sql
echo )>> C:\script.sql
echo CREATE TABLE Order_Details>> C:\script.sql
echo (>> C:\script.sql
echo 	ID_OD char(9) NOT NULL, --Code to generate: ODXXXXXXX>> C:\script.sql
echo 	ID_O char(8) NOT NULL,>> C:\script.sql
echo 	ID_S char(5) NOT NULL,>> C:\script.sql
echo 	ID_P char(5) NOT NULL,>> C:\script.sql
echo 	Detail nvarchar(MAX) NOT NULL,>> C:\script.sql
echo 	P_Num int NOT NULL>> C:\script.sql
echo 	CONSTRAINT PK_Orders_Details PRIMARY KEY (ID_OD),>> C:\script.sql
echo 	CONSTRAINT FK_Orders_Details_Orders FOREIGN KEY (ID_O) REFERENCES Orders(ID_O) ON DELETE CASCADE,>> C:\script.sql
echo 	CONSTRAINT FK_Orders_Details_Specification FOREIGN KEY (ID_S) REFERENCES Specifications(ID_S),>> C:\script.sql
echo 	CONSTRAINT FK_Orders_Details_Products FOREIGN KEY (ID_P) REFERENCES Products(ID_P)>> C:\script.sql
echo )>> C:\script.sql
echo CREATE TABLE Raw_Material>> C:\script.sql
echo (>> C:\script.sql
echo 	ID_RM char(5) NOT NULL, --Code to generate: RMXXX>> C:\script.sql
echo 	Name varchar(300) NOT NULL,>> C:\script.sql
echo 	Stock int NOT NULL,>> C:\script.sql
echo 	Cost money NOT NULL,>> C:\script.sql
echo 	Supplier varchar(300) NOT NULL,>> C:\script.sql
echo 	Description nvarchar(MAX)>> C:\script.sql
echo 	CONSTRAINT PK_Raw_Material PRIMARY KEY (ID_RM)>> C:\script.sql
echo )>> C:\script.sql
echo CREATE TABLE Expenses>> C:\script.sql
echo (>> C:\script.sql
echo 	ID_E char(8) NOT NULL, --Code to generate: EXXXXXXX>> C:\script.sql
echo 	Purchase_Date date NOT NULL,>> C:\script.sql
echo 	Amount money NOT NULL,>> C:\script.sql
echo 	Quantity int NOT NULL,>> C:\script.sql
echo 	ID_RM char(5) NOT NULL>> C:\script.sql
echo 	CONSTRAINT PK_Expenses PRIMARY KEY (ID_E)>> C:\script.sql
echo 	CONSTRAINT FK_Expenses_Raw_Material FOREIGN KEY (ID_RM) REFERENCES Raw_Material(ID_RM)>> C:\script.sql
echo )>> C:\script.sql
echo GO>> C:\script.sql
echo CREATE TRIGGER TG_PK_Finance_Details>> C:\script.sql
echo ON Finance_Details>> C:\script.sql
echo FOR INSERT>> C:\script.sql
echo AS>> C:\script.sql
echo 	DECLARE @identity int>> C:\script.sql
echo 	SET @identity = 0>> C:\script.sql
echo 	SELECT TOP 1 @identity = CONVERT(int, SUBSTRING(ID_FD, 3, LEN(ID_FD))) >> C:\script.sql
echo 		FROM Finance_Details ORDER BY ID_FD DESC;>> C:\script.sql
echo 	SET @identity = @identity + 1;>> C:\script.sql
echo 	UPDATE Finance_Details >> C:\script.sql
echo 	SET ID_FD = CONCAT('FD', REPLICATE('0',3 - LEN(RTRIM(@identity))) + RTRIM(@identity))>> C:\script.sql
echo 	WHERE ID_FD = 'FD000'>> C:\script.sql
echo GO>> C:\script.sql
echo CREATE TRIGGER TG_PK_Payment_Methods>> C:\script.sql
echo ON Payment_Methods>> C:\script.sql
echo FOR INSERT>> C:\script.sql
echo AS>> C:\script.sql
echo 	DECLARE @identity int>> C:\script.sql
echo 	SET @identity = 0>> C:\script.sql
echo 	SELECT TOP 1 @identity = CONVERT(int, SUBSTRING(ID_PM, 3, LEN(ID_PM))) >> C:\script.sql
echo 		FROM Payment_Methods ORDER BY ID_PM DESC;>> C:\script.sql
echo 	SET @identity = @identity + 1;>> C:\script.sql
echo 	UPDATE Payment_Methods >> C:\script.sql
echo 	SET ID_PM = CONCAT('PM', REPLICATE('0',2 - LEN(RTRIM(@identity))) + RTRIM(@identity))>> C:\script.sql
echo 	WHERE ID_PM = 'PM00'>> C:\script.sql
echo GO>> C:\script.sql
echo CREATE TRIGGER TG_PK_Products>> C:\script.sql
echo ON Products>> C:\script.sql
echo FOR INSERT>> C:\script.sql
echo AS>> C:\script.sql
echo 	DECLARE @identity int>> C:\script.sql
echo 	SET @identity = 0>> C:\script.sql
echo 	SELECT TOP 1 @identity = CONVERT(int, SUBSTRING(ID_P, 2, LEN(ID_P))) >> C:\script.sql
echo 		FROM Products ORDER BY ID_P DESC;>> C:\script.sql
echo 	SET @identity = @identity + 1;>> C:\script.sql
echo 	UPDATE Products >> C:\script.sql
echo 	SET ID_P = CONCAT('P', REPLICATE('0',3 - LEN(RTRIM(@identity))) + RTRIM(@identity))>> C:\script.sql
echo 	WHERE ID_P = 'P000'>> C:\script.sql
echo GO>> C:\script.sql
echo CREATE TRIGGER TG_PK_Specifications>> C:\script.sql
echo ON Specifications>> C:\script.sql
echo FOR INSERT>> C:\script.sql
echo AS>> C:\script.sql
echo 	DECLARE @identity int>> C:\script.sql
echo 	SET @identity = 0>> C:\script.sql
echo 	SELECT TOP 1 @identity = CONVERT(int, SUBSTRING(ID_S, 2, LEN(ID_S))) >> C:\script.sql
echo 		FROM Specifications ORDER BY ID_S DESC;>> C:\script.sql
echo 	SET @identity = @identity + 1;>> C:\script.sql
echo 	UPDATE Specifications >> C:\script.sql
echo 	SET ID_S = CONCAT('S', REPLICATE('0',3 - LEN(RTRIM(@identity))) + RTRIM(@identity))>> C:\script.sql
echo 	WHERE ID_S = 'S000'>> C:\script.sql
echo GO>> C:\script.sql
echo CREATE TRIGGER TG_PK_Raw_Material>> C:\script.sql
echo ON Raw_Material>> C:\script.sql
echo FOR INSERT>> C:\script.sql
echo AS>> C:\script.sql
echo 	DECLARE @identity int>> C:\script.sql
echo 	SET @identity = 0>> C:\script.sql
echo 	SELECT TOP 1 @identity = CONVERT(int, SUBSTRING(ID_RM, 3, LEN(ID_RM))) >> C:\script.sql
echo 		FROM Raw_Material ORDER BY ID_RM DESC;>> C:\script.sql
echo 	SET @identity = @identity + 1;>> C:\script.sql
echo 	UPDATE Raw_Material >> C:\script.sql
echo 	SET ID_RM = CONCAT('RM', REPLICATE('0',3 - LEN(RTRIM(@identity))) + RTRIM(@identity))>> C:\script.sql
echo 	WHERE ID_RM = 'RM000'>> C:\script.sql
echo GO>> C:\script.sql
echo CREATE TRIGGER TG_PK_Expenses>> C:\script.sql
echo ON Expenses>> C:\script.sql
echo FOR INSERT>> C:\script.sql
echo AS>> C:\script.sql
echo 	DECLARE @identity int>> C:\script.sql
echo 	DECLARE @quantity int>> C:\script.sql
echo 	DECLARE @amount money>> C:\script.sql
echo 	DECLARE @ID_RM char(5)>> C:\script.sql
echo 	SELECT TOP 1 @identity = CONVERT(int, SUBSTRING(ID_E, 2, LEN(ID_E))) >> C:\script.sql
echo 		FROM Expenses ORDER BY ID_E DESC;>> C:\script.sql
echo 	SET @identity = @identity + 1;>> C:\script.sql
echo 	SELECT @quantity = Quantity, @amount = Amount, @ID_RM = ID_RM>> C:\script.sql
echo 		FROM Expenses WHERE ID_E = 'E0000000'>> C:\script.sql
echo 	UPDATE Raw_Material>> C:\script.sql
echo 		SET Stock += @quantity WHERE ID_RM = @ID_RM>> C:\script.sql
echo 	UPDATE Finance_Details SET Balance -= @amount WHERE ID_FD = 'FD001'>> C:\script.sql
echo 	UPDATE Payment_Methods SET Balance -= @amount WHERE ID_PM = 'PM01'>> C:\script.sql
echo 	UPDATE Expenses >> C:\script.sql
echo 	SET ID_E = CONCAT('E', REPLICATE('0',7 - LEN(RTRIM(@identity))) + RTRIM(@identity))>> C:\script.sql
echo 	WHERE ID_E = 'E0000000'>> C:\script.sql
echo GO>> C:\script.sql
echo CREATE TRIGGER TG_PK_Order_Details>> C:\script.sql
echo ON Order_Details>> C:\script.sql
echo FOR INSERT>> C:\script.sql
echo AS>> C:\script.sql
echo 	DECLARE @identity int>> C:\script.sql
echo 	SET @identity = 0>> C:\script.sql
echo 	SELECT TOP 1 @identity = CONVERT(int, SUBSTRING(ID_OD, 3, LEN(ID_OD))) >> C:\script.sql
echo 		FROM Order_Details ORDER BY ID_OD DESC;>> C:\script.sql
echo 	SET @identity = @identity + 1;>> C:\script.sql
echo 	UPDATE Order_Details >> C:\script.sql
echo 	SET ID_OD = CONCAT('OD', REPLICATE('0',7 - LEN(RTRIM(@identity))) + RTRIM(@identity))>> C:\script.sql
echo 	WHERE ID_OD = 'OD0000000'>> C:\script.sql
echo GO>> C:\script.sql
echo CREATE TRIGGER TG_PK_Order>> C:\script.sql
echo ON Orders>> C:\script.sql
echo FOR INSERT>> C:\script.sql
echo AS>> C:\script.sql
echo 	DECLARE @identity int>> C:\script.sql
echo 	SET @identity = 0>> C:\script.sql
echo 	SELECT TOP 1 @identity = CONVERT(int, SUBSTRING(ID_O, 2, LEN(ID_O))) >> C:\script.sql
echo 		FROM Orders ORDER BY ID_O DESC;>> C:\script.sql
echo 	SET @identity = @identity + 1;>> C:\script.sql
echo 	UPDATE Orders>> C:\script.sql
echo 	SET ID_O = CONCAT('O', REPLICATE('0',7 - LEN(RTRIM(@identity))) + RTRIM(@identity))>> C:\script.sql
echo 	WHERE ID_O = 'O0000000'>> C:\script.sql
echo GO>> C:\script.sql
echo INSERT INTO Payment_Methods VALUES>> C:\script.sql
echo 	('PM00', 'Efectivo', 0.00);>> C:\script.sql
echo INSERT INTO Payment_Methods VALUES>> C:\script.sql
echo 	('PM00', 'Agrícola', 0.00);>> C:\script.sql
echo INSERT INTO Payment_Methods VALUES>> C:\script.sql
echo 	('PM00', 'BIM', 0.00);>> C:\script.sql
echo INSERT INTO Finance_Details VALUES>> C:\script.sql
echo 	('FD000', 'Bordablu', 0.00);>> C:\script.sql
echo INSERT INTO Finance_Details VALUES>> C:\script.sql
echo 	('FD000', 'Margarita', 0.00);>> C:\script.sql
echo INSERT INTO Finance_Details VALUES>> C:\script.sql
echo 	('FD000', 'Andrea', 0.00); >> C:\script.sql

echo INSERT INTO Products VALUES>> C:\script.sql
echo 	('P000', 'Camisas'); >> C:\script.sql
echo INSERT INTO Products VALUES>> C:\script.sql
echo 	('P000', 'Gorras'); >> C:\script.sql
echo INSERT INTO Products VALUES>> C:\script.sql
echo 	('P000', 'Bolsas'); >> C:\script.sql
echo INSERT INTO Products VALUES>> C:\script.sql
echo 	('P000', 'Cojines'); >> C:\script.sql
echo INSERT INTO Products VALUES>> C:\script.sql
echo 	('P000', 'Hoops'); >> C:\script.sql

echo INSERT INTO Specifications VALUES>> C:\script.sql
echo 	('S000', 'Cantidad', 'P001', 'Número entero'); >> C:\script.sql
echo INSERT INTO Specifications VALUES>> C:\script.sql
echo 	('S000', 'Talla', 'P001', 'Texto corto'); >> C:\script.sql
echo INSERT INTO Specifications VALUES>> C:\script.sql
echo 	('S000', 'Color', 'P001', 'Texto corto'); >> C:\script.sql
echo INSERT INTO Specifications VALUES>> C:\script.sql
echo 	('S000', 'Ubicación de bordado', 'P001', 'Texto corto'); >> C:\script.sql
echo INSERT INTO Specifications VALUES>> C:\script.sql
echo 	('S000', 'Tamaño Bordado', 'P001', 'Texto corto'); >> C:\script.sql
echo INSERT INTO Specifications VALUES>> C:\script.sql
echo 	('S000', 'Descripción', 'P001', 'Texto largo'); >> C:\script.sql
echo INSERT INTO Specifications VALUES>> C:\script.sql
echo 	('S000', 'Total', 'P001', 'Dinero'); >> C:\script.sql

echo INSERT INTO Specifications VALUES>> C:\script.sql
echo 	('S000', 'Cantidad', 'P002', 'Número entero'); >> C:\script.sql
echo INSERT INTO Specifications VALUES>> C:\script.sql
echo 	('S000', 'Color', 'P002', 'Texto corto'); >> C:\script.sql
echo INSERT INTO Specifications VALUES>> C:\script.sql
echo 	('S000', 'Ubicación de bordado', 'P002', 'Texto corto'); >> C:\script.sql
echo INSERT INTO Specifications VALUES>> C:\script.sql
echo 	('S000', 'Tamaño del bordado', 'P002', 'Texto corto'); >> C:\script.sql
echo INSERT INTO Specifications VALUES>> C:\script.sql
echo 	('S000', 'Descripción del diseño', 'P002', 'Texto largo'); >> C:\script.sql
echo INSERT INTO Specifications VALUES>> C:\script.sql
echo 	('S000', 'Total', 'P002', 'Dinero'); >> C:\script.sql

echo INSERT INTO Specifications VALUES>> C:\script.sql
echo 	('S000', 'Cantidad', 'P003', 'Número entero'); >> C:\script.sql
echo INSERT INTO Specifications VALUES>> C:\script.sql
echo 	('S000', 'Tamaño de la bolsa', 'P003', 'Texto corto'); >> C:\script.sql
echo INSERT INTO Specifications VALUES>> C:\script.sql
echo 	('S000', 'Ubicación del bordado', 'P003', 'Texto corto'); >> C:\script.sql
echo INSERT INTO Specifications VALUES>> C:\script.sql
echo 	('S000', 'Tamaño del bordado', 'P003', 'Texto corto'); >> C:\script.sql
echo INSERT INTO Specifications VALUES>> C:\script.sql
echo 	('S000', 'Descripción del diseño', 'P003', 'Texto largo'); >> C:\script.sql
echo INSERT INTO Specifications VALUES>> C:\script.sql
echo 	('S000', 'Total', 'P003', 'Dinero'); >> C:\script.sql

echo INSERT INTO Specifications VALUES>> C:\script.sql
echo 	('S000', 'Dimension funda', 'P004', 'Texto corto'); >> C:\script.sql
echo INSERT INTO Specifications VALUES>> C:\script.sql
echo 	('S000', 'Cantidad', 'P004', 'Número entero'); >> C:\script.sql
echo INSERT INTO Specifications VALUES>> C:\script.sql
echo 	('S000', 'Ubicación del bordado', 'P004', 'Texto corto'); >> C:\script.sql
echo INSERT INTO Specifications VALUES>> C:\script.sql
echo 	('S000', 'Descripción del diseño', 'P004', 'Texto largo'); >> C:\script.sql
echo INSERT INTO Specifications VALUES>> C:\script.sql
echo 	('S000', 'Total', 'P004', 'Dinero'); >> C:\script.sql

echo INSERT INTO Specifications VALUES>> C:\script.sql
echo 	('S000', 'Tamaño', 'P005', 'Texto corto'); >> C:\script.sql
echo INSERT INTO Specifications VALUES>> C:\script.sql
echo 	('S000', 'Cantidad', 'P005', 'Número entero'); >> C:\script.sql
echo INSERT INTO Specifications VALUES>> C:\script.sql
echo 	('S000', 'Descripción del diseño', 'P005', 'Texto largo'); >> C:\script.sql
echo INSERT INTO Specifications VALUES>> C:\script.sql
echo 	('S000', 'Total', 'P005', 'Dinero'); >> C:\script.sql

sqlcmd -S localhost\SQLEXPRESS -i "C:\script.sql" -f 65001
del "C:\script.sql"