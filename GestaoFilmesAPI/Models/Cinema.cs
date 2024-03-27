using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoFilmesAPI.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int IdCinema { get; set; }

        [Required(ErrorMessage = "O nome do cinema é obrigatório")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string NomeCinema { get; set; }

        [ForeignKey("Endereco")]
        public int IdEndereco { get; set; }
        public virtual Endereco Endereco { get; set; }

        public virtual ICollection<Sessao> Sessoes { get; set; }
    }
}
