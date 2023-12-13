IF ( NOT EXISTS ( SELECT    * FROM      INFORMATION_SCHEMA.TABLES
              WHERE     Table_Schema = 'dbo' AND Table_Name = 'Staff' ) ) 
BEGIN
CREATE TABLE [dbo].Staff(
	ID int identity  NOT NULL,
	FullName nvarchar(200) not null,
	ShortName nvarchar(50)
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	ID ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END

GO

IF ( NOT EXISTS ( SELECT    * FROM      INFORMATION_SCHEMA.TABLES
              WHERE     Table_Schema = 'dbo' AND Table_Name = 'Task')) 
BEGIN
CREATE TABLE [dbo].Task(
	ID int identity  NOT NULL,
	IDParent int,
	[Label] varchar(30),
	Type varchar(30),
	Name nvarchar(200),
	StartDate datetime,
	EndDate datetime,
	Duration int,
	Progress int,
	IsUnscheduled bit
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	ID ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END

GO

IF ( NOT EXISTS ( SELECT    * FROM      INFORMATION_SCHEMA.TABLES
              WHERE     Table_Schema = 'dbo' AND Table_Name = 'StaffInTask' ) ) 
BEGIN
CREATE TABLE [dbo].StaffInTask(
	ID int identity  NOT NULL,
	IDStaff int NOT NULL,
	IDStask int NOT NULL
 CONSTRAINT [PK_StaffInTask] PRIMARY KEY CLUSTERED 
(
	ID ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO

--ALTER TABLE [dbo].StaffInTask
--ADD CONSTRAINT FK_StaffInTask_IDStaff FOREIGN KEY (IDStaff) REFERENCES [dbo].Staff(ID);

--GO

--ALTER TABLE [dbo].StaffInTask
--ADD CONSTRAINT FK_StaffInTask_IDStask FOREIGN KEY (IDStask) REFERENCES [dbo].Task(ID);


--ALTER TABLE [dbo].StaffInTask DROP CONSTRAINT FK_StaffInTask_IDStask;
--ALTER TABLE [dbo].StaffInTask DROP CONSTRAINT FK_StaffInTask_IDStaff;

select * from Staff