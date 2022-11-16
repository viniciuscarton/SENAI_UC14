CREATE DATABASE Chapter;

USE Chapter;

CREATE TABLE Livros
(
	Id INT PRIMARY KEY IDENTITY,
	Titulo VARCHAR(150) NOT NULL,
	Paginas INT,
	Disponivel BIT
);

INSERT INTO Livros (Titulo, Paginas, Disponivel)
VALUES ('Harry Potter e a Pedra Filosofal', 150, 1);

INSERT INTO Livros (Titulo, Paginas, Disponivel)
VALUES ('It, A Coisa', 1300, 0)

SELECT * FROM Livros