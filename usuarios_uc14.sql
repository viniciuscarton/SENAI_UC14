use Chapter;

CREATE TABLE Usuarios
(
	Id INT PRIMARY KEY IDENTITY,
	Email VARCHAR(300) NOT NULL UNIQUE, 
	Senha VARCHAR(100) NOT NULL,
	Tipo CHAR (1) NOT NULL
);

INSERT INTO Usuarios VALUES ('email1@email.com', '1234', '0')
 
 SELECT * FROM Usuarios