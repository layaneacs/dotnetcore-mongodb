using System.Linq;
using System.Collections.Generic;
using MongoDB.Driver;

using dotnetcore.mongo.Models;
using dotnetcore.mongo.Database;

namespace dotnetcore.mongo.Services
{
    public class ProdutoService
    {
        private readonly IMongoCollection<Produto> _produtos;
        
        public ProdutoService(IMongoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.DatabaseName);

            _produtos = db.GetCollection<Produto>(settings.ProdutosCollectionName);
        }
    }
}