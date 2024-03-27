using AutoMapper;
using GestaoFilmesAPI.Data.DTOs.CinemaDTO;
using GestaoFilmesAPI.Models;

namespace GestaoFilmesAPI.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDTO, Cinema>();
            CreateMap<UpdateCinemaDTO, Cinema>();
            CreateMap<Cinema, ReadCinemaDTO>()
                .ForMember(cinemaDTO => cinemaDTO.Endereco, opt => opt.MapFrom(cinema => cinema.Endereco))
                .ForMember(cinemaDTO => cinemaDTO.Sessoes, opt => opt.MapFrom(cinema => cinema.Sessoes));
        }
    }
}
