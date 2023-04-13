using AutoMapper;
using Senha.Grpc.Domain.Entities;
using Senha.Grpc.Protos;

namespace Senha.Grpc.Mapper
{
    public class SenhaProfile : Profile
    {
        public SenhaProfile()
        {
            CreateMap<SenhaClass, SenhaModel>().ReverseMap();
        }   
    }
}