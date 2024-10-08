USE [master]
GO
/****** Object:  Database [Clean.Architecture.WS]    Script Date: 13-Aug-24 15:37:40 ******/
CREATE DATABASE [Clean.Architecture.WS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Clean.Architecture.WS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Clean.Architecture.WS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Clean.Architecture.WS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Clean.Architecture.WS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Clean.Architecture.WS] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Clean.Architecture.WS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Clean.Architecture.WS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Clean.Architecture.WS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Clean.Architecture.WS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Clean.Architecture.WS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Clean.Architecture.WS] SET ARITHABORT OFF 
GO
ALTER DATABASE [Clean.Architecture.WS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Clean.Architecture.WS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Clean.Architecture.WS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Clean.Architecture.WS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Clean.Architecture.WS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Clean.Architecture.WS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Clean.Architecture.WS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Clean.Architecture.WS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Clean.Architecture.WS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Clean.Architecture.WS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Clean.Architecture.WS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Clean.Architecture.WS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Clean.Architecture.WS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Clean.Architecture.WS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Clean.Architecture.WS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Clean.Architecture.WS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Clean.Architecture.WS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Clean.Architecture.WS] SET RECOVERY FULL 
GO
ALTER DATABASE [Clean.Architecture.WS] SET  MULTI_USER 
GO
ALTER DATABASE [Clean.Architecture.WS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Clean.Architecture.WS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Clean.Architecture.WS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Clean.Architecture.WS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Clean.Architecture.WS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Clean.Architecture.WS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Clean.Architecture.WS', N'ON'
GO
ALTER DATABASE [Clean.Architecture.WS] SET QUERY_STORE = OFF
GO
USE [Clean.Architecture.WS]
GO
/****** Object:  Table [dbo].[COMPANY]    Script Date: 13-Aug-24 15:37:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COMPANY](
	[COMPANY_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPANY_NAME] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_COMPANY] PRIMARY KEY CLUSTERED 
(
	[COMPANY_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[COMPANY_V]    Script Date: 13-Aug-24 15:37:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[COMPANY_V] AS
              SELECT 
                  COMPANY_ID,
                  COMPANY_NAME
              FROM 
                  COMPANY;
GO
/****** Object:  Table [dbo].[ROLE]    Script Date: 13-Aug-24 15:37:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ROLE](
	[ROLE_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ROLE_NAME] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_ROLE] PRIMARY KEY CLUSTERED 
(
	[ROLE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ROLE_V]    Script Date: 13-Aug-24 15:37:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
				  CREATE VIEW [dbo].[ROLE_V] AS
              SELECT 
                  ROLE_ID,
                  ROLE_NAME
              FROM 
                  ROLE;
GO
/****** Object:  Table [dbo].[EMPLOYEE]    Script Date: 13-Aug-24 15:37:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EMPLOYEE](
	[EMPLOYEE_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[FIRST_NAME] [nvarchar](255) NOT NULL,
	[LAST_NAME] [nvarchar](255) NOT NULL,
	[EMAIL] [nvarchar](255) NOT NULL,
	[PHONE_NUMBER] [nvarchar](50) NOT NULL,
	[ROLE_ID] [bigint] NOT NULL,
	[COMPANY_ID] [bigint] NOT NULL,
 CONSTRAINT [PK_EMPLOYEE] PRIMARY KEY CLUSTERED 
(
	[EMPLOYEE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[EMPLOYEE_V]    Script Date: 13-Aug-24 15:37:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[EMPLOYEE_V] AS
              SELECT 
                  E.EMPLOYEE_ID,
                  E.FIRST_NAME,
                  E.LAST_NAME,
                  E.EMAIL,
                  E.PHONE_NUMBER,
				  E.ROLE_ID,
                  R.ROLE_NAME,
				  E.COMPANY_ID,
                  C.COMPANY_NAME
              FROM 
                  EMPLOYEE E
              JOIN 
                  COMPANY C ON E.COMPANY_ID = C.COMPANY_ID
              JOIN 
                  ROLE R ON E.ROLE_ID = R.ROLE_ID;
GO
ALTER TABLE [dbo].[EMPLOYEE]  WITH CHECK ADD  CONSTRAINT [FK_EMPLOYEE_COMPANY] FOREIGN KEY([COMPANY_ID])
REFERENCES [dbo].[COMPANY] ([COMPANY_ID])
GO
ALTER TABLE [dbo].[EMPLOYEE] CHECK CONSTRAINT [FK_EMPLOYEE_COMPANY]
GO
ALTER TABLE [dbo].[EMPLOYEE]  WITH CHECK ADD  CONSTRAINT [FK_EMPLOYEE_ROLE] FOREIGN KEY([ROLE_ID])
REFERENCES [dbo].[ROLE] ([ROLE_ID])
GO
ALTER TABLE [dbo].[EMPLOYEE] CHECK CONSTRAINT [FK_EMPLOYEE_ROLE]
GO
/****** Object:  StoredProcedure [dbo].[DELETE_EMPLOYEE]    Script Date: 13-Aug-24 15:37:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DELETE_EMPLOYEE]
              @EmployeeId BIGINT
              AS
              BEGIN
                -- Ensure no referential integrity issues
                IF EXISTS (SELECT 1 FROM EMPLOYEE WHERE EMPLOYEE_ID = @EmployeeId)
                    BEGIN
                        DELETE FROM EMPLOYEE
                        WHERE EMPLOYEE_ID = @EmployeeId;
                    END
                ELSE
                    BEGIN
                        PRINT 'Not found!';
                    END
              END
GO
/****** Object:  StoredProcedure [dbo].[INSERT_COMPANY]    Script Date: 13-Aug-24 15:37:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERT_COMPANY]
              @CompanyName NVARCHAR(255)
              AS
              BEGIN
                  INSERT INTO COMPANY (COMPANY_NAME)
                  VALUES (@CompanyName);
              END
GO
/****** Object:  StoredProcedure [dbo].[INSERT_EMPLOYEE]    Script Date: 13-Aug-24 15:37:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERT_EMPLOYEE]
                @FirstName NVARCHAR(255),
                @LastName NVARCHAR(255),
                @Email NVARCHAR(255),
                @PhoneNumber NVARCHAR(50),
                @RoleId BIGINT,
                @CompanyId BIGINT
                AS
                BEGIN
                    INSERT INTO EMPLOYEE (FIRST_NAME, LAST_NAME, EMAIL, PHONE_NUMBER, ROLE_ID, COMPANY_ID)
                    VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @RoleId, @CompanyId);
                END
GO
/****** Object:  StoredProcedure [dbo].[INSERT_ROLE]    Script Date: 13-Aug-24 15:37:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERT_ROLE]
              @RoleName NVARCHAR(255)
              AS
              BEGIN
                  INSERT INTO ROLE (ROLE_NAME)
                  VALUES (@RoleName);
              END
GO
/****** Object:  StoredProcedure [dbo].[UPDATE_COMPANY]    Script Date: 13-Aug-24 15:37:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UPDATE_COMPANY]
              @CompanyId BIGINT,
              @CompanyName NVARCHAR(255) = NULL
              AS
              BEGIN
                  UPDATE COMPANY
                  SET 
                      COMPANY_NAME = ISNULL(@CompanyName, COMPANY_NAME)
                  WHERE COMPANY_ID = @CompanyId;
              END
GO
/****** Object:  StoredProcedure [dbo].[UPDATE_EMPLOYEE]    Script Date: 13-Aug-24 15:37:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UPDATE_EMPLOYEE]
              @EmployeeId BIGINT,
              @FirstName NVARCHAR(255) = NULL,
              @LastName NVARCHAR(255) = NULL,
              @Email NVARCHAR(255) = NULL,
              @PhoneNumber NVARCHAR(50) = NULL,
              @RoleId BIGINT = NULL,
              @CompanyId BIGINT = NULL
              AS
              BEGIN
                  UPDATE EMPLOYEE
                  SET 
                      FIRST_NAME = ISNULL(@FirstName, FIRST_NAME),
                      LAST_NAME = ISNULL(@LastName, LAST_NAME),
                      EMAIL = ISNULL(@Email, EMAIL),
                      PHONE_NUMBER = ISNULL(@PhoneNumber, PHONE_NUMBER),
                      ROLE_ID = ISNULL(@RoleId, ROLE_ID),
                      COMPANY_ID = ISNULL(@CompanyId, COMPANY_ID)
                  WHERE EMPLOYEE_ID = @EmployeeId;
              END
GO
/****** Object:  StoredProcedure [dbo].[UPDATE_ROLE]    Script Date: 13-Aug-24 15:37:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UPDATE_ROLE]
              @RoleId BIGINT,
              @RoleName NVARCHAR(255)
              AS
              BEGIN
                UPDATE ROLE
                SET
                    ROLE_NAME = ISNULL(@RoleName, ROLE_NAME)
                WHERE ROLE_ID = @RoleId;
              END
GO
USE [master]
GO
ALTER DATABASE [Clean.Architecture.WS] SET  READ_WRITE 
GO
