using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Senha.Grpc.Adapter.Mongo.Entities;
using Senha.Grpc.Adapter.Mongo.NovaPasta;
using Senha.Grpc.Domain.Entities;
using Senha.Grpc.Domain.UseCases;
using Senha.Grpc.Protos;
using System.Text.Json;

namespace Senha.Grpc.Adapter.Mongo.Services
{
    public class SenhaMongoService : ISenhaMongoService
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

        public async Task<SenhaClass> CreateSenhaAsync(int idClienteRef) 
        {
            var criarNovaSenha = new UseCaseCriarNovaSenha();
            var a = criarNovaSenha.NovaSenha(idClienteRef);

            try
            {
                await _senhaCollection.InsertOneAsync(a);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            return a;
        }

        public async Task UpdateAsync(SenhaClass senhaAtualizada)
        {
            try
            {
                await _senhaCollection.ReplaceOneAsync(x => x.Id == senhaAtualizada.Id, senhaAtualizada);
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task RemoveAsync(string id)
        {
            try
            {
                await _senhaCollection.DeleteOneAsync(x => x.Id == id);
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
