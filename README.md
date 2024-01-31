A fully functional API built with ASP.NET Core Web API. 
This API is built for fun and about the Yu-Gi-Oh card game in which you can create:

- Owners
- Cards
- Decks
- Reviews
- Reviewers
- Types

The API end points are built around models which are based on a database schema.
![afbeelding](https://github.com/hamidquayomi/YGOReviewHub/assets/58644587/43e32e15-6963-4914-8250-50c61475f574)

|How to set it up|

You need a code editor prefer VisualStudio and SQL server

Create a new database in your SQL server 

When you download this repo and open it in a code editor make sure you use your own DefaultConnection from your SQL server. You can find this in the AppsettingsJson file.
It's supposed to look like this => "Data Source=DESKTOP-1CT5PMO\\SQLEXPRESS;Initial Catalog=ygoreviewhub;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"

Once your SQL server is connected you can go ahead and run "Add-Migration InitialCreate" in the Package Manager Console of the editor. 

If that went with no error enter "Update-Database" The tables should be added in SQL.
Next use my Seed.CS file to generate random data to seed the database. Feel free to use your own data.

Go ahead and open the terminal again in the editor, make sure you cd into .\YGOReviewHub\ and run the "dotnet run seeddata" command. Now the tables should contain rows of data.

If you run the code you should be greeted with swagger, and in swagger are the 6 models we created. 

=> Troubleshooting <=

If you cant get the code to run 
Make sure you have the NuGet packages like
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Tools
- AutoMapper
- automapper dependency injection

- Make sure in your main project file this is set to false => < InvariantGlobalization > false < / InvariantGlobalization >

