# Introduction

There are two projects in this repository, first one is aspnet-core, this is the backend in C# .NET Core and angular which is the frontend project

# Requirements

- Visual Studio 2019
- NodeJS, npm
- Visual Studio Code (optional)

# How to Install

### To start the backend, first open up the project in Visual Studio 2019

- Set **RandomNumbersAngular.Web.Host** project as startup project.
- Build solution.
- Check the **connection string** in the **appsettings.json** file of the Web.Host project, change it if you need to.
- Open Package Manager Console, set **RandomNumbersAngular.EntityFrameworkCore** as default project.
- Run command **Update-Database**.
- Debug project.

### To start the frontend

- In the project directory open command prompt.
- Run **npm install** command.
- Run **ng serve** command.
- Browse **http://localhost:4200** in any web browser.

# After Install

Manually insert records into the **matches** Table
*example: INSERT INTO [dbo].[matches]
           ([ExpiryDate], [CreationTime])
     VALUES
           (GETDATE()+1, CURRENT_TIMESTAMP)*
           
Use **GETDATE()+#** to add or subtract days
