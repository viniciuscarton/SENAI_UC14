CREATE DATABASE dbExoApi;

USE dbExoApi;
CREATE TABLE Projetos 
(
	Id INT PRIMARY KEY IDENTITY,
	Titulo VARCHAR(150) NOT NULL,
	Status VARCHAR(150) NOT NULL,
	DataInicio VARCHAR(10) NOT NULL,
	Area VARCHAR(150) NOT NULL
);
 
 INSERT INTO Projetos (Titulo, Status, DataInicio, Area)
 VALUES ('Projeto Manhattan', 'Planejamento', '10/10/2022', 'Inteligência');
 INSERT INTO Projetos (Titulo, Status, DataInicio, Area)
 VALUES ('Projeto ´Apocalipse', 'Iniciado', '01/05/2022', 'T.I.')

 SELECT * FROM Projetos

 CREATE TABLE Usuarios
(
	Id INT PRIMARY KEY IDENTITY,
	Email VARCHAR(300) NOT NULL UNIQUE, 
	Senha VARCHAR(100) NOT NULL,
	Tipo CHAR (1) NOT NULL
);

INSERT INTO Usuarios VALUES ('email1@email.com', '1234', '0')
 
 SELECT * FROM Usuarios
