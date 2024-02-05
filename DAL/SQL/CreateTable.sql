CREATE TABLE Users(
Id INT PRIMARY KEY IDENTITY,
email VARCHAR(255),
password VARCHAR(30),
firstname VARCHAR(20),
lastname VARCHAR(100),
phone VARCHAR(15),
birthdate DATE
)

CREATE TABLE Article (
Id INT PRIMARY KEY IDENTITY,
title VARCHAR(50),
type INT,
price DECIMAL,
link VARCHAR(MAX),
description VARCHAR(255),
UsersID INT,
CONSTRAINT FK_UsersArticle FOREIGN KEY (UsersID)
REFERENCES Users(Id)
)

CREATE TABLE Agenda(
Id INT PRIMARY KEY IDENTITY,
startDate DATE,
endDate DATE,
ArticleID INT,
CONSTRAINT FK_ArticleAgenda FOREIGN KEY (ArticleID)
REFERENCES Article(Id)
)

CREATE TABLE Favorite(
UsersID INT,
ArticleID INT,
CONSTRAINT FK_FavoriteUsers FOREIGN KEY (UsersID)
REFERENCES Users(Id),
CONSTRAINT FK_FavoriteArticle FOREIGN KEY (ArticleID)
REFERENCES Article(Id)
)