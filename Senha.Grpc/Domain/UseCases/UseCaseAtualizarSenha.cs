using Senha.Grpc.Domain.Entities;

namespace Senha.Grpc.Domain.UseCases
{
    public class UseCaseAtualizarSenha
    {
        public static SenhaClass AtualizarSenha(SenhaClass senhaClass)
        {
            return new SenhaClass
            {
                Id = senhaClass.Id,
                IdCliente = senhaClass.IdCliente,
                SenhaCliente = senhaClass.SenhaCliente,
                SenhaClienteCifrada = senhaClass.SenhaClienteCifrada,
                Status = senhaClass.Status,
            };
        }
    }
}
