﻿namespace MongoAndCSharp
{
    using System;
    using System.Collections.Generic;
    using MongoDB.Bson;
    using MongoDB.Driver;

    class Program
    {
        static void Main(string[] args)
        {
            // CRUD OPERATIONS
            // CREATE
            CreateMongoWithBsonDocument();
            CreateMongoWithClass();
            CreateMongoManyWithBsonDocument();
            CreateMongoManyWithClass();

            Console.WriteLine("The program has ended, press any key");
            Console.ReadKey();
        }

        static void CreateMongoWithBsonDocument()
        {
            var collection = new MongoDb<BsonDocument>().GetCollection("student");

            //Save Data In Mongo using a BsonDocument object
            var document = new BsonDocument
            {
                { "name", "Winston Churchill" },
                { "undergrad", true },
                { "units", "3" },
                { "classes", new BsonArray {
                    "English",
                    "Math",
                    "Spanish"
                }},
            };

            collection.InsertOne(document);

            Console.WriteLine("The record has been successfully created (scenario 1)");
        }

        static void CreateMongoWithClass()
        {
            var collection = new MongoDb<Student>().GetCollection("student");

            //Save Data In Mongo using a BsonDocument object
            var document = new Student
            {
                Id = ObjectId.GenerateNewId(),
                Name = "Keanu Reeves",
                Undergrad = false,
                Units = 3,
                Classes = new List<string>
                {
                    "History",
                    "Math",
                    "Chemistry"
                }
            };

            collection.InsertOne(document);

            Console.WriteLine("The record has been successfully created (scenario 2)");
        }

        static void CreateMongoManyWithBsonDocument()
        {
            var collection = new MongoDb<BsonDocument>().GetCollection("student");

            var documents = new List<BsonDocument>
            {
                new BsonDocument
                {
                    { "name", "Winston Churchill" },
                    { "undergrad", true },
                    { "units", "3" },
                    { "classes", new BsonArray {
                        "English",
                        "Math",
                        "Spanish"
                    }}
                },
                new BsonDocument
                {
                    { "name", "Winston Churchill" },
                    { "undergrad", true },
                    { "units", "3" },
                    { "classes", new BsonArray {
                        "English",
                        "Math",
                        "Spanish"
                    }}
                },
                new BsonDocument
                {
                    { "name", "Winston Churchill" },
                    { "undergrad", true },
                    { "units", "3" },
                    { "classes", new BsonArray {
                        "English",
                        "Math",
                        "Spanish"
                    }}
                },
            };

            collection.InsertMany(documents);

            Console.WriteLine("The records has been successfully created (scenario 3)");
        }

        static void CreateMongoManyWithClass()
        {
            var collection = new MongoDb<Student>().GetCollection("student");

            var documents = new List<Student>
            {
                new Student
                {
                    Id = ObjectId.GenerateNewId(),
                    Name = "Keanu Reeves",
                    Undergrad = false,
                    Units = 3,
                    Classes = new List<string>
                    {
                        "History",
                        "Math",
                        "Chemistry"
                    }
                },
                new Student
                {
                    Id = ObjectId.GenerateNewId(),
                    Name = "Keanu Reeves",
                    Undergrad = false,
                    Units = 3,
                    Classes = new List<string>
                    {
                        "History",
                        "Math",
                        "Chemistry"
                    }
                },
                new Student
                {
                    Id = ObjectId.GenerateNewId(),
                    Name = "Keanu Reeves",
                    Undergrad = false,
                    Units = 3,
                    Classes = new List<string>
                    {
                        "History",
                        "Math",
                        "Chemistry"
                    }
                }
            };

            collection.InsertMany(documents);

            Console.WriteLine("The records has been successfully created (scenario 4)");
        }


    }

    class MongoDb<T> where T : class
    {
        private readonly string dbServer = "mongodb://localhost:27017";
        private readonly string dbName = "myfirstdb";
        private readonly IMongoDatabase _db;

        public MongoDb()
        {
            MongoClient client = new MongoClient(dbServer);
            _db = client.GetDatabase(dbName);
        }

        public IMongoCollection<T> GetCollection(string collectionName)
        {
            return _db.GetCollection<T>(collectionName);
        }
    }

    class Student
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public bool Undergrad { get; set; }
        public int Units { get; set; }
        public List<string> Classes { get; set; }
    }
}
