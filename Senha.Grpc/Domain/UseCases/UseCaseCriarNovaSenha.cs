using Senha.Grpc.Domain.Entities;

namespace Senha.Grpc.Domain.UseCases
{
    public class UseCaseCriarNovaSenha
    {
        public static SenhaClass NovaSenha(int idClientRef)
        {
            return new SenhaClass()
            {
                IdCliente = idClientRef,
                SenhaCliente = "AAAATeste",
                SenhaClienteCifrada = "AAAATESTEAAA123",
                Status = Enums.ESenhaStatus.PRIMEIRA_SENHA
            };
        }
        
    }
}
