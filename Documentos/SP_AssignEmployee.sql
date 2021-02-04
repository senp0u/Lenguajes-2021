CREATE PROCEDURE AssignEmployee
	@ReportNumber int,
	@EmployeeID int
AS
BEGIN
    -- Insert statements for procedure here
	UPDATE Issue SET
	[EmployeeId] = @EmployeeID
	WHERE [ReportNumber] = @ReportNumber

END
GO
