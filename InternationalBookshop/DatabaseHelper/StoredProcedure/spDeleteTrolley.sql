USE [InternationalBookShop]
GO
/****** Object:  StoredProcedure [dbo].[spDeleteTrolley]    Script Date: 17/04/2024 09:22:54 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spDeleteTrolley]
	@email VARCHAR(50)
AS
BEGIN
	DELETE FROM Trolley WHERE email= @email
END
