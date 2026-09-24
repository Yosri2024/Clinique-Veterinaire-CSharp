# 🐾 Clinique Vétérinaire — C# WinForms + SQL Server

[![C#](https://img.shields.io/badge/C%23-10.0-239120?logo=csharp&logoColor=white)](CliniqueVeterinaire/CliniqueVeterinaire.csproj)
[![.NET](https://img.shields.io/badge/.NET-10.0--windows-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![WinForms](https://img.shields.io/badge/WinForms-Desktop-0078D4)](https://learn.microsoft.com/en-us/dotnet/desktop/winforms/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-2022-CC2927?logo=microsoftsqlserver&logoColor=white)](database/CliniqueVeterinaire.sql)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)

Application de gestion complète pour clinique vétérinaire : authentification par rôles, gestion des animaux/propriétaires, consultations, vaccins, stock et facturation avec génération PDF.

---

## 📸 Fonctionnalités

* **Authentification** `Form1.cs` : login `Utilisateur` (`Administrateur` / `Secretaire` / `Veterinaire`) via `Microsoft.Data.SqlClient` paramétré
* **Rôles :**
  * **Administrateur** `FormAdministrateur.cs` - dashboard, gestion utilisateurs
  * **Secrétaire** `FormSecretaire.cs` (43k lignes) - accueil, rendez-vous, factures
  * **Vétérinaire** `FormVeterinaire.cs` - consultations, vaccins, dossiers animaux
* **Gestion :**
  * `FormGestionUtilisateurs.cs` - CRUD utilisateurs
  * `FormGestionStock.cs` - inventaire médicaments
  * `FormGestionFactures.cs` + `FormMontantFacture.cs` - facturation + PDF `iTextSharp`
  * `FormChoisirConsultation.cs` / `FormAjouterVaccin.cs` - workflow clinique
* **Base de données** `database/CliniqueVeterinaire.sql` : `USE [master]` + `CliniqueVeterinaire` (MDF/LDF), tables `Animal`, `Proprietaire`, `Utilisateur`, `Consultation`, `Vaccin`, `Facture`, etc.

---

## 🗂️ Structure

```
clinique-veterinaire-CSharp/
├── CliniqueVeterinaire.sln
├── CliniqueVeterinaire/
│   ├── CliniqueVeterinaire.csproj  # net10.0-windows, iTextSharp, Microsoft.Data.SqlClient
│   ├── Program.cs                  # Application.Run(new Form1())
│   ├── ConnexionBD.cs              # Data Source=localhost\SQLEXPRESS; Integrated Security
│   ├── Form1.cs (+ Designer/resx)  # Login
│   ├── FormAdministrateur.cs       # Admin
│   ├── FormSecretaire.cs           # Secrétaire
│   ├── FormVeterinaire.cs          # Vétérinaire
│   ├── FormGestion*.cs             # Stock / Factures / Utilisateurs / Vaccins
│   └── ...
├── database/
│   └── CliniqueVeterinaire.sql     # Script complet (UTF-8, ~27k lignes)
├── docs/
│   └── rapport.pdf                 # Rapport du projet
├── .github/workflows/dotnet.yml    # CI Windows + dotnet build
├── .gitignore
└── README.md
```

---

## 🚀 Prérequis

* **Windows 10/11** (WinForms `net10.0-windows` ne tourne pas sur Linux/macOS sans Wine)
* **.NET 10 SDK** (ou 8/9 - change `TargetFramework` dans `.csproj` si besoin)
* **SQL Server 2017+** (`SQLEXPRESS`) ou Docker
* **Visual Studio 2022** (17.8+) avec workload `.NET Desktop`

---

## ⚙️ Installation

### 1. Base de données

**Option A — SQL Server local :**
```sql
-- Dans SSMS, ouvrir database/CliniqueVeterinaire.sql et Exécuter (F5)
-- Le script fait : CREATE DATABASE [CliniqueVeterinaire] + tables
-- Chemin par défaut : D:\Microsoft SQL Server\MSSQL17.SQLEXPRESS\MSSQL\DATA\*.mdf
-- Si erreur de chemin, modifie FILENAME dans les 2 lignes du script
```

**Option B — Docker :**
```bash
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=YourStrong!Passw0rd" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
# Puis SSMS -> localhost,1433 -> SA / YourStrong!Passw0rd -> exécuter CliniqueVeterinaire.sql
# Et adapter ConnexionBD.cs : Data Source=localhost,1433;User Id=sa;Password=...
```

### 2. Connexion
`CliniqueVeterinaire/ConnexionBD.cs:7` :
```csharp
private string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=CliniqueVeterinaire;Integrated Security=True;TrustServerCertificate=True;";
```
Change si besoin : `localhost,1433` + `User Id=sa;Password=...` ou instance nommée.

### 3. Build & Run

**Visual Studio :**
```
Ouvrir CliniqueVeterinaire.sln -> F5 (Debug) ou Ctrl+F5
```

**CLI :**
```bash
dotnet restore
dotnet build CliniqueVeterinaire.sln -c Release
dotnet run --project CliniqueVeterinaire/CliniqueVeterinaire.csproj
# ou exe : CliniqueVeterinaire/bin/Release/net10.0-windows/CliniqueVeterinaire.exe
```

---

## 🔐 Comptes par défaut

Vérifie dans `database/CliniqueVeterinaire.sql` table `Utilisateur` (`INSERT INTO Utilisateur...`) - login/mdp fournis dans le rapport. Exemple typique (à vérifier) :
* `admin` / `admin` -> `Administrateur`
* `secretaire` / `...` -> `Secretaire`
* `veto` / `...` -> `Veterinaire`

> Si vide, crée via SSMS : `INSERT INTO Utilisateur (Login, MotDePasse, Role, Nom, Prenom) VALUES ('admin','admin','Administrateur','Admin','Test')`

---

## 🧪 CI

`.github/workflows/dotnet.yml` build sur `windows-latest` avec `dotnet 10` à chaque push (vérifie que `CliniqueVeterinaire.csproj` compile).

```bash
# Local vérif sans VS
dotnet build CliniqueVeterinaire.sln
```

---

## 📝 Notes

* Connexion paramétrée `cmd.Parameters.AddWithValue` -> anti-injection
* PDF via `iTextSharp.LGPLv2.Core 3.7.12`
* `*.user`, `bin/`, `obj/`, `.vs/` ignorés par `.gitignore`
* `rapport.pdf` dans `docs/` -> rapport académique

---

## 📄 Licence

MIT — voir [LICENSE](LICENSE).

## 👨‍💻 Auteur

Projet C# WinForms — Clinique Vétérinaire — Yosri.
