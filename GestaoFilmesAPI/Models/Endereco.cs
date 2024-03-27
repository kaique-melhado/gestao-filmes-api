using System.ComponentModel.DataAnnotations;

namespace GestaoFilmesAPI.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int IdEndereco { get; set; }

        [Required(ErrorMessage = "O logradouro do endereço é obrigatório")]
        public string Logradouro { get; set; }

        public int Numero { get; set; }

        public virtual Cinema Cinema { get; set; }
    }
}
