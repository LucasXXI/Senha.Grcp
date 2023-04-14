using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Senha.Grpc.Adapter.Mongo.Entities;
using Senha.Grpc.Domain.Entities;
using Senha.Grpc.Domain.UseCases;
using Senha.Grpc.Protos;

namespace Senha.Grpc.Adapter.Mongo.Services
{
    public class SenhaMongoService
    {
        private readonly IMongoCollection<SenhaClass> _senhaCollection;

        public SenhaMongoService(IOptions<SenhaDatabaseConfig> databaseConfig) 
        {
            var mongoClient = new MongoClient(databaseConfig.Value.ConnectionString);

            var mongoDatabase =  mongoClient.GetDatabase(databaseConfig.Value.DatabaseName);

            _senhaCollection = mongoDatabase.GetCollection<SenhaClass>(databaseConfig.Value.SenhaCollectionName);
        }

        public async Task<List<SenhaClass>> GetSenhasAsync()
            => await _senhaCollection.Find(_ => true).ToListAsync();

        public async Task<SenhaClass?> GetSenhaAsync(string id) 
            => await _senhaCollection.Find( x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateSenhaAsync(UseCaseCriarNovaSenha criarNovaSenha) =>
            await _senhaCollection.InsertOneAsync(criarNovaSenha.NovaSenha(3));

        public async Task UpdateAsync(string id, SenhaClass senhaAtualizada) =>
            await _senhaCollection.ReplaceOneAsync(x => x.Id == id, senhaAtualizada);

        public async Task RemoveAsync(string id) =>
           await _senhaCollection.DeleteOneAsync(x => x.Id == id);

    }
}
