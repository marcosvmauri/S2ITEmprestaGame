USE [master]
GO
/****** Object:  Database [EmprestaGame]    Script Date: 22/12/2017 02:23:50 ******/
CREATE DATABASE [EmprestaGame] ON  PRIMARY 
( NAME = N'EmprestaGame2', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\EmprestaGame2.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EmprestaGame2_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\EmprestaGame2_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [EmprestaGame] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmprestaGame].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EmprestaGame] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EmprestaGame] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EmprestaGame] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EmprestaGame] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EmprestaGame] SET ARITHABORT OFF 
GO
ALTER DATABASE [EmprestaGame] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EmprestaGame] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [EmprestaGame] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EmprestaGame] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EmprestaGame] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EmprestaGame] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EmprestaGame] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EmprestaGame] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EmprestaGame] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EmprestaGame] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EmprestaGame] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EmprestaGame] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EmprestaGame] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EmprestaGame] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EmprestaGame] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EmprestaGame] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EmprestaGame] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EmprestaGame] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EmprestaGame] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EmprestaGame] SET  MULTI_USER 
GO
ALTER DATABASE [EmprestaGame] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EmprestaGame] SET DB_CHAINING OFF 
GO
USE [EmprestaGame]
GO
/****** Object:  Table [dbo].[Emprestimo]    Script Date: 22/12/2017 02:23:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Emprestimo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[idJogo] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Emprestimo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Jogo]    Script Date: 22/12/2017 02:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Jogo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](250) NULL,
	[Console] [varchar](250) NULL,
	[idUsuario] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[Emprestimo_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Jogo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Token]    Script Date: 22/12/2017 02:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Token](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [varchar](50) NOT NULL,
	[Chave] [varchar](250) NOT NULL,
	[Validade] [datetime] NULL,
	[IP] [varchar](250) NULL,
 CONSTRAINT [PK_dbo.Token] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 22/12/2017 02:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Login] [varchar](50) NOT NULL,
	[Senha] [varchar](250) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Emprestimo]  WITH CHECK ADD  CONSTRAINT [FK_EMPRESTIMO_JOGO] FOREIGN KEY([idJogo])
REFERENCES [dbo].[Jogo] ([Id])
GO
ALTER TABLE [dbo].[Emprestimo] CHECK CONSTRAINT [FK_EMPRESTIMO_JOGO]
GO
ALTER TABLE [dbo].[Emprestimo]  WITH CHECK ADD  CONSTRAINT [FK_Emprestimo_USUARIO] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Emprestimo] CHECK CONSTRAINT [FK_Emprestimo_USUARIO]
GO
ALTER TABLE [dbo].[Jogo]  WITH CHECK ADD  CONSTRAINT [FK_JOGO_USUARIO] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Jogo] CHECK CONSTRAINT [FK_JOGO_USUARIO]
GO
USE [master]
GO
ALTER DATABASE [EmprestaGame] SET  READ_WRITE 
GO
