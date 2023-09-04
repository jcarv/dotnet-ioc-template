USE [master]
GO

CREATE DATABASE [DotNetIocTemplateDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DotNetIocTemplateDatabase', FILENAME = N'/var/opt/mssql/data/DotNetIocTemplateDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DotNetIocTemplateDatabase_log', FILENAME = N'/var/opt/mssql/data/DotNetIocTemplateDatabase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DotNetIocTemplateDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [DotNetIocTemplateDatabase] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [DotNetIocTemplateDatabase] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [DotNetIocTemplateDatabase] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [DotNetIocTemplateDatabase] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [DotNetIocTemplateDatabase] SET ARITHABORT OFF 
GO

ALTER DATABASE [DotNetIocTemplateDatabase] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [DotNetIocTemplateDatabase] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [DotNetIocTemplateDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [DotNetIocTemplateDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [DotNetIocTemplateDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [DotNetIocTemplateDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [DotNetIocTemplateDatabase] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [DotNetIocTemplateDatabase] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [DotNetIocTemplateDatabase] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [DotNetIocTemplateDatabase] SET  DISABLE_BROKER 
GO

ALTER DATABASE [DotNetIocTemplateDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [DotNetIocTemplateDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [DotNetIocTemplateDatabase] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [DotNetIocTemplateDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [DotNetIocTemplateDatabase] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [DotNetIocTemplateDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [DotNetIocTemplateDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [DotNetIocTemplateDatabase] SET RECOVERY FULL 
GO

ALTER DATABASE [DotNetIocTemplateDatabase] SET  MULTI_USER 
GO

ALTER DATABASE [DotNetIocTemplateDatabase] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [DotNetIocTemplateDatabase] SET DB_CHAINING OFF 
GO

ALTER DATABASE [DotNetIocTemplateDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [DotNetIocTemplateDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [DotNetIocTemplateDatabase] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [DotNetIocTemplateDatabase] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [DotNetIocTemplateDatabase] SET QUERY_STORE = ON
GO

ALTER DATABASE [DotNetIocTemplateDatabase] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO

ALTER DATABASE [DotNetIocTemplateDatabase] SET  READ_WRITE 
GO

USE [master]
GO
CREATE LOGIN [DotNetIocTemplateDatabaseUser] WITH PASSWORD=N'123456', DEFAULT_DATABASE=[DotNetIocTemplateDatabase], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
USE [DotNetIocTemplateDatabase]
GO
CREATE USER [DotNetIocTemplateDatabaseUser] FOR LOGIN [DotNetIocTemplateDatabaseUser]
GO
ALTER ROLE [db_datareader] ADD MEMBER [DotNetIocTemplateDatabaseUser]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [DotNetIocTemplateDatabaseUser]
GO
ALTER ROLE [db_owner] ADD MEMBER [DotNetIocTemplateDatabaseUser]
GO
