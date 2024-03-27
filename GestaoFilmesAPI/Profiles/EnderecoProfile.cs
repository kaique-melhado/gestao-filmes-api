using AutoMapper;
using GestaoFilmesAPI.Data.DTOs.EnderecoDTO;
using GestaoFilmesAPI.Models;

namespace GestaoFilmesAPI.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDTO, Endereco>();
            CreateMap<Endereco, ReadEnderecoDTO>();
            CreateMap<UpdateEnderecoDTO, Endereco>();
        }
    }
}
