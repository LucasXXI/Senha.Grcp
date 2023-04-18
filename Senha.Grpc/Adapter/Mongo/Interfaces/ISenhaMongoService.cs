using Senha.Grpc.Domain.Entities;

namespace Senha.Grpc.Adapter.Mongo.Interfaces
{
    public interface ISenhaMongoService
    {
        Task<List<SenhaClass>> GetSenhasAsync();
        Task<SenhaClass?> GetSenhaAsync(string id);
        Task<SenhaClass> CreateSenhaAsync(int idCliente);
        Task UpdateAsync(SenhaClass senhaAtualizada);
        Task RemoveAsync(string id);
    }
}
