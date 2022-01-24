 USE master;
GO

IF DB_ID(N'Warenbestand_Fahrradladen') IS NULL
  CREATE DATABASE Warenbestand_Fahrradladen;
GO

USE Warenbestand_Fahrradladen;
GO 

IF OBJECT_ID('log') IS NOT NULL
  DROP TABLE log;
GO

IF OBJECT_ID('Ware') IS NOT NULL
  DROP TABLE Ware;
GO

IF OBJECT_ID('Benutzer') IS NOT NULL
  DROP TABLE Benutzer;
GO


CREATE TABLE Benutzer (
  ID_Benutzer int NOT NULL IDENTITY PRIMARY KEY, 
  Name nvarchar(40),
  Rolle nvarchar(20),
  Passwort nvarchar(32),
);


CREATE TABLE Ware (
  ID_Ware int NOT NULL IDENTITY PRIMARY KEY, 
  Name nvarchar(500),
  Anzahl int,
  Listenpreis decimal ,
);


CREATE TABLE log (
  ID_LogNr int IDENTITY NOT NULL PRIMARY KEY,
  hinzufügen int, 
  entfernen int,
  Datum datetime,
  Nutzer_ID int,
  Waren_ID int,
  CONSTRAINT FK_Nutzer_ID FOREIGN KEY (Nutzer_ID) REFERENCES Benutzer(ID_Benutzer),
  CONSTRAINT FK_Waren_ID FOREIGN KEY (Waren_ID) REFERENCES Ware (ID_Ware)
  );

INSERT INTO Benutzer(Name, Rolle, Passwort) VALUES ('Mohamad','Mitarbeiter','demo1234'), ('Tim','Leiter','demo1234'), ('Drilon','Admin','demo1234');

INSERT INTO Ware (Name, Anzahl, Listenpreis) VALUES
  ('Schaltwerk', 20, 39.99),
  ('Griffe', 30, 24.99),
  ('Kassette', 30, 79.99),
  ('Kettenblatt', 15, 84.99),
  ('Bremse', 25, 14.99),
  ('Klingle', 50, 9.99),
  ('Rad', 25, 19.44),
  ('Sitz', 15, 74.99),
  ('Bremsscheibe', 20, 19.99),
  ('Schlauch', 30, 4.99);

  INSERT INTO log(hinzufügen, Datum, Nutzer_ID ,Waren_ID) VALUES 
  (20, '22-01-2022 12:47:30', 1, 1),
  (30, '20220101', 2, 2),
  (30, GETDATE(), 3, 3),
  (15, GETDATE(), 3, 4),
  (25, GETDATE(), 2, 5),
  (50, GETDATE(), 1, 6),
  (25, GETDATE(), 1, 7),
  (15, GETDATE(), 2, 8),
  (20, GETDATE(), 3, 9),
  (30, GETDATE(), 1, 10);

  select * from Benutzer;
  select * from Ware;
  select * from log;