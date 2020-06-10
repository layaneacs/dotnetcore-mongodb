namespace dotnetcore.mongo.Database
{
    public class MongoDatabaseSettings : IMongoDatabaseSettings
    {
        public string ProdutosCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IMongoDatabaseSettings
    {
        string ProdutosCollectionName { get; set;}
        string ConnectionString { get; set;}
        string DatabaseName { get; set;}
    }
}