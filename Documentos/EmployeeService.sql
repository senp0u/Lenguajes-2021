CREATE PROCEDURE EmployeeServiceSP
	@EmployeeId int,
	@ServiceId int,
	@CreateBy int
AS
BEGIN
    
	INSERT INTO [dbo].[EmployeeService]
           ([EmployeeId]
           ,[ServiceId]
           ,[CreateBy]
           ,[CreateDate])
     VALUES
           (@EmployeeId,
            @ServiceId,
            @CreateBy,
            GETDATE())

END
GO
