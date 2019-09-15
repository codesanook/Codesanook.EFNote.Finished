# Codesanook.EFNote
Just another web-based note app implemented by Entity Framework and C#

## Minimalist domain driven design project structure

### Codesanook.EFNote.Core contains (.NET Standard)
- Entity, Value object
- Business logic and Services
- Interface of repository
- Interface of email service

### Codesanook.EFNote.Infrastructure (.NET Standard)
- EF mapping and configuration
- Email
- Logging
- Implementation of repository
- Autofac configuration

### Codesanook.EFNote.Utility (.NET Standard)
- Utility or help classes that can be used in all projects

### Codesanook.EFNote.MvcWeb
- .NET Framework front-end web project

### Codesanook.EFNote.MvcCoreWeb
- .NET Core front-end web project

### Codesanook.EFNote.MvcCoreWeb
- .NET Core front-end web project

### Codesanook.EFNote.ConsoleApp
- .NET Core front-end console project

## Libraries/Framework dependencies
- EntityFramework 6.3.0-preview9-19423-04
- Bootstrap 4
