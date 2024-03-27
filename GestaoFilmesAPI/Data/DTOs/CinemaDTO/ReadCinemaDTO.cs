using GestaoFilmesAPI.Data.DTOs.EnderecoDTO;
using GestaoFilmesAPI.Data.DTOs.SessaoDTO;

namespace GestaoFilmesAPI.Data.DTOs.CinemaDTO
{
    public class ReadCinemaDTO
    {
        public int IdCinema { get; set; }
        public string NomeCinema { get; set; }
        public ReadEnderecoDTO Endereco { get; set; }

        public ICollection<ReadSessaoDTO> Sessoes { get; set; }
    }
}
