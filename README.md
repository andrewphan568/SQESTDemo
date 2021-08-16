# SQESTDemo
The simple app is motivated based on S-QEST’s Take-Home Coding Challenge. It implements the simple CRUD workflow from backend to frontend and has a few Unit Tests.

There are still some works that need to work on the front end ( testing, clean up code,fix bugs,...), but it is good for a demo purpose.
## Technologies
The project follows the Clean Architecture (https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
### Backend
-	NET 5.0
-	Entity Framework 
-	Microsoft SQL Server Express
-	MediatR & CQRS (https://letienthanh0212.medium.com/cqrs-and-mediator-in-net-core-project-c0b477eab6e9)
### Frontend
-	ReactTS
-	MobX  (https://mobx.js.org/README.html) as state management instead of the famous Redux-Saga library.
-	Semantic UI React (https://react.semantic-ui.com/) mainly use for theming.
-	React Router (https://reactrouter.com/) to navigate components.

### Testing
There are some simple Unit Tests on the SQEST.Tests project. I use xUnit as the unit test framework for .NET.

## Dependencies
-	NodeJs
-	Dotnet Core SDK
-	 **Microsoft SQL Server Express**. The database name is configured in API/appsettings.Development.json
-	Visual Studio 2019 or Visual Studio Code. 

## Running the App in Visual Studio Code
```shell
cd API
dotnet run 
cd ..
cd client-app
npm start
```

### Entity Framework Migrations
Migrations and other database related code should be in the Persistence project.
****
For example, add the initial migration 
```shell
cd Persistence
dotnet ef migrations add AddedSomeTables --startup-project ..\API --context DataContext
```
For example, remove the lasted migration 
```shell
cd Persistence
dotnet ef migrations remove --startup-project ..\API --context DataContext
```





