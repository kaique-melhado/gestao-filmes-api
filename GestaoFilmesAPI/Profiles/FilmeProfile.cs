using AutoMapper;
using GestaoFilmesAPI.Data.DTOs.FilmeDTO;
using GestaoFilmesAPI.Models;

namespace GestaoFilmesAPI.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDTO, Filme>();
            CreateMap<UpdateFilmeDTO, Filme>();
            CreateMap<Filme, UpdateFilmeDTO>();
            CreateMap<Filme, ReadFilmeDTO>()
                .ForMember(filmeDTO => filmeDTO.Sessoes, opt => opt.MapFrom(filme => filme.Sessoes));
        }
    }
}
