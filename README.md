# Dotnet - Fred. Colin

## Architecture

DataContracts : c'est le modèle de données, les classes qui représentent les données.
ServicesContracts : c'est la couche de contrats de services, les interfaces des services.
Services : c'est la couche de services, les classes qui gèrent la logique métier, les accès aux données, etc.
IHM : c'est l'interface utilisateur, les vues, les contrôleurs, les viewmodels.

### Dotnet

1. Net Core : Cross platform, open source

2. Net Framework : Windows only, legacy

### Conventions

PascalCase -> public
camelCase -> private / protected

### Compilation

## DLL

- P/E : Portable Executable
  - Metadata : Information about the types, members, references, etc.
  - IL : Intermediate Language (CIL : Common Intermediate Language)

## EXE

- Bootstrap : small native code to load the CLR
- P/E : Portable Executable
  - Metadata : Information about the types, members, references, etc.
  - IL : Intermediate Language (CIL : Common Intermediate Language)

CLI : Common Language Infrastructure
CLR : Common Language Runtime
JIT : Just In Time Compiler
CLS : Common Language Specification

## Overriding

il faut que la méthode soit virtual

## Methode d'extension

Une espace de nom doit être importée avec using pour que la méthode d'extension soit visible. Ça permet d'ajouter des méthodes à des types existants sans les modifier.
Exemple d'utilisation : une méthode d'extension pour ajouter une méthode `IsEven` à la classe `int`.

```csharp
public static class IntExtensions
{
    public static bool IsEven(this int number)
    {
        return number % 2 == 0;
    }
}
```

### CLI

#### Solutions

Créer une solution :

```bash
dotnet new sln -n SolutionAnthony
```

Lister les projets dans la solution :

```bash
dotnet sln list
```

Retirer le projet de la solution :

```bash
dotnet sln remove MonProjet/MonProjet.csproj
```

Ajouter plusieurs projets:

```bash
dotnet new classlib -n MaBibliotheque
dotnet sln MaSolution.sln add MaBibliotheque/MaBibliotheque.csproj
```

Puis créer une référence entre projets : (cela d'utiliser les classes entre les projets, il faudra aussi ajouter le using)

```bash
dotnet add MonProjet/MonProjet.csproj reference MaBibliotheque/MaBibliotheque.csproj
```

Pour lancer le projet :

```bash
dotnet run --project MonProjet
```

Installer un workload (un workload est comme un SDK mais pour des types d'applications spécifiques, par exemple MAUI pour les applications mobiles et desktop) :

```bash
dotnet workload install maui
```

Verifier les workloads installés :

```bash
dotnet workload list
```

Créer un projet MAUI :

```bash
dotnet new maui -n MonProjetMaui
```

#### Restore

Restaurer les dépendances :

```bash
dotnet restore MonProjet/MonProjet.csproj
```

ça permet de télécharger les packages NuGet nécessaires au projet.

#### Lancer un projet

Lancer en dev :

```bash
  dotnet run --project IHM/IHM.csproj -f net9.0-maccatalyst

  dotnet run --project IHM/IHM.csproj  -f net9.0-ios /p:Platform=iPhoneSimulator
```

### Build

- Build / Run sur iOS Simulator

```bash
dotnet build IHM/IHM.csproj -f net9.0-ios /p:Platform=iPhoneSimulator /p:Configuration=Debug
dotnet run --project IHM/IHM.csproj -f net9.0-ios /p:Platform=iPhoneSimulator
```

Ouvre l’app dans le simulateur iPhone sur Mac.

- Build pour iOS Device (Release)

```bash
dotnet publish IHM/IHM.csproj -f net9.0-ios /p:Platform=iPhone /p:Configuration=Release
```

Génère un .app signé pour device.
Pour distribution App Store / TestFlight, il faut un compte Apple Developer.

- Build pour macOS (Release)

```bash
dotnet publish IHM/IHM.csproj -c Release -f net9.0-maccatalyst /p:RuntimeIdentifier=osx-x64
```

Pour Apple Silicon :

```bash
dotnet publish IHM/IHM.csproj -c Release -f net9.0-maccatalyst /p:RuntimeIdentifier=osx-arm64
```
