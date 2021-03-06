USE [master]
GO
/****** Object:  Database [JunShen.BudgetTracker]    Script Date: 3/7/2021 2:41:07 PM ******/
CREATE DATABASE [JunShen.BudgetTracker]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'JunShen.BudgetTracker', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\JunShen.BudgetTracker.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'JunShen.BudgetTracker_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\JunShen.BudgetTracker_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [JunShen.BudgetTracker] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [JunShen.BudgetTracker].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [JunShen.BudgetTracker] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [JunShen.BudgetTracker] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [JunShen.BudgetTracker] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [JunShen.BudgetTracker] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [JunShen.BudgetTracker] SET ARITHABORT OFF 
GO
ALTER DATABASE [JunShen.BudgetTracker] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [JunShen.BudgetTracker] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [JunShen.BudgetTracker] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [JunShen.BudgetTracker] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [JunShen.BudgetTracker] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [JunShen.BudgetTracker] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [JunShen.BudgetTracker] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [JunShen.BudgetTracker] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [JunShen.BudgetTracker] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [JunShen.BudgetTracker] SET  ENABLE_BROKER 
GO
ALTER DATABASE [JunShen.BudgetTracker] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [JunShen.BudgetTracker] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [JunShen.BudgetTracker] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [JunShen.BudgetTracker] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [JunShen.BudgetTracker] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [JunShen.BudgetTracker] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [JunShen.BudgetTracker] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [JunShen.BudgetTracker] SET RECOVERY FULL 
GO
ALTER DATABASE [JunShen.BudgetTracker] SET  MULTI_USER 
GO
ALTER DATABASE [JunShen.BudgetTracker] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [JunShen.BudgetTracker] SET DB_CHAINING OFF 
GO
ALTER DATABASE [JunShen.BudgetTracker] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [JunShen.BudgetTracker] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [JunShen.BudgetTracker] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [JunShen.BudgetTracker] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'JunShen.BudgetTracker', N'ON'
GO
ALTER DATABASE [JunShen.BudgetTracker] SET QUERY_STORE = OFF
GO
USE [JunShen.BudgetTracker]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/7/2021 2:41:08 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Expenditure]    Script Date: 3/7/2021 2:41:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Expenditure](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Description] [nvarchar](100) NULL,
	[ExpDate] [datetime2](7) NULL,
	[Remarks] [nvarchar](500) NULL,
 CONSTRAINT [PK_Expenditure] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Income]    Script Date: 3/7/2021 2:41:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Income](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Description] [nvarchar](100) NULL,
	[IncomeDate] [datetime2](7) NULL,
	[Remarks] [nvarchar](500) NULL,
 CONSTRAINT [PK_Income] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 3/7/2021 2:41:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [nvarchar](10) NULL,
	[Fullname] [nvarchar](50) NULL,
	[JoinedOn] [datetime2](7) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_Expenditure_UserId]    Script Date: 3/7/2021 2:41:08 PM ******/
CREATE NONCLUSTERED INDEX [IX_Expenditure_UserId] ON [dbo].[Expenditure]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Income_UserId]    Script Date: 3/7/2021 2:41:08 PM ******/
CREATE NONCLUSTERED INDEX [IX_Income_UserId] ON [dbo].[Income]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Expenditure] ADD  DEFAULT (getdate()) FOR [ExpDate]
GO
ALTER TABLE [dbo].[Income] ADD  DEFAULT (getdate()) FOR [IncomeDate]
GO
ALTER TABLE [dbo].[Expenditure]  WITH CHECK ADD  CONSTRAINT [FK_Expenditure_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Expenditure] CHECK CONSTRAINT [FK_Expenditure_User_UserId]
GO
ALTER TABLE [dbo].[Income]  WITH CHECK ADD  CONSTRAINT [FK_Income_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Income] CHECK CONSTRAINT [FK_Income_User_UserId]
GO
USE [master]
GO
ALTER DATABASE [JunShen.BudgetTracker] SET  READ_WRITE 
GO
