using System;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

namespace MongoDBDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoClient mongoClient = new MongoClient("mongodb://localhost:27017");
            var db = mongoClient.GetDatabase("countriesdb");
            var collection = db.GetCollection<BsonDocument>("countries");
            var filter = Builders<BsonDocument>.Filter.Eq("Name", "Sweden");
            BsonDocument doc = collection.Find<BsonDocument>(filter).FirstOrDefault();
            Country sweden = BsonSerializer.Deserialize<Country>(doc);

            Country norway = new Country
            {
                _id = new ObjectId(),
                Exists = true,
                Name = "norway",
                Population = 4000000
            };

            //Country norway = new Country {
            //    _id = 2,
            //    Exists = true,
            //    Name = "norway",
            //    Population = 4000000
            //};

            collection.InsertOne(norway.ToBsonDocument());










            //var filter = Builders<BsonDocument>.Filter.Eq("class", "Mammalia");
            //var carnivoraFilter = Builders<BsonDocument>.Filter.Eq("color" , "black");
            //var andFilter = Builders<BsonDocument>.Filter.And(filter, carnivoraFilter);
            //var found = collection.Find(andFilter);
            //// Använd .ToEnumerable() för att iterera över resultatet.
            //foreach (var x in found.ToEnumerable())
            //{
            //    Console.WriteLine(x.ToString());
            //}
        }
    }
}
