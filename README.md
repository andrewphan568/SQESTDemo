# SQESTDemo
The simple app is motivated by S-QEST’s Take-Home Coding Challenge. It implements the simple CRUD workflow from backend to frontend and has a few Unit Tests.

There are still many works that need to work on the front end ( implement other functions, testing, clean up codes,fix bugs,...), but it is OK for a demo purpose.


https://user-images.githubusercontent.com/72535251/129638105-cff39b8a-9846-4052-be0c-2b311cc90076.mp4



## Code-Challenge Files
- Question 1: Moisture Content object model, pls refer to the file MoistureContent.cs (dir SQEST\Domain\Moisture\MoistureContent.cs). Please note that the Moisture Content model is the [tag -finish_code_challege](https://github.com/andrewphan568/SQESTDemo/releases/tag/finish_code_challenge) is so much simple that the updated Moisture Content model in the lasted main branch. The extra field int the lasted model, just simply use to store the data from front-end form.
- Question 2: Calculates Material Wet Mass, Material Dry Mass and Water Content, pls refer to the file MoistureContentCalculator.cs ( dir SQEST\Application\Helpers\MoistureContentCalculator.cs)
- Question 3: unit tests, pls refer to the MoistureContentTest ( dir SQEST\SQEST.Tests\MoistureContentTest.cs)

## Technologies
The project follows the [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
### Backend
-	NET 5.0
-	Entity Framework 
-	Microsoft SQL Server Express
-	[MediatR & CQRS](https://letienthanh0212.medium.com/cqrs-and-mediator-in-net-core-project-c0b477eab6e9)
### Frontend
-	ReactTS
-	[MobX](https://mobx.js.org/README.html) as state management instead of the famous Redux-Saga library.
-	[React Semantic UI](https://react.semantic-ui.com/) mainly use for theming.
-	[React Router](https://reactrouter.com/) to navigate components.

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





