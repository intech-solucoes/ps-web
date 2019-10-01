CREATE TABLE [dbo].[WEB_DOCUMENTO_PLANO](
	[OID_DOCUMENTO_PLANO] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[OID_DOCUMENTO] [numeric](10, 0) NOT NULL,
	[SQ_PLANO_PREVIDENCIAL] [int] NOT NULL,
 CONSTRAINT [WEB_DOCUMENTO_PLANO_PK] PRIMARY KEY CLUSTERED 
(
	[OID_DOCUMENTO_PLANO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[WEB_DOCUMENTO_PLANO]  WITH CHECK ADD  CONSTRAINT [WEB_DOCUMENTO_PLANO_FK01] FOREIGN KEY([OID_DOCUMENTO])
REFERENCES [dbo].[WEB_DOCUMENTO] ([OID_DOCUMENTO])
GO

ALTER TABLE [dbo].[WEB_DOCUMENTO_PLANO] CHECK CONSTRAINT [WEB_DOCUMENTO_PLANO_FK01]
GO

