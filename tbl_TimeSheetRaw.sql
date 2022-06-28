USE [Paymatic]
GO

/****** Object:  Table [dbo].[tbl_TimesheetRaw]    Script Date: 2/24/2016 5:52:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_TimesheetRaw](
	[UserId] [nvarchar](10) NULL,
	[Name] [nvarchar](50) NULL,
	[Shift] [int] NULL,
	[Punch] [datetime] NULL
) ON [PRIMARY]

GO

