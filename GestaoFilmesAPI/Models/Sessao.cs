using System.ComponentModel.DataAnnotations;

namespace GestaoFilmesAPI.Models
{
    public class Sessao
    {
        public int? IdFilme { get; set; }
        public virtual Filme Filme { get; set; }

        public int? IdCinema { get; set; }
        public virtual Cinema Cinema { get; set; }
    }
}
