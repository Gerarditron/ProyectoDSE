USE [master]
GO
/****** Object:  Database [facturacionDB]    Script Date: 3/11/2022 20:53:27 ******/
CREATE DATABASE [facturacionDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'facturacionDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\facturacionDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'facturacionDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\facturacionDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [facturacionDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [facturacionDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [facturacionDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [facturacionDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [facturacionDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [facturacionDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [facturacionDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [facturacionDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [facturacionDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [facturacionDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [facturacionDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [facturacionDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [facturacionDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [facturacionDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [facturacionDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [facturacionDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [facturacionDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [facturacionDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [facturacionDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [facturacionDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [facturacionDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [facturacionDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [facturacionDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [facturacionDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [facturacionDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [facturacionDB] SET  MULTI_USER 
GO
ALTER DATABASE [facturacionDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [facturacionDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [facturacionDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [facturacionDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [facturacionDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [facturacionDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [facturacionDB] SET QUERY_STORE = OFF
GO
USE [facturacionDB]
GO
/****** Object:  Table [dbo].[bitacoras]    Script Date: 3/11/2022 20:53:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bitacoras](
	[idBitacora] [int] IDENTITY(1,1) NOT NULL,
	[idCliente] [int] NULL,
	[descripcion] [varchar](50) NULL,
	[numReferencia] [varchar](60) NULL,
	[fechaCreacion] [date] NULL,
	[fechaVerificada] [date] NULL,
	[horaVerificada] [time](7) NULL,
	[montoTotal] [money] NULL,
	[completada] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idBitacora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[clientes]    Script Date: 3/11/2022 20:53:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clientes](
	[idCliente] [int] IDENTITY(1,1) NOT NULL,
	[idTipoCliente] [int] NULL,
	[nombreCliente] [varchar](50) NULL,
	[apellidoCliente] [varchar](50) NULL,
	[activo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[facturas]    Script Date: 3/11/2022 20:53:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[facturas](
	[idFactura] [int] IDENTITY(1,1) NOT NULL,
	[idTipoProceso] [int] NULL,
	[idBitacora] [int] NULL,
	[concepto] [varchar](50) NULL,
	[fechaFactura] [date] NULL,
	[valor] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[idFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipoCliente]    Script Date: 3/11/2022 20:53:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipoCliente](
	[idTipoCliente] [int] IDENTITY(1,1) NOT NULL,
	[tipoCliente] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[idTipoCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipoProceso]    Script Date: 3/11/2022 20:53:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipoProceso](
	[idTipoProceso] [int] IDENTITY(1,1) NOT NULL,
	[tipoProceso] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[idTipoProceso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[clientes] ON 

INSERT [dbo].[clientes] ([idCliente], [idTipoCliente], [nombreCliente], [apellidoCliente], [activo]) VALUES (1, 1, N'David', N'Moya', 1)
INSERT [dbo].[clientes] ([idCliente], [idTipoCliente], [nombreCliente], [apellidoCliente], [activo]) VALUES (2, 2, N'Enrique', N'Aguilar', 0)
SET IDENTITY_INSERT [dbo].[clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[tipoCliente] ON 

INSERT [dbo].[tipoCliente] ([idTipoCliente], [tipoCliente]) VALUES (1, N'Personas')
INSERT [dbo].[tipoCliente] ([idTipoCliente], [tipoCliente]) VALUES (2, N'Empresas')
SET IDENTITY_INSERT [dbo].[tipoCliente] OFF
GO
SET IDENTITY_INSERT [dbo].[tipoProceso] ON 

INSERT [dbo].[tipoProceso] ([idTipoProceso], [tipoProceso]) VALUES (1, N'Cargo')
INSERT [dbo].[tipoProceso] ([idTipoProceso], [tipoProceso]) VALUES (2, N'Abono')
SET IDENTITY_INSERT [dbo].[tipoProceso] OFF
GO
ALTER TABLE [dbo].[bitacoras]  WITH CHECK ADD FOREIGN KEY([idCliente])
REFERENCES [dbo].[clientes] ([idCliente])
GO
ALTER TABLE [dbo].[clientes]  WITH CHECK ADD FOREIGN KEY([idTipoCliente])
REFERENCES [dbo].[tipoCliente] ([idTipoCliente])
GO
ALTER TABLE [dbo].[facturas]  WITH CHECK ADD FOREIGN KEY([idBitacora])
REFERENCES [dbo].[bitacoras] ([idBitacora])
GO
ALTER TABLE [dbo].[facturas]  WITH CHECK ADD FOREIGN KEY([idTipoProceso])
REFERENCES [dbo].[tipoProceso] ([idTipoProceso])
GO
USE [master]
GO
ALTER DATABASE [facturacionDB] SET  READ_WRITE 
GO
