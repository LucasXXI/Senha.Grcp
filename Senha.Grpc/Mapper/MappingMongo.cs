using Senha.Grpc.Domain.Entities;
using Senha.Grpc.Protos;

namespace Senha.Grpc.Mapper
{
    public static class MappingMongo
    {
        public static SenhaModel MongoToProto(SenhaClass MongoObj)
        {
            var retorno = new SenhaModel
            {
                Id = MongoObj.Id,
                SenhaCliente = MongoObj.SenhaCliente,
                Status = (SenhaModel.Types.EnumStatus)MongoObj.Status,
            };
            return retorno;
        }
    }
}
