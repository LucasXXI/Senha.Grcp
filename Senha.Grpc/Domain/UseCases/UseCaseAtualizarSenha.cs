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
                SenhaCliente = senhaClass.SenhaCliente,
                SenhaClienteCifrada = senhaClass.SenhaCliente.GetHashCode(),
                Status = Enums.ESenhaStatus.SENHA_ALTERADA
            };
        }
    }
}
