USE [master]
GO
/****** Object:  Database [vehiculos]    Script Date: 22/11/2020 23:57:37 ******/
CREATE DATABASE [vehiculos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'vehiculos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\vehiculos.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'vehiculos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\vehiculos_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [vehiculos] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [vehiculos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [vehiculos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [vehiculos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [vehiculos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [vehiculos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [vehiculos] SET ARITHABORT OFF 
GO
ALTER DATABASE [vehiculos] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [vehiculos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [vehiculos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [vehiculos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [vehiculos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [vehiculos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [vehiculos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [vehiculos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [vehiculos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [vehiculos] SET  DISABLE_BROKER 
GO
ALTER DATABASE [vehiculos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [vehiculos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [vehiculos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [vehiculos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [vehiculos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [vehiculos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [vehiculos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [vehiculos] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [vehiculos] SET  MULTI_USER 
GO
ALTER DATABASE [vehiculos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [vehiculos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [vehiculos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [vehiculos] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [vehiculos] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [vehiculos] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [vehiculos] SET QUERY_STORE = OFF
GO
USE [vehiculos]
GO
/****** Object:  Table [dbo].[vehiculos]    Script Date: 22/11/2020 23:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vehiculos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[marca] [varchar](50) NOT NULL,
	[precio] [float] NOT NULL,
	[patente] [varchar](50) NOT NULL,
	[tipo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_vehiculos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[vehiculos] ON 

INSERT [dbo].[vehiculos] ([id], [marca], [precio], [patente], [tipo]) VALUES (1, N'BMW', 635425.88, N'AB928OZ', N'Suv')
INSERT [dbo].[vehiculos] ([id], [marca], [precio], [patente], [tipo]) VALUES (2, N'Fiat', 963258.44, N'AC820MF', N'Auto')
INSERT [dbo].[vehiculos] ([id], [marca], [precio], [patente], [tipo]) VALUES (3, N'Kawasaki', 789654.25, N'AF827AF', N'Moto')
INSERT [dbo].[vehiculos] ([id], [marca], [precio], [patente], [tipo]) VALUES (4, N'Suzuki', 258963, N'AA780MA', N'Moto')
INSERT [dbo].[vehiculos] ([id], [marca], [precio], [patente], [tipo]) VALUES (5, N'Volkswagen', 785214, N'AB892NT', N'Auto')
INSERT [dbo].[vehiculos] ([id], [marca], [precio], [patente], [tipo]) VALUES (6, N'Ford', 998765.83, N'AC134PZ', N'Suv')
INSERT [dbo].[vehiculos] ([id], [marca], [precio], [patente], [tipo]) VALUES (7, N'Yamaha', 665221.875, N'AB987OA', N'Suv')
SET IDENTITY_INSERT [dbo].[vehiculos] OFF
GO
USE [master]
GO
ALTER DATABASE [vehiculos] SET  READ_WRITE 
GO
