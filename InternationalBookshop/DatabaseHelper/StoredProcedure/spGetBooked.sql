USE [InternationalBookShop]
GO
/****** Object:  StoredProcedure [dbo].[spGetBooked]    Script Date: 17/04/2024 09:23:58 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spGetBooked]
	@email varchar(50)
AS
BEGIN
	SELECT * FROM Booked WHERE email=@email
END
