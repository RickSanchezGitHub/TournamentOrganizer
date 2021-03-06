CREATE TABLE [dbo].[Player](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](25) NOT NULL,
	[LastName] [varchar](25) NOT NULL,
	[Name] [varchar](25) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Birthday] [date] NOT NULL,
 CONSTRAINT [PK_PLAYER] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
)