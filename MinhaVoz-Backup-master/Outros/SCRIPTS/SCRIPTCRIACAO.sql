CREATE DATABASE MinhaVozManha

USE MinhaVozManha

CREATE TABLE Tipo_Usuario(
ID INT PRIMARY KEY IDENTITY,
NOME VARCHAR(30)NOT NULL UNIQUE 
);

CREATE TABLE Usuario(
ID INT PRIMARY KEY IDENTITY,
ID_TIPO_USUARIO INT  NOT NULL FOREIGN KEY REFERENCES Tipo_Usuario(ID),
EMAIL VARCHAR(50) NOT NULL,
SENHA VARCHAR(50) NOT NULL
);

CREATE TABLE Chamado(
ID INT PRIMARY KEY IDENTITY,
NOME VARCHAR(100) NOT NULL,
EMAIL VARCHAR(50) NOT NULL, 
TELEFONE VARCHAR(30) NOT NULL UNIQUE,
TITULO VARCHAR(30) NOT NULL,
ASSUNTO VARCHAR (40) NOT NULL,
DESCRICAO VARCHAR(500) NOT NULL,
STATUS VARCHAR(30) NOT NULL,
DATA DATETIME NOT NULL
);
