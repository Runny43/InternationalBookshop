USE [InternationalBookShop]
GO
/****** Object:  StoredProcedure [dbo].[spGetTrolley]    Script Date: 16/04/2024 03:04:24 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spGetTrolley]
	@email varchar(50)
AS
BEGIN
	SELECT * FROM Trolley WHERE email=@email
END
