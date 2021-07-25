USE [master]
GO
/****** Object:  Database [jornada-dotnet-db]    Script Date: 21/10/2021 10:08:13 ******/
CREATE DATABASE [jornada-dotnet-db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'jornada-dotnet-db', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\jornada-dotnet-db.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'jornada-dotnet-db_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\jornada-dotnet-db_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [jornada-dotnet-db] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [jornada-dotnet-db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [jornada-dotnet-db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [jornada-dotnet-db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [jornada-dotnet-db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [jornada-dotnet-db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [jornada-dotnet-db] SET ARITHABORT OFF 
GO
ALTER DATABASE [jornada-dotnet-db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [jornada-dotnet-db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [jornada-dotnet-db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [jornada-dotnet-db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [jornada-dotnet-db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [jornada-dotnet-db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [jornada-dotnet-db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [jornada-dotnet-db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [jornada-dotnet-db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [jornada-dotnet-db] SET  DISABLE_BROKER 
GO
ALTER DATABASE [jornada-dotnet-db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [jornada-dotnet-db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [jornada-dotnet-db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [jornada-dotnet-db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [jornada-dotnet-db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [jornada-dotnet-db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [jornada-dotnet-db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [jornada-dotnet-db] SET RECOVERY FULL 
GO
ALTER DATABASE [jornada-dotnet-db] SET  MULTI_USER 
GO
ALTER DATABASE [jornada-dotnet-db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [jornada-dotnet-db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [jornada-dotnet-db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [jornada-dotnet-db] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [jornada-dotnet-db] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'jornada-dotnet-db', N'ON'
GO
USE [jornada-dotnet-db]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 21/10/2021 10:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_Product]    Script Date: 21/10/2021 10:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[RegisteredAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_tb_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_ProductReviews]    Script Date: 21/10/2021 10:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_ProductReviews](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Author] [nvarchar](50) NOT NULL,
	[Rating] [int] NOT NULL,
	[Comments] [nvarchar](max) NULL,
	[RegisteredAt] [datetime2](7) NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_tb_ProductReviews] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211021114249_InitialMigration', N'5.0.11')
/****** Object:  Index [IX_tb_ProductReviews_ProductId]    Script Date: 21/10/2021 10:08:14 ******/
CREATE NONCLUSTERED INDEX [IX_tb_ProductReviews_ProductId] ON [dbo].[tb_ProductReviews]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tb_ProductReviews]  WITH CHECK ADD  CONSTRAINT [FK_tb_ProductReviews_tb_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[tb_Product] ([Id])
GO
ALTER TABLE [dbo].[tb_ProductReviews] CHECK CONSTRAINT [FK_tb_ProductReviews_tb_Product_ProductId]
GO
USE [master]
GO
ALTER DATABASE [jornada-dotnet-db] SET  READ_WRITE 
GO
