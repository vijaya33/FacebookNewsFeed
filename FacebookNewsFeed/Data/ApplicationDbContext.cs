using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using System.Xml.Linq;
using FacebookNewsFeed.Models;

namespace FacebookNewsFeed.Data
{
    public class ApplicationDbContext
    {
        private readonly IMongoDatabase _database;

        public ApplicationDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
            _database = client.GetDatabase("FacebookCloneDb");
        }
        public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
        public IMongoCollection<Post> Posts => _database.GetCollection<Post>("Posts");
        public IMongoCollection<Comment> Comments => _database.GetCollection<Comment>("Comments");
        public IMongoCollection<Like> Likes => _database.GetCollection<Like>("Likes");
    }
}

