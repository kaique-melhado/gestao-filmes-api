using System.ComponentModel.DataAnnotations;

namespace GestaoFilmesAPI.Data.DTOs.FilmeDTO
{
    public class UpdateFilmeDTO
    {
        [Required(ErrorMessage = "O título do filme é obrigatório")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O gênero do filme é obrigatório")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string Genero { get; set; }

        [Required]
        [Range(40, 600, ErrorMessage = "A duração do filme deve ser entre 40 e 600 minutos")]
        public int Duracao { get; set; }
    }
}
