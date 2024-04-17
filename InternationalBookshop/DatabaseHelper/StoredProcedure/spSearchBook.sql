USE [InternationalBookShop]
GO
/****** Object:  StoredProcedure [dbo].[spSearchBook]    Script Date: 17/04/2024 08:10:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spSearchBook]
	@name VARCHAR(50)
AS
BEGIN
	SELECT * FROM [InternationalBookShop].[dbo].[Book] WHERE [title] LIKE '%'+@name+'%' OR [ISBN] LIKE '%'+@name+'%'
END
