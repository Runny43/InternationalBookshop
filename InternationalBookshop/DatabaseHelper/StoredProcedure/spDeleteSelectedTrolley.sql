USE [InternationalBookShop]
GO
/****** Object:  StoredProcedure [dbo].[spDeleteSelectedTrolley]    Script Date: 17/04/2024 09:24:25 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spDeleteSelectedTrolley] 
	@bookid int
AS
BEGIN
	DELETE FROM Trolley WHERE bookid= @bookid
END
