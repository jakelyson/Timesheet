USE [Paymatic]
GO

/****** Object:  Table [dbo].[tbl_TimeSheet]    Script Date: 2/24/2016 5:52:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_TimeSheet](
	[TimeSheetID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [nvarchar](10) NULL,
	[Date] [datetime] NULL,
	[TimeIn] [datetime] NULL,
	[BreakOut] [datetime] NULL,
	[Resume] [datetime] NULL,
	[Out] [datetime] NULL,
	[OT] [datetime] NULL,
	[Done] [datetime] NULL,
	[HoursWork] [decimal](18, 2) NULL,
 CONSTRAINT [PK_tbl_TimeSheet] PRIMARY KEY CLUSTERED 
(
	[TimeSheetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

