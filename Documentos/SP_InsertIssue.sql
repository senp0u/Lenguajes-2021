Create procedure [dbo].[InsertIssue]
	@Description varchar(100), @ServiceId int, @ClientEmail varchar(30)
AS
BEGIN

	declare @ClientId int, @ClientName varchar(25), @ClientSurname varchar(20);

	SELECT @ClientId = c.client_id, @ClientName = c.name , @ClientSurname = c.first_surname
	FROM client c 
	WHERE email = @ClientEmail

	INSERT INTO [dbo].[issue](
			[create_at]
           ,[create_by]
           ,[description]
           ,[modify_at]
           ,[modify_by]
           ,[status]
           ,[supporter_user]
           ,[service_id]
           ,[client_id])
     VALUES
           (GETDATE(),
           CONCAT (@ClientName, ' ',@ClientSurname),
           @Description,
           NULL,
           NULL,
           'Ingresado',
           'Por asignar',
           @ServiceId,
           @ClientId)

END