using Grpc.Core;
using Senha.Grpc.Adapter.Mongo.Interfaces;
using Senha.Grpc.Domain.Entities;
using Senha.Grpc.Mapper;
using Senha.Grpc.Protos;

namespace Senha.Grpc.Services
{
    public class SenhaClienteService : SenhaService.SenhaServiceBase
    {
        private readonly ILogger<SenhaClienteService> _logger;
        private readonly ISenhaMongoService _mongoService;

        public SenhaClienteService(ILogger<SenhaClienteService> logger, ISenhaMongoService mongoService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mongoService = mongoService;
        }

        public override async Task<SenhaModel> GetSenha(GetSenhaRequest request, ServerCallContext context)
        {
            SenhaClass senhaRetorno = await _mongoService.GetSenhaAsync(request.Id);

            if (senhaRetorno is null)
            {
                throw new ArgumentNullException(nameof(senhaRetorno));
            }

            return MappingMongo.MongoToProto(senhaRetorno);
        }

        public override async Task<SenhaModel> CreateSenha(CreateSenhaRequest request, ServerCallContext context)
        {
            var novaSenha = await _mongoService.CreateSenhaAsync(request.SenhaCliente);

            return MappingMongo.MongoToProto(novaSenha);
        }

        public override async Task<SenhaModel> UpdateSenha(UpdateSenhaRequest request, ServerCallContext context)
        {
            var senhaToUpdate = new SenhaClass
            {
                Id = request.Senha.Id,
                SenhaCliente = request.Senha.SenhaCliente,
                Status = (Domain.Enums.ESenhaStatus)request.Senha.Status
            };

            await _mongoService.UpdateAsync(senhaToUpdate);

            return MappingMongo.MongoToProto(senhaToUpdate);
        }

        public override async Task<DeleteSenhaResponse> DeleteSenha(DeleteSenhaRequest request, ServerCallContext context)
        {
            await _mongoService.RemoveAsync(request.Id);

            return null;
        }
    }
}
