using System.ComponentModel.DataAnnotations;

namespace GestaoFilmesAPI.Data.DTOs.CinemaDTO
{
    public class UpdateCinemaDTO
    {
        [Required(ErrorMessage = "O nome do cinema é obrigatório")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string NomeCinema { get; set; }
    }
}
