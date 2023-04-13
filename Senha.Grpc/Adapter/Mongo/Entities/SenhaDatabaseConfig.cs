namespace Senha.Grpc.Adapter.Mongo.Entities
{
    public class SenhaDatabaseConfig
    {
        public string SenhaCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
