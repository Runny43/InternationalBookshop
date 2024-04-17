USE [InternationalBookShop]
GO
/****** Object:  StoredProcedure [dbo].[spSaveBooked]    Script Date: 17/04/2024 09:03:22 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spSaveBooked]
	@bookid int,
	@name VARCHAR(50),
	@email VARCHAR(50),
	@country VARCHAR(50),
	@province VARCHAR(50),
	@address VARCHAR(50),
	@postalcode int,
	@cardnumber int,
	@checkout datetime,
	@securitycode int,
	@created datetime,
	@total int
AS
BEGIN
     INSERT INTO [dbo].[Booked] ([bookid], [name], [email], [country], [province], [address], [postalcode], [cardnumber], [checkout], [securitycode], [created], [total])
	VALUES (@bookid, @name, @email, @country, @province, @address, @postalcode, @cardnumber, @checkout, @securitycode, GETDATE(), @total)
END
