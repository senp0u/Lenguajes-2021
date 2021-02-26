Create procedure [dbo].[GetLastInsertIssue]
AS
BEGIN

	SELECT [issue_id]
      ,[create_at]
      ,[create_by]
      ,[description]
      ,[modify_at]
      ,[modify_by]
      ,[status]
      ,[supporter_user]
      ,[service_id]
      ,[client_id]
	FROM [DB_A6F43E_ClientDB].[dbo].[issue]
	WHERE issue_id = @@Identity 

 END
