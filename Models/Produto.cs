using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace dotnetcore.mongo.Models
{
    public class Produto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Produto")]
        public string ProdutoNome { get; set; }
        public string Categoria { get; set; }
        public decimal Preco { get; set; }
    }
}