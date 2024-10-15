using _3kt;
using System.Collections.Generic;
using System;
using Bogus;
using Microsoft.Extensions.Primitives;

class Program
{
    static void Main(string[] args)
    {
        var faker = new Faker();

        var people = new List<Person>();
        for (int i = 0; i < 10; i++)
        {
            var person = new Person
            {
                Name = faker.Name.FirstName() + " " + faker.Name.LastName(),
                Email = faker.Internet.Email(),
                Age = faker.Random.Number(1, 100)
            };
            people.Add(person);
            Console.WriteLine(person.Name + " " + person.Email + " " + person.Age);
        }

        

        string databasePath = "mydatabase.db";
        string tableName = "People";
        string columns = "Name TEXT, Email TEXT, Age INTEGER";
        string columnsINSERT = "Name, Email, Age";


        DatabaseDB database = new DatabaseDB(databasePath);
      
        database.CreateTable(tableName, columns);
        foreach (var pers in people)
        {
            if (pers.Age >= 14)
            {
                string values = $" '{pers.Name}' , '{pers.Email}' , {pers.Age}";
                database.InsertData(tableName, columnsINSERT, values);
            }
            else { Console.WriteLine("маленький еще"); }
        }
        Console.WriteLine("ура, все!!!");
        Console.ReadLine();
    }
}

public class Person
{
    public string Name { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
}