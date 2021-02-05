CREATE PROCEDURE AssignEmployee
	@ReportNumber int,
	@EmployeeID int,
	@SupervisorId int
AS
BEGIN
    -- Insert statements for procedure here
	UPDATE Issue SET
	[EmployeeId] = @EmployeeID,
	[SupervisorId] = @SupervisorId,
	[ModifyBy] = @SupervisorId,
	[ModifyDate] = GETDATE()
 	WHERE [ReportNumber] = @ReportNumber

END
GO
