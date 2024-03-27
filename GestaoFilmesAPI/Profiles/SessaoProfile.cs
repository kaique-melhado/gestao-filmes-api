using AutoMapper;
using GestaoFilmesAPI.Data.DTOs.SessaoDTO;
using GestaoFilmesAPI.Models;

namespace GestaoFilmesAPI.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDTO, Sessao>();
            CreateMap<Sessao, ReadSessaoDTO>();
        }
    }
}
