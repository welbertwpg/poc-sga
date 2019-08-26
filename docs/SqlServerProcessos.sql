USE [master]
GO
/****** Object:  Database [processos]    Script Date: 26/08/2019 18:46:32 ******/
CREATE DATABASE [processos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'processos', FILENAME = N'/var/opt/mssql/data/processos.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'processos_log', FILENAME = N'/var/opt/mssql/data/processos_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [processos] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [processos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [processos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [processos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [processos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [processos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [processos] SET ARITHABORT OFF 
GO
ALTER DATABASE [processos] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [processos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [processos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [processos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [processos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [processos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [processos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [processos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [processos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [processos] SET  ENABLE_BROKER 
GO
ALTER DATABASE [processos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [processos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [processos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [processos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [processos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [processos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [processos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [processos] SET RECOVERY FULL 
GO
ALTER DATABASE [processos] SET  MULTI_USER 
GO
ALTER DATABASE [processos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [processos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [processos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [processos] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [processos] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [processos] SET QUERY_STORE = OFF
GO
USE [processos]
GO
/****** Object:  Table [dbo].[EtapaReferencia]    Script Date: 26/08/2019 18:46:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EtapaReferencia](
	[IdentificadorEtapaEntrada] [uniqueidentifier] NOT NULL,
	[IdentificadorEtapaSaida] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Etapas]    Script Date: 26/08/2019 18:46:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Etapas](
	[Identificador] [uniqueidentifier] NOT NULL,
	[Tipo] [int] NOT NULL,
	[Nome] [nvarchar](200) NOT NULL,
	[IdentificadorProcesso] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Etapa] PRIMARY KEY CLUSTERED 
(
	[Identificador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paradas]    Script Date: 26/08/2019 18:46:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paradas](
	[Identificador] [uniqueidentifier] NOT NULL,
	[Data] [datetime2](7) NOT NULL,
	[Turno] [int] NOT NULL,
	[Descricao] [nvarchar](500) NOT NULL,
	[IdentificadorEtapa] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Parada] PRIMARY KEY CLUSTERED 
(
	[Identificador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Problemas]    Script Date: 26/08/2019 18:46:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Problemas](
	[Identificador] [uniqueidentifier] NOT NULL,
	[Data] [datetime2](7) NOT NULL,
	[Turno] [int] NOT NULL,
	[Descricao] [nvarchar](500) NOT NULL,
	[IdentificadorEtapa] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Problema] PRIMARY KEY CLUSTERED 
(
	[Identificador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Processos]    Script Date: 26/08/2019 18:46:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Processos](
	[Identificador] [uniqueidentifier] NOT NULL,
	[Nome] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Processo] PRIMARY KEY CLUSTERED 
(
	[Identificador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_Parada_EtapaIdentificador]    Script Date: 26/08/2019 18:46:32 ******/
CREATE NONCLUSTERED INDEX [IX_Parada_EtapaIdentificador] ON [dbo].[Paradas]
(
	[IdentificadorEtapa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Problema_EtapaIdentificador]    Script Date: 26/08/2019 18:46:32 ******/
CREATE NONCLUSTERED INDEX [IX_Problema_EtapaIdentificador] ON [dbo].[Problemas]
(
	[IdentificadorEtapa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EtapaReferencia]  WITH CHECK ADD  CONSTRAINT [FK_EtapaEntrada] FOREIGN KEY([IdentificadorEtapaEntrada])
REFERENCES [dbo].[Etapas] ([Identificador])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EtapaReferencia] CHECK CONSTRAINT [FK_EtapaEntrada]
GO
ALTER TABLE [dbo].[EtapaReferencia]  WITH CHECK ADD  CONSTRAINT [FK_EtapaSaida] FOREIGN KEY([IdentificadorEtapaSaida])
REFERENCES [dbo].[Etapas] ([Identificador])
GO
ALTER TABLE [dbo].[EtapaReferencia] CHECK CONSTRAINT [FK_EtapaSaida]
GO
ALTER TABLE [dbo].[Etapas]  WITH CHECK ADD  CONSTRAINT [FK_Etapa_Processo_IdentificadorProcesso] FOREIGN KEY([IdentificadorProcesso])
REFERENCES [dbo].[Processos] ([Identificador])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Etapas] CHECK CONSTRAINT [FK_Etapa_Processo_IdentificadorProcesso]
GO
ALTER TABLE [dbo].[Paradas]  WITH CHECK ADD  CONSTRAINT [FK_EtapaParada] FOREIGN KEY([IdentificadorEtapa])
REFERENCES [dbo].[Etapas] ([Identificador])
GO
ALTER TABLE [dbo].[Paradas] CHECK CONSTRAINT [FK_EtapaParada]
GO
ALTER TABLE [dbo].[Problemas]  WITH CHECK ADD  CONSTRAINT [FK_EtapaProblema] FOREIGN KEY([IdentificadorEtapa])
REFERENCES [dbo].[Etapas] ([Identificador])
GO
ALTER TABLE [dbo].[Problemas] CHECK CONSTRAINT [FK_EtapaProblema]
GO
USE [master]
GO
ALTER DATABASE [processos] SET  READ_WRITE 
GO
