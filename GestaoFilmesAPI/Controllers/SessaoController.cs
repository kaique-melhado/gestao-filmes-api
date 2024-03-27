using AutoMapper;
using GestaoFilmesAPI.Data.DTOs.SessaoDTO;
using GestaoFilmesAPI.Data;
using GestaoFilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoFilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : Controller
    {
        private GestaoFilmesContext _context;
        private IMapper _mapper;

        public SessaoController(GestaoFilmesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Busca uma lista de sessoes no banco de dados, podendo delimitar a quantidade de registros ou até mesmo pular registros
        /// </summary>
        /// <param name="skip">Objeto com o campo necessário para pular a quantidade de registros</param>
        /// <param name="take">Objeto com o campo necessário para delimitar a quantidade de registros</param>
        /// <returns>IEnumerable de ReadSessaoDTO</returns>
        /// <response code="200">Caso a busca seja feita com sucesso</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public  async Task<IEnumerable<ReadSessaoDTO>> ObterSessoes([FromQuery] int skip = 0, int take = 10)
        {
            var lstSessoes = await _context.Sessoes.AsNoTracking().Skip(skip).Take(take).ToListAsync();
            return _mapper.Map<List<ReadSessaoDTO>>(lstSessoes);
        }

        /// <summary>
        /// Busca uma sessao específica no banco de dados, através do idFilme e idCinema
        /// </summary>
        /// <param name="idFilme">Objeto com o campo necessário para filtrar o filme</param>
        /// <param name="idCinema">Objeto com o campo necessário para filtrar o cinema</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a busca seja feita com sucesso</response>
        [HttpGet("{idFilme}/{idCinema}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterSessaoPorId(int idFilme, int idCinema)
        {
            var sessao = await _context.Sessoes.FirstOrDefaultAsync(x => x.IdFilme == idFilme && x.IdCinema == idCinema);

            if (sessao == null)
                return NotFound();

            var sessaoDTO = _mapper.Map<ReadSessaoDTO>(sessao);

            return Ok(sessaoDTO);
        }

        /// <summary>
        /// Adiciona uma sessao ao banco de dados
        /// </summary>
        /// <param name="sessaoDTO">Objeto com os campos necessários para criação de uma sessao</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CadastrarSessao([FromBody] CreateSessaoDTO sessaoDTO)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDTO);

            await _context.Sessoes.AddAsync(sessao);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObterSessaoPorId), new { idFilme = sessao.IdFilme, idCinema = sessao.IdCinema }, sessao);
        }

        /// <summary>
        /// Deleta uma sessao do banco de dados
        /// </summary>
        /// <param name="idFilme">Objeto com o campo necessário para filtrar o filme</param>
        /// <param name="idCinema">Objeto com o campo necessário para filtrar o cinema</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a deleção seja feita com sucesso</response>
        [HttpDelete("{idFilme}/{idCinema}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeletarSessao(int idFilme, int idCinema)
        {
            var sessao = _context.Sessoes.FirstOrDefaultAsync(x => x.IdFilme == idFilme && x.IdCinema == idCinema);

            if (sessao == null)
                return NotFound();

            _context.Remove(sessao);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
