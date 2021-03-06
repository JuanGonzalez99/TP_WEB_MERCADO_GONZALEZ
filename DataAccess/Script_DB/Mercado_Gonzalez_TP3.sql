USE master
GO
DECLARE @dbname nvarchar(128)
SET @dbname = N'Mercado_Gonzalez_TP3'

IF (EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE ('[' + name + ']' = @dbname 
OR name = @dbname)))
DROP DATABASE Mercado_Gonzalez_TP3

GO

CREATE DATABASE Mercado_Gonzalez_TP3
GO
USE [Mercado_Gonzalez_TP3]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 31/5/2019 15:42:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 31/5/2019 15:42:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Clienteid] [int] IDENTITY(1,1) NOT NULL,
	[Documento] [nvarchar](20) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Apellido] [nvarchar](100) NOT NULL,
	[Localidad] [nvarchar](50) NULL,
	[Provincia] [nvarchar](50) NULL,
	[Direccion] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_dbo.Clientes] PRIMARY KEY CLUSTERED 
(
	[Clienteid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Premios]    Script Date: 31/5/2019 15:42:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Premios](
	[IdPremio] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
	[URL] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_dbo.Premios] PRIMARY KEY CLUSTERED 
(
	[IdPremio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sorteo]    Script Date: 31/5/2019 15:42:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sorteo](
	[IdSorteo] [int] IDENTITY(1,1) NOT NULL,
	[Cliente_Clienteid] [int] NULL,
	[Premio_IdPremio] [int] NULL,
	[Voucher_IdVoucher] [int] NULL,
 CONSTRAINT [PK_dbo.Sorteo] PRIMARY KEY CLUSTERED 
(
	[IdSorteo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Voucher]    Script Date: 31/5/2019 15:42:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Voucher](
	[IdVoucher] [int] IDENTITY(1,1) NOT NULL,
	[CodigoPromocional] [nvarchar](100) UNIQUE NOT NULL,
	[Estado] [bit] DEFAULT 0 NOT NULL,
 CONSTRAINT [PK_dbo.Voucher] PRIMARY KEY CLUSTERED 
(
	[IdVoucher] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Sorteo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Sorteo_dbo.Clientes_Cliente_Clienteid] FOREIGN KEY([Cliente_Clienteid])
REFERENCES [dbo].[Clientes] ([Clienteid])
GO
ALTER TABLE [dbo].[Sorteo] CHECK CONSTRAINT [FK_dbo.Sorteo_dbo.Clientes_Cliente_Clienteid]
GO
ALTER TABLE [dbo].[Sorteo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Sorteo_dbo.Premios_Premio_IdPremio] FOREIGN KEY([Premio_IdPremio])
REFERENCES [dbo].[Premios] ([IdPremio])
GO
ALTER TABLE [dbo].[Sorteo] CHECK CONSTRAINT [FK_dbo.Sorteo_dbo.Premios_Premio_IdPremio]
GO
ALTER TABLE [dbo].[Sorteo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Sorteo_dbo.Voucher_Voucher_IdVoucher] FOREIGN KEY([Voucher_IdVoucher])
REFERENCES [dbo].[Voucher] ([IdVoucher])
GO
ALTER TABLE [dbo].[Sorteo] CHECK CONSTRAINT [FK_dbo.Sorteo_dbo.Voucher_Voucher_IdVoucher]
GO

INSERT INTO Premios
VALUES ('Auriculares', 'https://media.game.es/COVERV2/3D_L/117/117735.png')
GO
INSERT INTO Premios
Values ('Mouse', 'https://jumbocolombiafood.vteximg.com.br/arquivos/ids/3233000-750-750/image-5ebcd5ad41a14f468286531d70e52855.jpg?v=636536270750630000')
GO
INSERT INTO Premios
VALUES ('Silla', 'https://images-na.ssl-images-amazon.com/images/I/61ZIeF3%2BBFL._SY355_.jpg')
GO
INSERT INTO Premios
VALUES ('Teclado', 'https://www.tastytechshop.cl/wp-content/uploads/1-Teclado-Gamer-Limeme-TX30-104-pc-gamer-audifonos-teclados-mouse-mecanico-mousepads-gamers-videojuego-videojuegos-componentes.jpg')

GO

DECLARE @cnt INT = 0;
WHILE @cnt < 100
BEGIN
   INSERT INTO Voucher 
   VALUES (CONVERT(VARCHAR(32), HashBytes('MD5', CONVERT(varchar, SYSDATETIME(), 121)), 2), 0)
   
   SET @cnt = @cnt + 1;
   WAITFOR DELAY '00:00:00.002'
END;
