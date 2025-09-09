# Dotnet - Fred. Colin

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
