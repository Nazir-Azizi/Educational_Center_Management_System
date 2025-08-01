USE [master]
GO
/****** Object:  Database [Educational_Center_Management_System]    Script Date: 6/30/2025 11:39:41 AM ******/
CREATE DATABASE [Educational_Center_Management_System]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Educational_Center_Management_System', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Educational_Center_Management_System.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Educational_Center_Management_System_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Educational_Center_Management_System_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Educational_Center_Management_System] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Educational_Center_Management_System].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Educational_Center_Management_System] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Educational_Center_Management_System] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Educational_Center_Management_System] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Educational_Center_Management_System] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Educational_Center_Management_System] SET ARITHABORT OFF 
GO
ALTER DATABASE [Educational_Center_Management_System] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Educational_Center_Management_System] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Educational_Center_Management_System] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Educational_Center_Management_System] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Educational_Center_Management_System] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Educational_Center_Management_System] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Educational_Center_Management_System] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Educational_Center_Management_System] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Educational_Center_Management_System] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Educational_Center_Management_System] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Educational_Center_Management_System] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Educational_Center_Management_System] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Educational_Center_Management_System] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Educational_Center_Management_System] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Educational_Center_Management_System] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Educational_Center_Management_System] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Educational_Center_Management_System] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Educational_Center_Management_System] SET RECOVERY FULL 
GO
ALTER DATABASE [Educational_Center_Management_System] SET  MULTI_USER 
GO
ALTER DATABASE [Educational_Center_Management_System] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Educational_Center_Management_System] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Educational_Center_Management_System] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Educational_Center_Management_System] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Educational_Center_Management_System] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Educational_Center_Management_System', N'ON'
GO
ALTER DATABASE [Educational_Center_Management_System] SET QUERY_STORE = OFF
GO
USE [Educational_Center_Management_System]
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 6/30/2025 11:39:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classes](
	[class_id] [int] IDENTITY(1,1) NOT NULL,
	[class_state] [int] NOT NULL,
	[class_teacher] [int] NOT NULL,
	[class_semester] [varchar](5) NOT NULL,
	[class_name] [varchar](10) NOT NULL,
	[class_time] [time](0) NOT NULL,
	[class_date] [date] NOT NULL,
 CONSTRAINT [PK_Classes] PRIMARY KEY CLUSTERED 
(
	[class_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Managers]    Script Date: 6/30/2025 11:39:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Managers](
	[manager_id] [int] IDENTITY(1,1) NOT NULL,
	[manager_name] [varchar](20) NOT NULL,
	[manager_last_name] [varchar](20) NOT NULL,
	[manager_photo] [varbinary](max) NULL,
	[manager_password] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Managers] PRIMARY KEY CLUSTERED 
(
	[manager_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Scores]    Script Date: 6/30/2025 11:39:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Scores](
	[score_id] [int] IDENTITY(1,1) NOT NULL,
	[st_id] [int] NOT NULL,
	[class_id] [int] NOT NULL,
	[score] [decimal](4, 1) NOT NULL,
 CONSTRAINT [PK_Scores] PRIMARY KEY CLUSTERED 
(
	[score_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentClassRelationship]    Script Date: 6/30/2025 11:39:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentClassRelationship](
	[st_class_id] [int] IDENTITY(1,1) NOT NULL,
	[st_id] [int] NOT NULL,
	[class_id] [int] NOT NULL,
 CONSTRAINT [PK_StudentClassRelationship] PRIMARY KEY CLUSTERED 
(
	[st_class_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 6/30/2025 11:39:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[s_id] [int] IDENTITY(1,1) NOT NULL,
	[s_name] [varchar](20) NOT NULL,
	[s_last_name] [varchar](20) NOT NULL,
	[s_father_name] [varchar](20) NOT NULL,
	[s_date_of_birth] [date] NOT NULL,
	[s_photo] [varbinary](max) NULL,
	[s_phone_number] [varchar](15) NULL,
	[s_join_date] [date] NOT NULL,
	[s_state] [int] NOT NULL,
	[s_password] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[s_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 6/30/2025 11:39:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[t_id] [int] IDENTITY(1,1) NOT NULL,
	[t_name] [varchar](20) NOT NULL,
	[t_last_name] [varchar](20) NOT NULL,
	[t_father_name] [varchar](20) NOT NULL,
	[t_date_of_birth] [date] NOT NULL,
	[t_photo] [varbinary](max) NULL,
	[t_phone_number] [varchar](15) NOT NULL,
	[t_join_date] [date] NOT NULL,
	[t_leave_date] [date] NULL,
	[t_state] [int] NOT NULL,
	[t_password] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Teachers] PRIMARY KEY CLUSTERED 
(
	[t_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Classes_Teachers] FOREIGN KEY([class_teacher])
REFERENCES [dbo].[Teachers] ([t_id])
GO
ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [FK_Classes_Teachers]
GO
ALTER TABLE [dbo].[Scores]  WITH CHECK ADD  CONSTRAINT [FK_Scores_Classes] FOREIGN KEY([class_id])
REFERENCES [dbo].[Classes] ([class_id])
GO
ALTER TABLE [dbo].[Scores] CHECK CONSTRAINT [FK_Scores_Classes]
GO
ALTER TABLE [dbo].[Scores]  WITH CHECK ADD  CONSTRAINT [FK_Scores_Students] FOREIGN KEY([st_id])
REFERENCES [dbo].[Students] ([s_id])
GO
ALTER TABLE [dbo].[Scores] CHECK CONSTRAINT [FK_Scores_Students]
GO
ALTER TABLE [dbo].[StudentClassRelationship]  WITH CHECK ADD  CONSTRAINT [FK_StudentClassRelationship_Classes] FOREIGN KEY([class_id])
REFERENCES [dbo].[Classes] ([class_id])
GO
ALTER TABLE [dbo].[StudentClassRelationship] CHECK CONSTRAINT [FK_StudentClassRelationship_Classes]
GO
ALTER TABLE [dbo].[StudentClassRelationship]  WITH CHECK ADD  CONSTRAINT [FK_StudentClassRelationship_Students] FOREIGN KEY([st_id])
REFERENCES [dbo].[Students] ([s_id])
GO
ALTER TABLE [dbo].[StudentClassRelationship] CHECK CONSTRAINT [FK_StudentClassRelationship_Students]
GO
USE [master]
GO
ALTER DATABASE [Educational_Center_Management_System] SET  READ_WRITE 
GO
