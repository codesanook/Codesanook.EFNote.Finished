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

### Codesanook.EFNote.MvcWeb (.NET Standard)
- .NET Framework front-end web project

### Codesanook.EFNote.MvcCoreWeb
- .NET Core front-end web project

### Codesanook.EFNote.Utility
- Utility or help classes that can be used in all projects

## Libraries/framework dependencies
- Bootstrap 4
