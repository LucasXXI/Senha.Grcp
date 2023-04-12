using Senha.Grpc.Domain.Enums;

namespace Senha.Grpc.Domain.Entities
{
    public class Senha
    {
        public string Id { get; set; }
        public string SenhaCliente { get; set; }
        public string SenhaClienteCifrada { get; set; }
        public ESenhaStatus Status { get; set; } 
    }
}
