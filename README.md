# Codesanook.EFNote
Just another web-based note app implemented by Entity Framework and C#

## Minimalist domain driven design project structure :

### Codesanook.EFNote.Core contains (.NET Standard)
- Entity, Value object
- Business logic and Services
- Interface of repositories
- Interface of logging service

### Codesanook.EFNote.Infrastructure (.NET Standard)
- EF mapping and configuration
- Implementation of Email
- Implementation of Logging
- Implementation of repositories
- Autofac configuration

### Codesanook.EFNote.Api (.NET Standard)
- Shared application service layer
- Consumed by console and web projects
- Service models
- Commands & Queries (CQRS)

### Codesanook.EFNote.Utilities (.NET Standard)
- Utilities or helper classes that can be used in all projects

### Codesanook.EFNote.MvcCoreWeb (.NET Core)
- .NET Core front-end web project

### Libraries/Framework dependencies
- EntityFramework 6.3.0-preview9-19423-04
- Bootstrap 4
- Font Awesome
- Webpack 4

### How to run the project
- Use SQL Sever Management Studio to execute create-dateabase.sql to create a database and table
- Open the project with Visual Studio 2019 preview which support both .NET Core 3.0
and .NET Framework 4.8
- Build the project
- Launch Codesanook.EFNote.MvcCoreWeb

### Software and tools 
- Visual Studio 2019 Preview https://visualstudio.microsoft.com/preview/ (ตรงนี้ admin ก็ต้องการจะใช้ VS code ครับ แต่ประสบการณ์ในการ debugging .NET App ยังสู้ VS Code ไม่ได้จริงๆ 
- .NET Core 3.0 (optional ควรมากับ VS 2019 preview แล้ว) https://dotnet.microsoft.com/download/dotnet-core/3.0 
- .NET Framwework 4.8 https://dotnet.microsoft.com/download/thank-you/net48-developer-pack
- SQL Sever 2017 Developer edition (install as default instance because we want to connect SQL server as localhost) https://go.microsoft.com/fwlink/?linkid=853016
- SQL Sever management studio SSMS 18.3
- https://go.microsoft.com/fwlink/?linkid=2104251
- Visual Studio plugin ZenCoding สำหรับใช้ Emmet HTML (https://marketplace.visualstudio.com/items?itemName=MadsKristensen.ZenCoding)
- Microsoft Code Analysis 2019 https://marketplace.visualstudio.com/items?itemName=VisualStudioPlatformTeam.MicrosoftCodeAnalysis2019
- Chocolatey, a software installer for Windows OS like apt-get install ( Install with your CMD as administrator, https://chocolatey.org/docs/installation#install-with-cmdexe)
- Node.js (I suggest to install with chocolatey) choco install nodejs
- Git (I suggest to install with chocolatey) choco install git
- PowerShell 5 Make sure if you are using at least PowerShell 5, launch PowerShell and use this command for checking $PSVersionTable
