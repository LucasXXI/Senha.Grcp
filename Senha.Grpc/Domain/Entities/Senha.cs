using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Senha.Grpc.Domain.Enums;

namespace Senha.Grpc.Domain.Entities
{
    public class SenhaClass
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("SenhaCliente")]
        public string SenhaCliente { get; set; } = null!;
        
        [BsonElement("SenhaClienteCifrada")]
        public string SenhaClienteCifrada { get; set; }

        [BsonElement("Status")]
        public ESenhaStatus Status { get; set; } 
    }
}
