using MongoDB.Bson;

namespace MongoDBDemo
{
    public class Country
    {
        public ObjectId _id { get; set; }
        public int Population { get; set; }
        public bool Exists { get; set; }
        public string Name{ get; set; }
    }
}