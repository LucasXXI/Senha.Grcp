using Senha.Grpc.Domain.Entities;
using Senha.Grpc.Domain.Enums;
using Senha.Grpc.Protos;

namespace Senha.Grpc.Mapper
{
    public static class MappingMongo
    {
        public static SenhaModel MongoToProto(SenhaClass MongoObj)
        {
            return new SenhaModel
            {
                Id = MongoObj.Id,
                IdCliente = MongoObj.IdCliente,
                SenhaCliente = MongoObj.SenhaCliente,
                SenhaClienteCifrada = MongoObj.SenhaClienteCifrada,
                Status = (int)MongoObj.Status,
            };
        }

        public static SenhaClass ProtoToClass(SenhaModel ProtoObj)
        {
            return new SenhaClass
            {
                Id = ProtoObj.Id,
                IdCliente = ProtoObj.IdCliente,
                SenhaCliente = ProtoObj.SenhaCliente,
                SenhaClienteCifrada = ProtoObj.SenhaClienteCifrada,
                Status = (ESenhaStatus)ProtoObj.Status
            };
            
        }
    }
}
