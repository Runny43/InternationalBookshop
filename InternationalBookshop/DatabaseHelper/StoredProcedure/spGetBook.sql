USE [InternationalBookShop]
GO
/****** Object:  StoredProcedure [dbo].[spGetBook]    Script Date: 10/04/2024 02:09:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spGetBook]
	
AS
BEGIN
	SELECT * FROM Book
END
