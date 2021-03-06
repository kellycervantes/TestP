USE [master]
GO
/****** Object:  Database [Test]    Script Date: 10/09/2017 19:43:26 ******/
CREATE DATABASE [Test]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Test', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.CERVANTESRPC\MSSQL\DATA\Test.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Test_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.CERVANTESRPC\MSSQL\DATA\Test_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Test] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Test].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Test] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Test] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Test] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Test] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Test] SET ARITHABORT OFF 
GO
ALTER DATABASE [Test] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Test] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Test] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Test] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Test] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Test] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Test] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Test] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Test] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Test] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Test] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Test] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Test] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Test] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Test] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Test] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Test] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Test] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Test] SET  MULTI_USER 
GO
ALTER DATABASE [Test] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Test] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Test] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Test] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Test] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Test]
GO
/****** Object:  User [Service]    Script Date: 10/09/2017 19:43:26 ******/
CREATE USER [Service] FOR LOGIN [Service] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[BonusGranted]    Script Date: 10/09/2017 19:43:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BonusGranted](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[BonusStatus] [bit] NOT NULL,
	[IdRechargeSim] [int] NOT NULL,
 CONSTRAINT [PK_BonusGranted] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Historial]    Script Date: 10/09/2017 19:43:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Historial](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdSim] [int] NOT NULL,
	[MinutesConsumed] [int] NOT NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK_Historial] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RechargeConfig]    Script Date: 10/09/2017 19:43:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RechargeConfig](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [int] NOT NULL,
	[PriceperMinute] [int] NOT NULL,
	[Minutes] [int] NOT NULL,
	[Status] [varchar](5) NOT NULL,
 CONSTRAINT [PK_RechargeConfig] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RechargeSim]    Script Date: 10/09/2017 19:43:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RechargeSim](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [float] NOT NULL,
	[IdSim] [int] NOT NULL,
	[IdRechargeConfig] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Status] [varchar](5) NOT NULL,
	[Minutes] [int] NOT NULL,
	[Bonus] [int] NULL,
	[BonusMin] [int] NULL,
 CONSTRAINT [PK_RechargeSim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sims]    Script Date: 10/09/2017 19:43:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SerialNumber] [varchar](150) NOT NULL,
	[Number] [bigint] NOT NULL,
 CONSTRAINT [PK_Sims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[VwMinutesReport]    Script Date: 10/09/2017 19:43:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[VwMinutesReport]
AS
SELECT        Number, SUM(TotalMinutes) AS TotalMinutes, SUM(MinutesConsumed) AS MinutesConsumed, SUM(TotalMinutes) - SUM(MinutesConsumed) AS MinutesLeft
FROM            (SELECT        S.Number, 0 AS TotalMinutes, SUM(H.MinutesConsumed) AS MinutesConsumed
                          FROM            dbo.Historial AS H INNER JOIN
                                                    dbo.Sims AS S ON H.IdSim = S.Id
                          GROUP BY S.Number
                          UNION ALL
                          SELECT        S.Number, SUM(RS.Minutes) AS TotalMinutes, 0 AS MinutesConsumed
                          FROM            dbo.RechargeSim AS RS INNER JOIN
                                                   dbo.Sims AS S ON RS.IdSim = S.Id
                          GROUP BY S.Number) AS T
GROUP BY Number


GO
SET IDENTITY_INSERT [dbo].[BonusGranted] ON 

INSERT [dbo].[BonusGranted] ([Id], [Date], [BonusStatus], [IdRechargeSim]) VALUES (1, CAST(N'2017-09-06' AS Date), 1, 4)
INSERT [dbo].[BonusGranted] ([Id], [Date], [BonusStatus], [IdRechargeSim]) VALUES (2, CAST(N'2017-09-08' AS Date), 1, 1004)
SET IDENTITY_INSERT [dbo].[BonusGranted] OFF
SET IDENTITY_INSERT [dbo].[Historial] ON 

INSERT [dbo].[Historial] ([Id], [IdSim], [MinutesConsumed], [Date]) VALUES (2, 1, 30, CAST(N'2017-09-08 17:10:47.673' AS DateTime))
INSERT [dbo].[Historial] ([Id], [IdSim], [MinutesConsumed], [Date]) VALUES (3, 1, 60, CAST(N'2017-09-08 17:23:20.287' AS DateTime))
INSERT [dbo].[Historial] ([Id], [IdSim], [MinutesConsumed], [Date]) VALUES (4, 1, 60, CAST(N'2017-09-08 18:09:53.200' AS DateTime))
INSERT [dbo].[Historial] ([Id], [IdSim], [MinutesConsumed], [Date]) VALUES (5, 1, 50, CAST(N'2017-09-08 18:10:51.160' AS DateTime))
INSERT [dbo].[Historial] ([Id], [IdSim], [MinutesConsumed], [Date]) VALUES (6, 1, 20, CAST(N'2017-09-08 18:16:45.537' AS DateTime))
INSERT [dbo].[Historial] ([Id], [IdSim], [MinutesConsumed], [Date]) VALUES (7, 1, 5, CAST(N'2017-09-08 18:23:29.817' AS DateTime))
INSERT [dbo].[Historial] ([Id], [IdSim], [MinutesConsumed], [Date]) VALUES (8, 1, 10, CAST(N'2017-09-08 18:30:20.760' AS DateTime))
INSERT [dbo].[Historial] ([Id], [IdSim], [MinutesConsumed], [Date]) VALUES (9, 3, 10, CAST(N'2017-09-10 15:57:58.443' AS DateTime))
SET IDENTITY_INSERT [dbo].[Historial] OFF
SET IDENTITY_INSERT [dbo].[RechargeConfig] ON 

INSERT [dbo].[RechargeConfig] ([Id], [Amount], [PriceperMinute], [Minutes], [Status]) VALUES (1, 50000, 500, 100, N'D')
INSERT [dbo].[RechargeConfig] ([Id], [Amount], [PriceperMinute], [Minutes], [Status]) VALUES (3, 20000, 500, 40, N'E')
INSERT [dbo].[RechargeConfig] ([Id], [Amount], [PriceperMinute], [Minutes], [Status]) VALUES (4, 10000, 500, 20, N'E')
INSERT [dbo].[RechargeConfig] ([Id], [Amount], [PriceperMinute], [Minutes], [Status]) VALUES (5, 5000, 500, 10, N'E')
INSERT [dbo].[RechargeConfig] ([Id], [Amount], [PriceperMinute], [Minutes], [Status]) VALUES (6, 50000, 500, 100, N'E')
INSERT [dbo].[RechargeConfig] ([Id], [Amount], [PriceperMinute], [Minutes], [Status]) VALUES (7, 60000, 500, 120, N'E')
INSERT [dbo].[RechargeConfig] ([Id], [Amount], [PriceperMinute], [Minutes], [Status]) VALUES (14, 100000, 200, 500, N'D')
INSERT [dbo].[RechargeConfig] ([Id], [Amount], [PriceperMinute], [Minutes], [Status]) VALUES (16, 40000, 200, 200, N'D')
SET IDENTITY_INSERT [dbo].[RechargeConfig] OFF
SET IDENTITY_INSERT [dbo].[RechargeSim] ON 

INSERT [dbo].[RechargeSim] ([Id], [Amount], [IdSim], [IdRechargeConfig], [Date], [Status], [Minutes], [Bonus], [BonusMin]) VALUES (1, 10000, 1, 4, CAST(N'2017-09-05 13:07:17.650' AS DateTime), N'A', 20, NULL, NULL)
INSERT [dbo].[RechargeSim] ([Id], [Amount], [IdSim], [IdRechargeConfig], [Date], [Status], [Minutes], [Bonus], [BonusMin]) VALUES (2, 20000, 1, 3, CAST(N'2017-09-06 09:13:11.263' AS DateTime), N'A', 40, NULL, NULL)
INSERT [dbo].[RechargeSim] ([Id], [Amount], [IdSim], [IdRechargeConfig], [Date], [Status], [Minutes], [Bonus], [BonusMin]) VALUES (4, 22000, 1, 3, CAST(N'2017-09-06 15:22:20.653' AS DateTime), N'A', 44, 2000, 4)
INSERT [dbo].[RechargeSim] ([Id], [Amount], [IdSim], [IdRechargeConfig], [Date], [Status], [Minutes], [Bonus], [BonusMin]) VALUES (1004, 66000, 1, 7, CAST(N'2017-09-08 11:52:14.393' AS DateTime), N'A', 132, 6000, 12)
INSERT [dbo].[RechargeSim] ([Id], [Amount], [IdSim], [IdRechargeConfig], [Date], [Status], [Minutes], [Bonus], [BonusMin]) VALUES (1005, 10000, 3, 4, CAST(N'2017-09-10 14:40:23.903' AS DateTime), N'A', 20, NULL, NULL)
SET IDENTITY_INSERT [dbo].[RechargeSim] OFF
SET IDENTITY_INSERT [dbo].[Sims] ON 

INSERT [dbo].[Sims] ([Id], [SerialNumber], [Number]) VALUES (1, N'S2-5676577', 3046343714)
INSERT [dbo].[Sims] ([Id], [SerialNumber], [Number]) VALUES (2, N'S2-45645', 3175359810)
INSERT [dbo].[Sims] ([Id], [SerialNumber], [Number]) VALUES (3, N'435-jgh', 3008166211)
INSERT [dbo].[Sims] ([Id], [SerialNumber], [Number]) VALUES (9, N'jghjhgjhgj', 3046343713)
SET IDENTITY_INSERT [dbo].[Sims] OFF
ALTER TABLE [dbo].[BonusGranted]  WITH CHECK ADD  CONSTRAINT [FK_BonusGranted_RechargeSim] FOREIGN KEY([IdRechargeSim])
REFERENCES [dbo].[RechargeSim] ([Id])
GO
ALTER TABLE [dbo].[BonusGranted] CHECK CONSTRAINT [FK_BonusGranted_RechargeSim]
GO
ALTER TABLE [dbo].[Historial]  WITH CHECK ADD  CONSTRAINT [FK_Historial_Sims] FOREIGN KEY([IdSim])
REFERENCES [dbo].[Sims] ([Id])
GO
ALTER TABLE [dbo].[Historial] CHECK CONSTRAINT [FK_Historial_Sims]
GO
ALTER TABLE [dbo].[RechargeSim]  WITH CHECK ADD  CONSTRAINT [FK_RechargeSim_RechargeConfig] FOREIGN KEY([IdRechargeConfig])
REFERENCES [dbo].[RechargeConfig] ([Id])
GO
ALTER TABLE [dbo].[RechargeSim] CHECK CONSTRAINT [FK_RechargeSim_RechargeConfig]
GO
ALTER TABLE [dbo].[RechargeSim]  WITH CHECK ADD  CONSTRAINT [FK_RechargeSim_Sims] FOREIGN KEY([IdSim])
REFERENCES [dbo].[Sims] ([Id])
GO
ALTER TABLE [dbo].[RechargeSim] CHECK CONSTRAINT [FK_RechargeSim_Sims]
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
         Begin Table = "T"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 247
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
      Begin ColumnWidths = 12
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwMinutesReport'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwMinutesReport'
GO
USE [master]
GO
ALTER DATABASE [Test] SET  READ_WRITE 
GO
