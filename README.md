# HNAMDotNetCore

C# .NET

C# Language
.NET 

Console App
Windows Forms
ASP.NET Core Web API
ASP.NET Core Web MVC
Blazor Web Assembly
Blazor Web Server

.NET framework (1, 2, 3, 3.5, 4, 4.5, 4.6, 4.7, 4.8) windows
.NET Core (1, 2, 2.2, 3, 3.1) vs2019, vs2022 - windows, linux, macos
.NET (5 - vs2019, 6 - vs2022, 7, 8 - windows, linux, macos

vscode
visual studio 2022 

windows

UI + Business Logic + Data Access => Database

Kpay

Mobile No => Transfer 

Mobile No Check
10000

SLH => Collin

10000 => 0

-5000 => +5000

Bank + 5000

--sql

SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
	  
  FROM [dbo].[Tbl_Blog]

GO
select * from Tbl_Blog where DeleteFlag=0


Update Tbl_Blog set DeleteFlag=0
Update Tbl_Blog set DeleteFlag=1 where BlogId=1

Delete from Tbl_Blog Where BlogId=13

dotnet ef dbcontext scaffold "Server=LAPTOP\SQLSERVER;Database=DotNet;User Id=sa;Password=sa@123;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c AppDbContext -f