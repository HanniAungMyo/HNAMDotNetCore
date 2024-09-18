// See https://aka.ms/new-console-template for more information
using HNAMDotNetCore.ConsoleApp;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");
//Console.ReadLine();

//Console.ReadKey();
//md =MarkDown

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Create();
//adoDotNetExample.Delete();

DapperExample dapper=new DapperExample();
dapper.Delete(12);
Console.ReadKey();


