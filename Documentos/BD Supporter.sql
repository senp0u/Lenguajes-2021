USE DB_A6E1ED_lenguajes

CREATE TABLE [dbo].[Service](
	[ServiceId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [nvarchar](20) NOT NULL UNIQUE,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int],
	[CreateDate] [DATETIME] NOT NULL,
	[ModifyDate] [DATETIME]
	)



CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [nvarchar](25) NOT NULL,
	[FirstSurname] [nvarchar](30) NOT NULL,
	[SecondSurname] [nvarchar](30) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[IsSupervisor] [bit] NOT NULL,
	[SupervisorId] [int] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int],
	[CreateDate] [DATETIME] NOT NULL,
	[ModifyDate] [DATETIME], 
	CONSTRAINT Supervisor_FK foreign key (SupervisorId) REFERENCES [dbo].[Employee](EmployeeId)
	)

CREATE TABLE [dbo].[EmployeeService](
	[EmployeeId] [int] NOT NULL,
	[ServiceId] [int] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int],
	[CreateDate] [DATETIME] NOT NULL,
	[ModifyDate] [DATETIME], 
	CONSTRAINT Employee_Service_PK PRIMARY KEY ([EmployeeId],[ServiceId]),
	CONSTRAINT Employee_Service_FK1 foreign key (EmployeeId) REFERENCES [dbo].[Employee](EmployeeId),
	CONSTRAINT Employee_Service_FK2 foreign key (ServiceId) REFERENCES [dbo].[Service](ServiceId)
)

CREATE TABLE [dbo].[Issue](
	[ReportNumber] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Classification] [nvarchar](5) NOT NULL,
	[Status] [nvarchar](12) NOT NULL,
	[ReportDate] [DATETIME] NOT NULL,
	[ResolutionComment] [nvarchar](255) NOT NULL,
	[EmployeeId] [int],
	[SupervisorId] [int],
	[ServiceId] [int]  NOT NULL,
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int],
	[CreateDate] [DATETIME] NOT NULL,
	[ModifyDate] [DATETIME], 
	CONSTRAINT Employee_FK foreign key (EmployeeId) REFERENCES [dbo].[Employee](EmployeeId),
	CONSTRAINT Service_FK foreign key (ServiceId) REFERENCES [dbo].[Service](ServiceId),
	CONSTRAINT Supervisor_FK2 foreign key (SupervisorId) REFERENCES [dbo].[Employee](EmployeeId)

	)

CREATE TABLE [dbo].[Notes](
	[NotesId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Description] [nvarchar](100) NOT NULL,
	[NoteDate] [DATETIME] NOT NULL,
	[ReportNumber] [int] NOT NULL,
	[EmployeeId] [int],
	[CreateBy] [int] NOT NULL,
	[ModifyBy] [int],
	[CreateDate] [DATETIME] NOT NULL,
	[ModifyDate] [DATETIME], 
	CONSTRAINT Employee_FK2 foreign key (EmployeeId) REFERENCES [dbo].[Employee](EmployeeId),
	CONSTRAINT Report_FK foreign key (ReportNumber) REFERENCES [dbo].[Issue](ReportNumber)
)