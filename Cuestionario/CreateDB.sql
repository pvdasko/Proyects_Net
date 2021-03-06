USE [master]
GO
/****** Object:  Database [cuestionario]    Script Date: 21/05/2017 06:27:57 p. m. ******/
CREATE DATABASE [cuestionario]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Bluekey_Cuestionario', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\data\cuestionario_Data.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Bluekey_Cuestionario_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\data\cuestionario_Log.ldf' , SIZE = 3456KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [cuestionario] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [cuestionario].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [cuestionario] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [cuestionario] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [cuestionario] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [cuestionario] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [cuestionario] SET ARITHABORT OFF 
GO
ALTER DATABASE [cuestionario] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [cuestionario] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [cuestionario] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [cuestionario] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [cuestionario] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [cuestionario] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [cuestionario] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [cuestionario] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [cuestionario] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [cuestionario] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [cuestionario] SET  DISABLE_BROKER 
GO
ALTER DATABASE [cuestionario] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [cuestionario] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [cuestionario] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [cuestionario] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [cuestionario] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [cuestionario] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [cuestionario] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [cuestionario] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [cuestionario] SET  MULTI_USER 
GO
ALTER DATABASE [cuestionario] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [cuestionario] SET DB_CHAINING OFF 
GO
ALTER DATABASE [cuestionario] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [cuestionario] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [cuestionario]
GO
/****** Object:  User [Cuestionario]    Script Date: 21/05/2017 06:27:58 p. m. ******/
CREATE USER [Cuestionario] FOR LOGIN [Cuestionario] WITH DEFAULT_SCHEMA=[Cuestionario]
GO
ALTER ROLE [db_owner] ADD MEMBER [Cuestionario]
GO
/****** Object:  Schema [Cuestionario]    Script Date: 21/05/2017 06:27:59 p. m. ******/
CREATE SCHEMA [Cuestionario]
GO
/****** Object:  StoredProcedure [dbo].[Ins_Preguntas]    Script Date: 21/05/2017 06:27:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ins_Preguntas]
	@Corporativo int = 0,
	@Hotel int,
	@TipoCuestionario nvarchar(5),
	@NoPregunta int,
	@TipoPregunta nvarchar(5),
	@Pregunta nvarchar(150),
	@PreguntaIngles nvarchar(50),
	@CalificacionMax Int
AS
	INSERT INTO [dbo].[C_Preguntas Cuestionario] VALUES (
	@Corporativo,
	@Hotel,
	@TipoCuestionario,
	@NoPregunta,
	@TipoPregunta,
	@Pregunta,
	@PreguntaIngles,
	@CalificacionMax
	)
RETURN 0

GO
/****** Object:  Table [dbo].[C_Preguntas Cuestionario]    Script Date: 21/05/2017 06:27:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[C_Preguntas Cuestionario](
	[Corporativo] [bigint] NOT NULL,
	[Hotel] [nvarchar](10) NOT NULL,
	[Tipo Cuestionario] [nvarchar](5) NOT NULL,
	[No Pregunta] [int] NOT NULL,
	[Tipo Pregunta] [nvarchar](5) NOT NULL,
	[Pregunta] [nvarchar](150) NOT NULL,
	[Pregunta Ingles] [nvarchar](150) NOT NULL,
	[Calificacion Maxima] [int] NOT NULL,
 CONSTRAINT [PK_C_Preguntas Cuestionario] PRIMARY KEY CLUSTERED 
(
	[Corporativo] ASC,
	[Hotel] ASC,
	[Tipo Cuestionario] ASC,
	[No Pregunta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[C_Respuestas Cuestionario]    Script Date: 21/05/2017 06:27:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[C_Respuestas Cuestionario](
	[Corporativo] [bigint] NOT NULL,
	[Hotel] [nvarchar](10) NOT NULL,
	[Tipo Cuestionario] [nvarchar](5) NOT NULL,
	[No Pregunta] [int] NOT NULL,
	[No Respuesta] [int] NOT NULL,
	[Respuesta] [nvarchar](100) NOT NULL,
	[Respuesta Ingles] [nvarchar](100) NOT NULL,
	[Respuesta Abierta] [bit] NOT NULL,
 CONSTRAINT [PK_C_Respuestas Cuestionario] PRIMARY KEY CLUSTERED 
(
	[Corporativo] ASC,
	[Hotel] ASC,
	[Tipo Cuestionario] ASC,
	[No Pregunta] ASC,
	[No Respuesta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[C_Tipos Cuestionario]    Script Date: 21/05/2017 06:27:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[C_Tipos Cuestionario](
	[Corporativo] [bigint] NOT NULL,
	[Hotel] [nvarchar](10) NOT NULL,
	[Tipo Cuestionario] [nvarchar](5) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[Descripcion Ingles] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_C_Tipos Cuestionario] PRIMARY KEY CLUSTERED 
(
	[Corporativo] ASC,
	[Hotel] ASC,
	[Tipo Cuestionario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[C_Tipos Pregunta Cuestionario]    Script Date: 21/05/2017 06:27:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[C_Tipos Pregunta Cuestionario](
	[Corporativo] [bigint] NOT NULL,
	[Hotel] [nvarchar](10) NOT NULL,
	[Tipo Pregunta] [nvarchar](5) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[Descripcion Ingles] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_C_Tipos Pregunta Cuestionario] PRIMARY KEY CLUSTERED 
(
	[Corporativo] ASC,
	[Hotel] ASC,
	[Tipo Pregunta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[O_Estancias]    Script Date: 21/05/2017 06:27:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[O_Estancias](
	[Corporativo] [bigint] NOT NULL,
	[Hotel] [nvarchar](10) NOT NULL,
	[Id] [nvarchar](20) NOT NULL,
	[Linea] [bigint] NOT NULL,
	[Habitacion] [nvarchar](20) NOT NULL,
	[Cuartos] [int] NOT NULL,
	[Llegada] [date] NULL,
	[Noches] [bigint] NOT NULL,
	[Salida] [date] NULL,
	[Adultos] [int] NOT NULL,
	[Ninos] [int] NOT NULL,
	[Juniors] [int] NOT NULL,
	[Llegada Original] [date] NULL,
	[Salida Original] [date] NULL,
	[Hora Entrada] [time](0) NULL,
	[Hora Salida] [time](0) NULL,
	[Up/Down Grade] [nvarchar](10) NOT NULL,
	[Codigo Tarifa] [nvarchar](10) NOT NULL,
	[Tarifa] [numeric](18, 2) NOT NULL,
	[Divisa] [nvarchar](5) NOT NULL,
	[Tipo Tarifa] [nvarchar](1) NOT NULL,
 CONSTRAINT [PK_O_Estancias] PRIMARY KEY CLUSTERED 
(
	[Corporativo] ASC,
	[Hotel] ASC,
	[Id] ASC,
	[Linea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[O_Huespedes]    Script Date: 21/05/2017 06:28:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[O_Huespedes](
	[Corporativo] [bigint] NOT NULL,
	[Hotel] [nvarchar](10) NOT NULL,
	[Id] [nvarchar](20) NOT NULL,
	[Perfil Id] [bigint] NOT NULL,
	[Tipo Reservacion] [nvarchar](3) NOT NULL,
	[Titulo] [nvarchar](5) NOT NULL,
	[Apellido] [nvarchar](60) NOT NULL,
	[Apellido 2] [nvarchar](60) NOT NULL,
	[Nombre] [nvarchar](60) NOT NULL,
	[Nombre 2] [nvarchar](60) NOT NULL,
	[Pais] [nvarchar](3) NOT NULL,
	[Ciudad] [nvarchar](3) NOT NULL,
	[Idioma] [nvarchar](2) NOT NULL,
	[Direccion] [nvarchar](250) NOT NULL,
	[Contacto] [nvarchar](100) NOT NULL,
	[Telefono] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[S Mercado] [nvarchar](5) NOT NULL,
	[S Venta] [nvarchar](5) NOT NULL,
	[Origen] [nvarchar](5) NOT NULL,
	[Medio] [nvarchar](5) NOT NULL,
	[Grupo] [nvarchar](10) NOT NULL,
	[Agencia] [nvarchar](10) NOT NULL,
	[Cupon] [nvarchar](20) NOT NULL,
	[Empresa] [nvarchar](10) NOT NULL,
	[Vip] [int] NOT NULL,
	[Fecha Rva] [date] NULL,
	[Usuario Captura] [nvarchar](50) NOT NULL,
	[Fecha Captura] [date] NULL,
	[Usuario Cancela] [nvarchar](50) NOT NULL,
	[Fecha Cancela] [date] NULL,
	[Id Maestro] [nvarchar](20) NOT NULL,
	[Forma de Pago] [nvarchar](5) NOT NULL,
	[Numero Tarjeta] [nvarchar](16) NOT NULL,
	[Nombre Tarjeta] [nvarchar](100) NOT NULL,
	[Expira Tarjeta] [nvarchar](5) NOT NULL,
	[Detalle Tarjeta] [nvarchar](250) NOT NULL,
	[Estatus] [nvarchar](2) NOT NULL,
 CONSTRAINT [PK_O_Huespedes] PRIMARY KEY CLUSTERED 
(
	[Corporativo] ASC,
	[Hotel] ASC,
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[O_Respuestas Cuestionario Huespedes]    Script Date: 21/05/2017 06:28:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[O_Respuestas Cuestionario Huespedes](
	[Corporativo] [bigint] NOT NULL,
	[Hotel] [nvarchar](10) NOT NULL,
	[Tipo Cuestionario] [nvarchar](5) NOT NULL,
	[No Pregunta] [int] NOT NULL,
	[Id] [nvarchar](20) NOT NULL,
	[No Respuesta] [int] NOT NULL,
	[Calificacion] [int] NOT NULL,
	[Texto] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_O_Respuestas Cuestionario Huespedes] PRIMARY KEY CLUSTERED 
(
	[Corporativo] ASC,
	[Hotel] ASC,
	[Tipo Cuestionario] ASC,
	[No Pregunta] ASC,
	[Id] ASC,
	[No Respuesta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[S_Configuracion Cuestionario]    Script Date: 21/05/2017 06:28:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[S_Configuracion Cuestionario](
	[Corporativo] [bigint] NOT NULL,
	[Hotel] [nvarchar](10) NOT NULL,
	[Tipo Cuestionario] [nvarchar](5) NOT NULL,
	[Email Saliente] [nvarchar](100) NOT NULL,
	[Servidor SMTP] [nvarchar](70) NOT NULL,
	[Usuario SMTP] [nvarchar](50) NOT NULL,
	[Contrasena SMTP] [nvarchar](50) NOT NULL,
	[Puerto SMTP] [bigint] NOT NULL,
	[Texto Superior] [nvarchar](500) NOT NULL,
	[Texto Superior Ingles] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_S_Configuracion Cuestionario] PRIMARY KEY CLUSTERED 
(
	[Corporativo] ASC,
	[Hotel] ASC,
	[Tipo Cuestionario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[S_Corporativos]    Script Date: 21/05/2017 06:28:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[S_Corporativos](
	[Corporativo] [bigint] NOT NULL,
	[Nombre Corporativo] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_S_Corporativos] PRIMARY KEY CLUSTERED 
(
	[Corporativo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[S_Correos Cuestionario]    Script Date: 21/05/2017 06:28:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[S_Correos Cuestionario](
	[Corporativo] [bigint] NOT NULL,
	[Hotel] [nvarchar](10) NOT NULL,
	[Tipo Cuestionario] [nvarchar](5) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](70) NOT NULL,
 CONSTRAINT [PK_S_Correos Cuestionario] PRIMARY KEY CLUSTERED 
(
	[Corporativo] ASC,
	[Hotel] ASC,
	[Tipo Cuestionario] ASC,
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[S_Hoteles]    Script Date: 21/05/2017 06:28:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[S_Hoteles](
	[Corporativo] [bigint] NOT NULL,
	[Hotel] [nvarchar](10) NOT NULL,
	[Nombre Hotel] [nvarchar](150) NOT NULL,
	[RFC] [nvarchar](20) NOT NULL,
	[Direccion] [nvarchar](150) NOT NULL,
	[Fecha] [date] NULL,
	[Licencia] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_S_Hoteles] PRIMARY KEY CLUSTERED 
(
	[Corporativo] ASC,
	[Hotel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[Consulta_Huesped]    Script Date: 21/05/2017 06:28:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[Consulta_Huesped]
AS
SELECT      O_Estancias.Corporativo, O_Estancias.Hotel, O_Estancias.Id, O_Estancias.Linea, O_Estancias.Habitacion, O_Estancias.Llegada, O_Estancias.Noches, O_Estancias.Salida, 
 (O_Huespedes.Titulo + ' ' + O_Huespedes.Apellido + ' ' + O_Huespedes.[Apellido 2] + ', ' + O_Huespedes.Nombre + ' ' + O_Huespedes.[Nombre 2]) as Nombre, O_Huespedes.Email
FROM            O_Estancias INNER JOIN
                         O_Huespedes ON O_Estancias.Corporativo = O_Huespedes.Corporativo



GO
ALTER TABLE [dbo].[C_Preguntas Cuestionario] ADD  CONSTRAINT [DF_C_Preguntas Cuestionario_Corporativo]  DEFAULT ((1)) FOR [Corporativo]
GO
ALTER TABLE [dbo].[C_Preguntas Cuestionario] ADD  CONSTRAINT [DF_C_Preguntas Cuestionario_Hotel]  DEFAULT ('') FOR [Hotel]
GO
ALTER TABLE [dbo].[C_Preguntas Cuestionario] ADD  CONSTRAINT [DF_C_Preguntas Cuestionario_Tipo Cuestionario]  DEFAULT ('') FOR [Tipo Cuestionario]
GO
ALTER TABLE [dbo].[C_Preguntas Cuestionario] ADD  CONSTRAINT [DF_C_Preguntas Cuestionario_No Pregunta]  DEFAULT ((1)) FOR [No Pregunta]
GO
ALTER TABLE [dbo].[C_Preguntas Cuestionario] ADD  CONSTRAINT [DF_C_Preguntas Cuestionario_Tipo Pregunta]  DEFAULT ('') FOR [Tipo Pregunta]
GO
ALTER TABLE [dbo].[C_Preguntas Cuestionario] ADD  CONSTRAINT [DF_C_Preguntas Cuestionario_Pregunta]  DEFAULT ('') FOR [Pregunta]
GO
ALTER TABLE [dbo].[C_Preguntas Cuestionario] ADD  CONSTRAINT [DF_C_Preguntas Cuestionario_Pregunta Ingles]  DEFAULT ('') FOR [Pregunta Ingles]
GO
ALTER TABLE [dbo].[C_Preguntas Cuestionario] ADD  CONSTRAINT [DF_C_Preguntas Cuestionario_Calificacion Maxima]  DEFAULT ((5)) FOR [Calificacion Maxima]
GO
ALTER TABLE [dbo].[C_Respuestas Cuestionario] ADD  CONSTRAINT [DF_C_Respuestas Cuestionario_Corporativo]  DEFAULT ((1)) FOR [Corporativo]
GO
ALTER TABLE [dbo].[C_Respuestas Cuestionario] ADD  CONSTRAINT [DF_C_Respuestas Cuestionario_Hotel]  DEFAULT ('') FOR [Hotel]
GO
ALTER TABLE [dbo].[C_Respuestas Cuestionario] ADD  CONSTRAINT [DF_C_Respuestas Cuestionario_Tipo Cuestionario]  DEFAULT ('') FOR [Tipo Cuestionario]
GO
ALTER TABLE [dbo].[C_Respuestas Cuestionario] ADD  CONSTRAINT [DF_C_Respuestas Cuestionario_No Pregunta]  DEFAULT ((1)) FOR [No Pregunta]
GO
ALTER TABLE [dbo].[C_Respuestas Cuestionario] ADD  CONSTRAINT [DF_C_Respuestas Cuestionario_No Respuesta]  DEFAULT ((1)) FOR [No Respuesta]
GO
ALTER TABLE [dbo].[C_Respuestas Cuestionario] ADD  CONSTRAINT [DF_C_Respuestas Cuestionario_Respuesta]  DEFAULT ('') FOR [Respuesta]
GO
ALTER TABLE [dbo].[C_Respuestas Cuestionario] ADD  CONSTRAINT [DF_C_Respuestas Cuestionario_Respuesta Ingles]  DEFAULT ('') FOR [Respuesta Ingles]
GO
ALTER TABLE [dbo].[C_Respuestas Cuestionario] ADD  CONSTRAINT [DF_C_Respuestas Cuestionario_Respuesta Abierta]  DEFAULT ((0)) FOR [Respuesta Abierta]
GO
ALTER TABLE [dbo].[C_Tipos Cuestionario] ADD  CONSTRAINT [DF_C_Tipos Cuestionario_Corporativo]  DEFAULT ((1)) FOR [Corporativo]
GO
ALTER TABLE [dbo].[C_Tipos Cuestionario] ADD  CONSTRAINT [DF_C_Tipos Cuestionario_Hotel]  DEFAULT ('') FOR [Hotel]
GO
ALTER TABLE [dbo].[C_Tipos Cuestionario] ADD  CONSTRAINT [DF_C_Tipos Cuestionario_Tipo Cuestionario]  DEFAULT ('') FOR [Tipo Cuestionario]
GO
ALTER TABLE [dbo].[C_Tipos Cuestionario] ADD  CONSTRAINT [DF_C_Tipos Cuestionario_Descripcion]  DEFAULT ('') FOR [Descripcion]
GO
ALTER TABLE [dbo].[C_Tipos Cuestionario] ADD  CONSTRAINT [DF_C_Tipos Cuestionario_Descripcion Ingles]  DEFAULT ('') FOR [Descripcion Ingles]
GO
ALTER TABLE [dbo].[C_Tipos Pregunta Cuestionario] ADD  CONSTRAINT [DF_C_Tipos Pregunta Cuestionario_Corporativo]  DEFAULT ((1)) FOR [Corporativo]
GO
ALTER TABLE [dbo].[C_Tipos Pregunta Cuestionario] ADD  CONSTRAINT [DF_C_Tipos Pregunta Cuestionario_Hotel]  DEFAULT ('') FOR [Hotel]
GO
ALTER TABLE [dbo].[C_Tipos Pregunta Cuestionario] ADD  CONSTRAINT [DF_C_Tipos Pregunta Cuestionario_Tipo Pregunta]  DEFAULT ('') FOR [Tipo Pregunta]
GO
ALTER TABLE [dbo].[C_Tipos Pregunta Cuestionario] ADD  CONSTRAINT [DF_C_Tipos Pregunta Cuestionario_Descripcion]  DEFAULT ('') FOR [Descripcion]
GO
ALTER TABLE [dbo].[C_Tipos Pregunta Cuestionario] ADD  CONSTRAINT [DF_C_Tipos Pregunta Cuestionario_Descripcion Ingles]  DEFAULT ('') FOR [Descripcion Ingles]
GO
ALTER TABLE [dbo].[O_Estancias] ADD  CONSTRAINT [DF_O_Estancias_Corporativo]  DEFAULT ((1)) FOR [Corporativo]
GO
ALTER TABLE [dbo].[O_Estancias] ADD  CONSTRAINT [DF_O_Estancias_Hotel]  DEFAULT ('') FOR [Hotel]
GO
ALTER TABLE [dbo].[O_Estancias] ADD  CONSTRAINT [DF_O_Estancias_Id]  DEFAULT ('') FOR [Id]
GO
ALTER TABLE [dbo].[O_Estancias] ADD  CONSTRAINT [DF_O_Estancias_Linea]  DEFAULT ((0)) FOR [Linea]
GO
ALTER TABLE [dbo].[O_Estancias] ADD  CONSTRAINT [DF_O_Estancias_Habitacion]  DEFAULT ('') FOR [Habitacion]
GO
ALTER TABLE [dbo].[O_Estancias] ADD  CONSTRAINT [DF_O_Estancias_Cuartos]  DEFAULT ((1)) FOR [Cuartos]
GO
ALTER TABLE [dbo].[O_Estancias] ADD  CONSTRAINT [DF_O_Estancias_Noches]  DEFAULT ((1)) FOR [Noches]
GO
ALTER TABLE [dbo].[O_Estancias] ADD  CONSTRAINT [DF_O_Estancias_Adultos]  DEFAULT ((1)) FOR [Adultos]
GO
ALTER TABLE [dbo].[O_Estancias] ADD  CONSTRAINT [DF_O_Estancias_Ninos]  DEFAULT ((0)) FOR [Ninos]
GO
ALTER TABLE [dbo].[O_Estancias] ADD  CONSTRAINT [DF_O_Estancias_Juniors]  DEFAULT ((0)) FOR [Juniors]
GO
ALTER TABLE [dbo].[O_Estancias] ADD  CONSTRAINT [DF_O_Estancias_Up/Down Grade]  DEFAULT ('') FOR [Up/Down Grade]
GO
ALTER TABLE [dbo].[O_Estancias] ADD  CONSTRAINT [DF_O_Estancias_Codigo Tarifa]  DEFAULT ('') FOR [Codigo Tarifa]
GO
ALTER TABLE [dbo].[O_Estancias] ADD  CONSTRAINT [DF_O_Estancias_Tarifa]  DEFAULT ((0)) FOR [Tarifa]
GO
ALTER TABLE [dbo].[O_Estancias] ADD  CONSTRAINT [DF_O_Estancias_Divisa]  DEFAULT ('MXN') FOR [Divisa]
GO
ALTER TABLE [dbo].[O_Estancias] ADD  CONSTRAINT [DF_O_Estancias_Tipo Tarifa]  DEFAULT ('') FOR [Tipo Tarifa]
GO
ALTER TABLE [dbo].[O_Huespedes] ADD  CONSTRAINT [DF_O_Huespedes_Corporativo]  DEFAULT ((1)) FOR [Corporativo]
GO
ALTER TABLE [dbo].[O_Huespedes] ADD  CONSTRAINT [DF_O_Huespedes_Hotel]  DEFAULT ('') FOR [Hotel]
GO
ALTER TABLE [dbo].[O_Huespedes] ADD  CONSTRAINT [DF_O_Huespedes_Id]  DEFAULT ('') FOR [Id]
GO
ALTER TABLE [dbo].[O_Huespedes] ADD  CONSTRAINT [DF_O_Huespedes_Perfil Id]  DEFAULT ((0)) FOR [Perfil Id]
GO
ALTER TABLE [dbo].[O_Huespedes] ADD  CONSTRAINT [DF_O_Huespedes_Tipo Reservacion]  DEFAULT ('') FOR [Tipo Reservacion]
GO
ALTER TABLE [dbo].[O_Huespedes] ADD  CONSTRAINT [DF_O_Huespedes_Titulo]  DEFAULT ('') FOR [Titulo]
GO
ALTER TABLE [dbo].[O_Huespedes] ADD  CONSTRAINT [DF_O_Huespedes_Apellido]  DEFAULT ('') FOR [Apellido]
GO
ALTER TABLE [dbo].[O_Huespedes] ADD  CONSTRAINT [DF_O_Huespedes_Apellido 2]  DEFAULT ('') FOR [Apellido 2]
GO
ALTER TABLE [dbo].[O_Huespedes] ADD  CONSTRAINT [DF_O_Huespedes_Nombre]  DEFAULT ('') FOR [Nombre]
GO
ALTER TABLE [dbo].[O_Huespedes] ADD  CONSTRAINT [DF_O_Huespedes_Nombre 2]  DEFAULT ('') FOR [Nombre 2]
GO
ALTER TABLE [dbo].[O_Huespedes] ADD  CONSTRAINT [DF_O_Huespedes_Pais]  DEFAULT ('') FOR [Pais]
GO
ALTER TABLE [dbo].[O_Huespedes] ADD  CONSTRAINT [DF_O_Huespedes_Ciudad]  DEFAULT ('') FOR [Ciudad]
GO
ALTER TABLE [dbo].[O_Huespedes] ADD  CONSTRAINT [DF_O_Huespedes_Idioma]  DEFAULT ('') FOR [Idioma]
GO
ALTER TABLE [dbo].[O_Huespedes] ADD  CONSTRAINT [DF_O_Huespedes_Direccion]  DEFAULT ('') FOR [Direccion]
GO
ALTER TABLE [dbo].[O_Huespedes] ADD  CONSTRAINT [DF_O_Huespedes_Contacto]  DEFAULT ('') FOR [Contacto]
GO
ALTER TABLE [dbo].[O_Huespedes] ADD  CONSTRAINT [DF_O_Huespedes_Telefono]  DEFAULT ('') FOR [Telefono]
GO
ALTER TABLE [dbo].[O_Huespedes] ADD  CONSTRAINT [DF_O_Huespedes_Email]  DEFAULT ('') FOR [Email]
GO
ALTER TABLE [dbo].[O_Huespedes] ADD  CONSTRAINT [DF_O_Huespedes_S Mercado]  DEFAULT ('') FOR [S Mercado]
GO
ALTER TABLE [dbo].[O_Huespedes] ADD  CONSTRAINT [DF_O_Huespedes_S Venta]  DEFAULT ('') FOR [S Venta]
GO
ALTER TABLE [dbo].[O_Huespedes] ADD  CONSTRAINT [DF_O_Huespedes_Origen]  DEFAULT ('') FOR [Origen]
GO
ALTER TABLE [dbo].[O_Huespedes] ADD  CONSTRAINT [DF_O_Huespedes_Medio]  DEFAULT ('') FOR [Medio]
GO
ALTER TABLE [dbo].[O_Huespedes] ADD  CONSTRAINT [DF_O_Huespedes_Grupo]  DEFAULT ('') FOR [Grupo]
GO
ALTER TABLE [dbo].[O_Huespedes] ADD  CONSTRAINT [DF_O_Huespedes_Agencia]  DEFAULT ('') FOR [Agencia]
GO
ALTER TABLE [dbo].[O_Huespedes] ADD  CONSTRAINT [DF_O_Huespedes_Cupon]  DEFAULT ('') FOR [Cupon]
GO
ALTER TABLE [dbo].[O_Huespedes] ADD  CONSTRAINT [DF_O_Huespedes_Empresa]  DEFAULT ('') FOR [Empresa]
GO
ALTER TABLE [dbo].[O_Huespedes] ADD  CONSTRAINT [DF_O_Huespedes_VIP]  DEFAULT ((0)) FOR [Vip]
GO
ALTER TABLE [dbo].[O_Huespedes] ADD  CONSTRAINT [DF_O_Huespedes_Usuario Capturo]  DEFAULT ('') FOR [Usuario Captura]
GO
ALTER TABLE [dbo].[O_Huespedes] ADD  CONSTRAINT [DF_O_Huespedes_Usuario Cancela]  DEFAULT ('') FOR [Usuario Cancela]
GO
ALTER TABLE [dbo].[O_Huespedes] ADD  CONSTRAINT [DF_O_Huespedes_Id Maestro]  DEFAULT ('') FOR [Id Maestro]
GO
ALTER TABLE [dbo].[O_Huespedes] ADD  CONSTRAINT [DF_O_Huespedes_Codigo Pago]  DEFAULT ('') FOR [Forma de Pago]
GO
ALTER TABLE [dbo].[O_Huespedes] ADD  CONSTRAINT [DF_O_Huespedes_Numero Tarjeta]  DEFAULT ('') FOR [Numero Tarjeta]
GO
ALTER TABLE [dbo].[O_Huespedes] ADD  CONSTRAINT [DF_O_Huespedes_Nombre Tarjeta]  DEFAULT ('') FOR [Nombre Tarjeta]
GO
ALTER TABLE [dbo].[O_Huespedes] ADD  CONSTRAINT [DF_O_Huespedes_Expira Tarjeta]  DEFAULT ('') FOR [Expira Tarjeta]
GO
ALTER TABLE [dbo].[O_Huespedes] ADD  CONSTRAINT [DF_O_Huespedes_Detalle Tarjeta]  DEFAULT ('') FOR [Detalle Tarjeta]
GO
ALTER TABLE [dbo].[O_Huespedes] ADD  CONSTRAINT [DF_O_Huespedes_Estatus]  DEFAULT ('') FOR [Estatus]
GO
ALTER TABLE [dbo].[O_Respuestas Cuestionario Huespedes] ADD  CONSTRAINT [DF_O_Respuestas Cuestionario Huespedes_Corporativo]  DEFAULT ((1)) FOR [Corporativo]
GO
ALTER TABLE [dbo].[O_Respuestas Cuestionario Huespedes] ADD  CONSTRAINT [DF_O_Respuestas Cuestionario Huespedes_Hotel]  DEFAULT ('') FOR [Hotel]
GO
ALTER TABLE [dbo].[O_Respuestas Cuestionario Huespedes] ADD  CONSTRAINT [DF_O_Respuestas Cuestionario Huespedes_Tipo Cuestionario]  DEFAULT ('') FOR [Tipo Cuestionario]
GO
ALTER TABLE [dbo].[O_Respuestas Cuestionario Huespedes] ADD  CONSTRAINT [DF_O_Respuestas Cuestionario Huespedes_No Pregunta]  DEFAULT ((1)) FOR [No Pregunta]
GO
ALTER TABLE [dbo].[O_Respuestas Cuestionario Huespedes] ADD  CONSTRAINT [DF_O_Respuestas Cuestionario Huespedes_Id]  DEFAULT ('') FOR [Id]
GO
ALTER TABLE [dbo].[O_Respuestas Cuestionario Huespedes] ADD  CONSTRAINT [DF_O_Respuestas Cuestionario Huespedes_No Respuesta]  DEFAULT ((1)) FOR [No Respuesta]
GO
ALTER TABLE [dbo].[O_Respuestas Cuestionario Huespedes] ADD  CONSTRAINT [DF_O_Respuestas Cuestionario Huespedes_Calificacion]  DEFAULT ((0)) FOR [Calificacion]
GO
ALTER TABLE [dbo].[O_Respuestas Cuestionario Huespedes] ADD  CONSTRAINT [DF_O_Respuestas Cuestionario Huespedes_Texto]  DEFAULT ('') FOR [Texto]
GO
ALTER TABLE [dbo].[S_Configuracion Cuestionario] ADD  CONSTRAINT [DF_S_Configuracion Cuestionario_Corporativo]  DEFAULT ((1)) FOR [Corporativo]
GO
ALTER TABLE [dbo].[S_Configuracion Cuestionario] ADD  CONSTRAINT [DF_S_Configuracion Cuestionario_Hotel]  DEFAULT ('') FOR [Hotel]
GO
ALTER TABLE [dbo].[S_Configuracion Cuestionario] ADD  CONSTRAINT [DF_S_Configuracion Cuestionario_Tipo Cuestionario]  DEFAULT ('') FOR [Tipo Cuestionario]
GO
ALTER TABLE [dbo].[S_Configuracion Cuestionario] ADD  CONSTRAINT [DF_S_Configuracion Cuestionario_Email Saliente]  DEFAULT ('') FOR [Email Saliente]
GO
ALTER TABLE [dbo].[S_Configuracion Cuestionario] ADD  CONSTRAINT [DF_S_Configuracion Cuestionario_Servidor SMTP]  DEFAULT ('') FOR [Servidor SMTP]
GO
ALTER TABLE [dbo].[S_Configuracion Cuestionario] ADD  CONSTRAINT [DF_S_Configuracion Cuestionario_Usuario SMTP]  DEFAULT ('') FOR [Usuario SMTP]
GO
ALTER TABLE [dbo].[S_Configuracion Cuestionario] ADD  CONSTRAINT [DF_S_Configuracion Cuestionario_Contrasena SMTP]  DEFAULT ('') FOR [Contrasena SMTP]
GO
ALTER TABLE [dbo].[S_Configuracion Cuestionario] ADD  CONSTRAINT [DF_S_Configuracion Cuestionario_Puerto SMTP]  DEFAULT ((25)) FOR [Puerto SMTP]
GO
ALTER TABLE [dbo].[S_Configuracion Cuestionario] ADD  CONSTRAINT [DF_S_Configuracion Cuestionario_Texto Superior]  DEFAULT ('') FOR [Texto Superior]
GO
ALTER TABLE [dbo].[S_Configuracion Cuestionario] ADD  CONSTRAINT [DF_S_Configuracion Cuestionario_Texto Superior Ingles]  DEFAULT ('') FOR [Texto Superior Ingles]
GO
ALTER TABLE [dbo].[S_Corporativos] ADD  CONSTRAINT [DF_S_Corporativos_Corporativo]  DEFAULT ((1)) FOR [Corporativo]
GO
ALTER TABLE [dbo].[S_Corporativos] ADD  CONSTRAINT [DF_S_Corporativos_Nombre Corporativo]  DEFAULT ('') FOR [Nombre Corporativo]
GO
ALTER TABLE [dbo].[S_Correos Cuestionario] ADD  CONSTRAINT [DF_S_Correos Cuestionario_Corporativo]  DEFAULT ((1)) FOR [Corporativo]
GO
ALTER TABLE [dbo].[S_Correos Cuestionario] ADD  CONSTRAINT [DF_S_Correos Cuestionario_Hotel]  DEFAULT ('') FOR [Hotel]
GO
ALTER TABLE [dbo].[S_Correos Cuestionario] ADD  CONSTRAINT [DF_S_Correos Cuestionario_Tipo Cuestionario]  DEFAULT ('') FOR [Tipo Cuestionario]
GO
ALTER TABLE [dbo].[S_Correos Cuestionario] ADD  CONSTRAINT [DF_S_Correos Cuestionario_Email]  DEFAULT ('') FOR [Email]
GO
ALTER TABLE [dbo].[S_Correos Cuestionario] ADD  CONSTRAINT [DF_S_Correos Cuestionario_Descripcion]  DEFAULT ('') FOR [Descripcion]
GO
ALTER TABLE [dbo].[S_Hoteles] ADD  CONSTRAINT [DF_S_Hoteles_Corporativo]  DEFAULT ((1)) FOR [Corporativo]
GO
ALTER TABLE [dbo].[S_Hoteles] ADD  CONSTRAINT [DF_S_Hoteles_Hotel]  DEFAULT ('') FOR [Hotel]
GO
ALTER TABLE [dbo].[S_Hoteles] ADD  CONSTRAINT [DF_S_Hoteles_Nombre Hotel]  DEFAULT ('') FOR [Nombre Hotel]
GO
ALTER TABLE [dbo].[S_Hoteles] ADD  CONSTRAINT [DF_S_Hoteles_RFC]  DEFAULT ('') FOR [RFC]
GO
ALTER TABLE [dbo].[S_Hoteles] ADD  CONSTRAINT [DF_S_Hoteles_Direccion]  DEFAULT ('') FOR [Direccion]
GO
ALTER TABLE [dbo].[S_Hoteles] ADD  CONSTRAINT [DF_S_Hoteles_Licencia]  DEFAULT ('') FOR [Licencia]
GO
ALTER TABLE [dbo].[C_Preguntas Cuestionario]  WITH CHECK ADD  CONSTRAINT [FK_C_Preguntas Cuestionario_C_Tipos Cuestionario] FOREIGN KEY([Corporativo], [Hotel], [Tipo Cuestionario])
REFERENCES [dbo].[C_Tipos Cuestionario] ([Corporativo], [Hotel], [Tipo Cuestionario])
GO
ALTER TABLE [dbo].[C_Preguntas Cuestionario] CHECK CONSTRAINT [FK_C_Preguntas Cuestionario_C_Tipos Cuestionario]
GO
ALTER TABLE [dbo].[C_Preguntas Cuestionario]  WITH CHECK ADD  CONSTRAINT [FK_C_Preguntas Cuestionario_C_Tipos Pregunta Cuestionario] FOREIGN KEY([Corporativo], [Hotel], [Tipo Pregunta])
REFERENCES [dbo].[C_Tipos Pregunta Cuestionario] ([Corporativo], [Hotel], [Tipo Pregunta])
GO
ALTER TABLE [dbo].[C_Preguntas Cuestionario] CHECK CONSTRAINT [FK_C_Preguntas Cuestionario_C_Tipos Pregunta Cuestionario]
GO
ALTER TABLE [dbo].[C_Preguntas Cuestionario]  WITH CHECK ADD  CONSTRAINT [FK_C_Preguntas Cuestionario_S_Hoteles] FOREIGN KEY([Corporativo], [Hotel])
REFERENCES [dbo].[S_Hoteles] ([Corporativo], [Hotel])
GO
ALTER TABLE [dbo].[C_Preguntas Cuestionario] CHECK CONSTRAINT [FK_C_Preguntas Cuestionario_S_Hoteles]
GO
ALTER TABLE [dbo].[C_Respuestas Cuestionario]  WITH CHECK ADD  CONSTRAINT [FK_C_Respuestas Cuestionario_C_Preguntas Cuestionario] FOREIGN KEY([Corporativo], [Hotel], [Tipo Cuestionario], [No Pregunta])
REFERENCES [dbo].[C_Preguntas Cuestionario] ([Corporativo], [Hotel], [Tipo Cuestionario], [No Pregunta])
GO
ALTER TABLE [dbo].[C_Respuestas Cuestionario] CHECK CONSTRAINT [FK_C_Respuestas Cuestionario_C_Preguntas Cuestionario]
GO
ALTER TABLE [dbo].[C_Respuestas Cuestionario]  WITH CHECK ADD  CONSTRAINT [FK_C_Respuestas Cuestionario_S_Hoteles] FOREIGN KEY([Corporativo], [Hotel])
REFERENCES [dbo].[S_Hoteles] ([Corporativo], [Hotel])
GO
ALTER TABLE [dbo].[C_Respuestas Cuestionario] CHECK CONSTRAINT [FK_C_Respuestas Cuestionario_S_Hoteles]
GO
ALTER TABLE [dbo].[C_Tipos Cuestionario]  WITH CHECK ADD  CONSTRAINT [FK_C_Tipos Cuestionario_S_Hoteles] FOREIGN KEY([Corporativo], [Hotel])
REFERENCES [dbo].[S_Hoteles] ([Corporativo], [Hotel])
GO
ALTER TABLE [dbo].[C_Tipos Cuestionario] CHECK CONSTRAINT [FK_C_Tipos Cuestionario_S_Hoteles]
GO
ALTER TABLE [dbo].[C_Tipos Pregunta Cuestionario]  WITH CHECK ADD  CONSTRAINT [FK_C_Tipos Pregunta Cuestionario_S_Hoteles] FOREIGN KEY([Corporativo], [Hotel])
REFERENCES [dbo].[S_Hoteles] ([Corporativo], [Hotel])
GO
ALTER TABLE [dbo].[C_Tipos Pregunta Cuestionario] CHECK CONSTRAINT [FK_C_Tipos Pregunta Cuestionario_S_Hoteles]
GO
ALTER TABLE [dbo].[O_Estancias]  WITH CHECK ADD  CONSTRAINT [FK_O_Estancias_O_Huespedes] FOREIGN KEY([Corporativo], [Hotel], [Id])
REFERENCES [dbo].[O_Huespedes] ([Corporativo], [Hotel], [Id])
GO
ALTER TABLE [dbo].[O_Estancias] CHECK CONSTRAINT [FK_O_Estancias_O_Huespedes]
GO
ALTER TABLE [dbo].[O_Estancias]  WITH CHECK ADD  CONSTRAINT [FK_O_Estancias_S_Hoteles] FOREIGN KEY([Corporativo], [Hotel])
REFERENCES [dbo].[S_Hoteles] ([Corporativo], [Hotel])
GO
ALTER TABLE [dbo].[O_Estancias] CHECK CONSTRAINT [FK_O_Estancias_S_Hoteles]
GO
ALTER TABLE [dbo].[O_Huespedes]  WITH CHECK ADD  CONSTRAINT [FK_O_Huespedes_S_Hoteles] FOREIGN KEY([Corporativo], [Hotel])
REFERENCES [dbo].[S_Hoteles] ([Corporativo], [Hotel])
GO
ALTER TABLE [dbo].[O_Huespedes] CHECK CONSTRAINT [FK_O_Huespedes_S_Hoteles]
GO
ALTER TABLE [dbo].[O_Respuestas Cuestionario Huespedes]  WITH CHECK ADD  CONSTRAINT [FK_O_Respuestas Cuestionario Huespedes_C_Respuestas Cuestionario] FOREIGN KEY([Corporativo], [Hotel], [Tipo Cuestionario], [No Pregunta], [No Respuesta])
REFERENCES [dbo].[C_Respuestas Cuestionario] ([Corporativo], [Hotel], [Tipo Cuestionario], [No Pregunta], [No Respuesta])
GO
ALTER TABLE [dbo].[O_Respuestas Cuestionario Huespedes] CHECK CONSTRAINT [FK_O_Respuestas Cuestionario Huespedes_C_Respuestas Cuestionario]
GO
ALTER TABLE [dbo].[O_Respuestas Cuestionario Huespedes]  WITH CHECK ADD  CONSTRAINT [FK_O_Respuestas Cuestionario Huespedes_O_Huespedes] FOREIGN KEY([Corporativo], [Hotel], [Id])
REFERENCES [dbo].[O_Huespedes] ([Corporativo], [Hotel], [Id])
GO
ALTER TABLE [dbo].[O_Respuestas Cuestionario Huespedes] CHECK CONSTRAINT [FK_O_Respuestas Cuestionario Huespedes_O_Huespedes]
GO
ALTER TABLE [dbo].[O_Respuestas Cuestionario Huespedes]  WITH CHECK ADD  CONSTRAINT [FK_O_Respuestas Cuestionario Huespedes_S_Hoteles] FOREIGN KEY([Corporativo], [Hotel])
REFERENCES [dbo].[S_Hoteles] ([Corporativo], [Hotel])
GO
ALTER TABLE [dbo].[O_Respuestas Cuestionario Huespedes] CHECK CONSTRAINT [FK_O_Respuestas Cuestionario Huespedes_S_Hoteles]
GO
ALTER TABLE [dbo].[S_Configuracion Cuestionario]  WITH CHECK ADD  CONSTRAINT [FK_S_Configuracion Cuestionario_C_Tipos Cuestionario] FOREIGN KEY([Corporativo], [Hotel], [Tipo Cuestionario])
REFERENCES [dbo].[C_Tipos Cuestionario] ([Corporativo], [Hotel], [Tipo Cuestionario])
GO
ALTER TABLE [dbo].[S_Configuracion Cuestionario] CHECK CONSTRAINT [FK_S_Configuracion Cuestionario_C_Tipos Cuestionario]
GO
ALTER TABLE [dbo].[S_Configuracion Cuestionario]  WITH CHECK ADD  CONSTRAINT [FK_S_Configuracion Cuestionario_S_Hoteles] FOREIGN KEY([Corporativo], [Hotel])
REFERENCES [dbo].[S_Hoteles] ([Corporativo], [Hotel])
GO
ALTER TABLE [dbo].[S_Configuracion Cuestionario] CHECK CONSTRAINT [FK_S_Configuracion Cuestionario_S_Hoteles]
GO
ALTER TABLE [dbo].[S_Correos Cuestionario]  WITH CHECK ADD  CONSTRAINT [FK_S_Correos Cuestionario_C_Tipos Cuestionario] FOREIGN KEY([Corporativo], [Hotel], [Tipo Cuestionario])
REFERENCES [dbo].[C_Tipos Cuestionario] ([Corporativo], [Hotel], [Tipo Cuestionario])
GO
ALTER TABLE [dbo].[S_Correos Cuestionario] CHECK CONSTRAINT [FK_S_Correos Cuestionario_C_Tipos Cuestionario]
GO
ALTER TABLE [dbo].[S_Correos Cuestionario]  WITH CHECK ADD  CONSTRAINT [FK_S_Correos Cuestionario_S_Hoteles] FOREIGN KEY([Corporativo], [Hotel])
REFERENCES [dbo].[S_Hoteles] ([Corporativo], [Hotel])
GO
ALTER TABLE [dbo].[S_Correos Cuestionario] CHECK CONSTRAINT [FK_S_Correos Cuestionario_S_Hoteles]
GO
ALTER TABLE [dbo].[S_Hoteles]  WITH CHECK ADD  CONSTRAINT [FK_S_Hoteles_S_Corporativos] FOREIGN KEY([Corporativo])
REFERENCES [dbo].[S_Corporativos] ([Corporativo])
GO
ALTER TABLE [dbo].[S_Hoteles] CHECK CONSTRAINT [FK_S_Hoteles_S_Corporativos]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "O_Estancias"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 247
            End
            DisplayFlags = 280
            TopColumn = 17
         End
         Begin Table = "O_Huespedes"
            Begin Extent = 
               Top = 6
               Left = 285
               Bottom = 136
               Right = 494
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Consulta_Huesped'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Consulta_Huesped'
GO
USE [master]
GO
ALTER DATABASE [cuestionario] SET  READ_WRITE 
GO
