USE [InternationalBookShop]
GO
/****** Object:  StoredProcedure [dbo].[spSaveTrolley]    Script Date: 14/04/2024 11:49:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spSaveTrolley]
	@bookid INT,
	@name VARCHAR(50),
	@email VARCHAR (50),
	@ISBN VARCHAR(50),
	@photoPath VARCHAR(100),
	@title VARCHAR(50),
	@author VARCHAR(50),
	@publicationDate datetime,
	@price DECIMAL
AS
BEGIN
	INSERT INTO [dbo].[Trolley] ([bookid], [name], [email], [ISBN], [photopath], [title], [author], [publicationdate], [price])
	VALUES (@bookid, @name, @email, @ISBN, @photoPath, @title, @author, @publicationDate, @price)
END
