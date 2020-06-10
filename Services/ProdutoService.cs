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


        // CRUD Produtos

        //-- Listar produtos
        public List<Produto> Get()
        {
            return _produtos.Find(produto => true).ToList();
        }

        //-- Obter Produto por id
        public Produto Get(string id)
        {
            return _produtos.Find<Produto>(produto => produto.Id == id).FirstOrDefault();
        }

        //-- Criar Produto
        public Produto Create(Produto produto){
            _produtos.InsertOne(produto);
            return produto;
        }

        //-- Update Produto
        public void Update(string id, Produto produtoIn)
        {
            _produtos.ReplaceOne(produto=> produto.Id == id , produtoIn);
        }

        //-- Remove
        public void Remove(Produto produtoIn)
        {
            _produtos.DeleteOne(produto => produto.Id == produtoIn.Id);
        }

        public void Remove(string id)
        {
            _produtos.DeleteOne(produto => produto.Id == id);
        }
            
        
    }    
}