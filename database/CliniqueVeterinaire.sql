USE [master]
GO
/****** Object:  Database [CliniqueVeterinaire]    Script Date: 4/27/2026 6:16:29 PM ******/
CREATE DATABASE [CliniqueVeterinaire]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CliniqueVeterinaire', FILENAME = N'D:\Microsoft SQL Server\MSSQL17.SQLEXPRESS\MSSQL\DATA\CliniqueVeterinaire.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CliniqueVeterinaire_log', FILENAME = N'D:\Microsoft SQL Server\MSSQL17.SQLEXPRESS\MSSQL\DATA\CliniqueVeterinaire_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [CliniqueVeterinaire] SET COMPATIBILITY_LEVEL = 170
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CliniqueVeterinaire].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CliniqueVeterinaire] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CliniqueVeterinaire] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CliniqueVeterinaire] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CliniqueVeterinaire] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CliniqueVeterinaire] SET ARITHABORT OFF 
GO
ALTER DATABASE [CliniqueVeterinaire] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CliniqueVeterinaire] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CliniqueVeterinaire] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CliniqueVeterinaire] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CliniqueVeterinaire] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CliniqueVeterinaire] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CliniqueVeterinaire] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CliniqueVeterinaire] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CliniqueVeterinaire] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CliniqueVeterinaire] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CliniqueVeterinaire] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CliniqueVeterinaire] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CliniqueVeterinaire] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CliniqueVeterinaire] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CliniqueVeterinaire] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CliniqueVeterinaire] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CliniqueVeterinaire] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CliniqueVeterinaire] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CliniqueVeterinaire] SET  MULTI_USER 
GO
ALTER DATABASE [CliniqueVeterinaire] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CliniqueVeterinaire] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CliniqueVeterinaire] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CliniqueVeterinaire] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CliniqueVeterinaire] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CliniqueVeterinaire] SET OPTIMIZED_LOCKING = OFF 
GO
ALTER DATABASE [CliniqueVeterinaire] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CliniqueVeterinaire] SET QUERY_STORE = ON
GO
ALTER DATABASE [CliniqueVeterinaire] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [CliniqueVeterinaire]
GO
/****** Object:  Table [dbo].[Animal]    Script Date: 4/27/2026 6:16:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Animal](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [varchar](100) NOT NULL,
	[Espece] [varchar](50) NOT NULL,
	[Race] [varchar](50) NULL,
	[Sexe] [char](1) NULL,
	[DateNaissance] [date] NULL,
	[Couleur] [varchar](50) NULL,
	[ProprietaireId] [int] NOT NULL,
	[DateCreation] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Consultation]    Script Date: 4/27/2026 6:16:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consultation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateConsultation] [datetime] NULL,
	[Diagnostic] [text] NULL,
	[Traitement] [text] NULL,
	[Poids] [decimal](5, 2) NULL,
	[Temperature] [decimal](4, 2) NULL,
	[AnimalId] [int] NOT NULL,
	[VeterinaireId] [int] NOT NULL,
	[Remarques] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facture]    Script Date: 4/27/2026 6:16:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facture](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NumeroFacture] [varchar](20) NOT NULL,
	[DateFacture] [datetime] NULL,
	[MontantHT] [decimal](10, 2) NOT NULL,
	[TVA] [decimal](10, 2) NULL,
	[MontantTTC] [decimal](10, 2) NOT NULL,
	[Paye] [bit] NULL,
	[DatePaiement] [datetime] NULL,
	[ModePaiement] [varchar](50) NULL,
	[ConsultationId] [int] NOT NULL,
	[AnimalId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[NumeroFacture] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicament]    Script Date: 4/27/2026 6:16:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicament](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [varchar](100) NOT NULL,
	[Description] [text] NULL,
	[PrixUnitaire] [decimal](10, 2) NULL,
	[QuantiteStock] [int] NULL,
	[SeuilAlerte] [int] NULL,
	[DateExpiration] [date] NULL,
	[Fournisseur] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prescription]    Script Date: 4/27/2026 6:16:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prescription](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ConsultationId] [int] NOT NULL,
	[MedicamentId] [int] NOT NULL,
	[Dosage] [varchar](100) NULL,
	[Instructions] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proprietaire]    Script Date: 4/27/2026 6:16:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proprietaire](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [varchar](100) NOT NULL,
	[Prenom] [varchar](100) NOT NULL,
	[Adresse] [varchar](255) NULL,
	[CodePostal] [varchar](10) NULL,
	[Ville] [varchar](100) NULL,
	[Telephone] [varchar](20) NULL,
	[Email] [varchar](100) NULL,
	[DateInscription] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RendezVous]    Script Date: 4/27/2026 6:16:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RendezVous](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateHeure] [datetime] NOT NULL,
	[Duree] [int] NULL,
	[Motif] [varchar](255) NULL,
	[Statut] [varchar](20) NULL,
	[AnimalId] [int] NOT NULL,
	[VeterinaireId] [int] NOT NULL,
	[Notes] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SuiviMedical]    Script Date: 4/27/2026 6:16:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SuiviMedical](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AnimalId] [int] NOT NULL,
	[DateSuivi] [datetime] NULL,
	[TypeSuivi] [varchar](50) NULL,
	[Description] [text] NULL,
	[VeterinaireId] [int] NOT NULL,
	[ProchainRdv] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utilisateur]    Script Date: 4/27/2026 6:16:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utilisateur](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [varchar](100) NOT NULL,
	[Prenom] [varchar](100) NULL,
	[Login] [varchar](50) NOT NULL,
	[MotDePasse] [varchar](100) NOT NULL,
	[Role] [varchar](20) NOT NULL,
	[Email] [varchar](100) NULL,
	[Telephone] [varchar](20) NULL,
	[DateCreation] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vaccination]    Script Date: 4/27/2026 6:16:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vaccination](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NomVaccin] [varchar](100) NOT NULL,
	[DateAdministration] [date] NOT NULL,
	[DateRappel] [date] NULL,
	[AnimalId] [int] NOT NULL,
	[VeterinaireId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Animal] ADD  DEFAULT (getdate()) FOR [DateCreation]
GO
ALTER TABLE [dbo].[Consultation] ADD  DEFAULT (getdate()) FOR [DateConsultation]
GO
ALTER TABLE [dbo].[Facture] ADD  DEFAULT (getdate()) FOR [DateFacture]
GO
ALTER TABLE [dbo].[Facture] ADD  DEFAULT ((20)) FOR [TVA]
GO
ALTER TABLE [dbo].[Facture] ADD  DEFAULT ((0)) FOR [Paye]
GO
ALTER TABLE [dbo].[Medicament] ADD  DEFAULT ((0)) FOR [QuantiteStock]
GO
ALTER TABLE [dbo].[Medicament] ADD  DEFAULT ((5)) FOR [SeuilAlerte]
GO
ALTER TABLE [dbo].[Proprietaire] ADD  DEFAULT (getdate()) FOR [DateInscription]
GO
ALTER TABLE [dbo].[RendezVous] ADD  DEFAULT ((30)) FOR [Duree]
GO
ALTER TABLE [dbo].[RendezVous] ADD  DEFAULT ('Planifie') FOR [Statut]
GO
ALTER TABLE [dbo].[SuiviMedical] ADD  DEFAULT (getdate()) FOR [DateSuivi]
GO
ALTER TABLE [dbo].[Utilisateur] ADD  DEFAULT (getdate()) FOR [DateCreation]
GO
ALTER TABLE [dbo].[Animal]  WITH CHECK ADD FOREIGN KEY([ProprietaireId])
REFERENCES [dbo].[Proprietaire] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Consultation]  WITH CHECK ADD FOREIGN KEY([AnimalId])
REFERENCES [dbo].[Animal] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Consultation]  WITH CHECK ADD FOREIGN KEY([VeterinaireId])
REFERENCES [dbo].[Utilisateur] ([Id])
GO
ALTER TABLE [dbo].[Facture]  WITH CHECK ADD FOREIGN KEY([AnimalId])
REFERENCES [dbo].[Animal] ([Id])
GO
ALTER TABLE [dbo].[Facture]  WITH CHECK ADD FOREIGN KEY([ConsultationId])
REFERENCES [dbo].[Consultation] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Prescription]  WITH CHECK ADD FOREIGN KEY([ConsultationId])
REFERENCES [dbo].[Consultation] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Prescription]  WITH CHECK ADD FOREIGN KEY([MedicamentId])
REFERENCES [dbo].[Medicament] ([Id])
GO
ALTER TABLE [dbo].[RendezVous]  WITH CHECK ADD FOREIGN KEY([AnimalId])
REFERENCES [dbo].[Animal] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RendezVous]  WITH CHECK ADD FOREIGN KEY([VeterinaireId])
REFERENCES [dbo].[Utilisateur] ([Id])
GO
ALTER TABLE [dbo].[SuiviMedical]  WITH CHECK ADD FOREIGN KEY([AnimalId])
REFERENCES [dbo].[Animal] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SuiviMedical]  WITH CHECK ADD FOREIGN KEY([VeterinaireId])
REFERENCES [dbo].[Utilisateur] ([Id])
GO
ALTER TABLE [dbo].[Vaccination]  WITH CHECK ADD FOREIGN KEY([AnimalId])
REFERENCES [dbo].[Animal] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Vaccination]  WITH CHECK ADD FOREIGN KEY([VeterinaireId])
REFERENCES [dbo].[Utilisateur] ([Id])
GO
ALTER TABLE [dbo].[Animal]  WITH CHECK ADD CHECK  (([Sexe]='F' OR [Sexe]='M'))
GO
ALTER TABLE [dbo].[Utilisateur]  WITH CHECK ADD CHECK  (([Role]='Veterinaire' OR [Role]='Secretaire' OR [Role]='Administrateur'))
GO
USE [master]
GO
ALTER DATABASE [CliniqueVeterinaire] SET  READ_WRITE 
GO
