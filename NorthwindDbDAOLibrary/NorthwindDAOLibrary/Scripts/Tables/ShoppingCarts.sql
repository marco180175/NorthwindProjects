USE [Northwind]
GO

/****** Object:  Table [dbo].[ShoppingCarts]    Script Date: 15/08/2020 21:18:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ShoppingCarts](
	[ShoppingCartID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [varchar](10) NOT NULL,
	[Date] [date] NOT NULL,
	[Description] [varchar](128) NULL,
 CONSTRAINT [PK_ShoppingCarts] PRIMARY KEY CLUSTERED 
(
	[ShoppingCartID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


