using Senha.Grpc.Domain.Entities;

namespace Senha.Grpc.Adapter.Mongo.Interfaces
{
    public interface ISenhaMongoService
    {
        Task<SenhaClass?> GetSenhaAsync(string id);
        Task<SenhaClass> CreateSenhaAsync(string senhaCliente);
        Task UpdateAsync(SenhaClass senhaAtualizada);
        Task RemoveAsync(string id);
    }
}
