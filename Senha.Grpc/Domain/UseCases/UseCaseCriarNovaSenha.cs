using Senha.Grpc.Domain.Entities;

namespace Senha.Grpc.Domain.UseCases
{
    public class UseCaseCriarNovaSenha
    {
        public static SenhaClass NovaSenha(string senhaClienteRef)
        {
            var retorno = new SenhaClass()
            {
                SenhaCliente = senhaClienteRef,
                SenhaClienteCifrada = senhaClienteRef.GetHashCode(),
                Status = Enums.ESenhaStatus.PRIMEIRA_SENHA
            };
            return retorno;
        }

    }
}
