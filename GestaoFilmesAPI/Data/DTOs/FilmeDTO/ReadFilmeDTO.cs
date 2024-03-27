using GestaoFilmesAPI.Data.DTOs.SessaoDTO;
using GestaoFilmesAPI.Models;

namespace GestaoFilmesAPI.Data.DTOs.FilmeDTO
{
    public class ReadFilmeDTO
    {
        public string Titulo { get; set; }

        public string Genero { get; set; }

        public int Duracao { get; set; }
        public DateTime DataConsulta { get; set; } = DateTime.Now;
        public ICollection<ReadSessaoDTO> Sessoes { get; set; }
    }
}
