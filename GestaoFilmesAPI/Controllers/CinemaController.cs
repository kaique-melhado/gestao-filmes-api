using AutoMapper;
using GestaoFilmesAPI.Data;
using GestaoFilmesAPI.Data.DTOs.CinemaDTO;
using GestaoFilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoFilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private GestaoFilmesContext _context;
        private IMapper _mapper;

        public CinemaController(GestaoFilmesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Busca uma lista de cinemas no banco de dados, podendo delimitar a quantidade de registros ou até mesmo pular registros
        /// </summary>
        /// <param name="skip">Objeto com o campo necessário para pular a quantidade de registros</param>
        /// <param name="take">Objeto com o campo necessário para delimitar a quantidade de registros</param>
        /// <returns>IEnumerable de ReadCinemaDTO</returns>
        /// <response code="200">Caso a busca seja feita com sucesso</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<ReadCinemaDTO>> ObterCinema([FromQuery] int skip = 0, int take = 10)
        {
            return _mapper.Map<List<ReadCinemaDTO>>(await _context.Cinemas.AsNoTracking().Skip(skip).Take(take).ToListAsync());
        }

        /// <summary>
        /// Busca um cinema específico no banco de dados, através do idCinema
        /// </summary>
        /// <param name="idCinema">Objeto com o campo necessário para filtrar o cinema</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a busca seja feita com sucesso</response>
        [HttpGet("{idCinema}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterCinemaPorId(int idCinema)
        {
            var cinema = await _context.Cinemas.FirstOrDefaultAsync(x => x.IdCinema == idCinema);

            if (cinema == null)
                return NotFound();

            var cinemaDTO = _mapper.Map<ReadCinemaDTO>(cinema);

            return Ok(cinemaDTO);
        }

        /// <summary>
        /// Adiciona um cinema ao banco de dados
        /// </summary>
        /// <param name="cinemaDTO">Objeto com os campos necessários para criação de um cinema</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CadastrarCinema([FromBody] CreateCinemaDTO cinemaDTO)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDTO);

            await _context.Cinemas.AddAsync(cinema);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObterCinemaPorId), new { id = cinema.IdCinema }, cinema);
        }

        /// <summary>
        /// Atualiza todos os dados de um cinema no banco de dados
        /// </summary>
        /// <param name="idCinema">Objeto com o campo necessário para filtrar o cinema</param>
        /// <param name="cinemaDTO">Objeto com os campos necessários para atualização do cinema</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a tualização seja feita com sucesso</response>
        [HttpPut("{idCinema}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> AtualizarCinema(int idCinema, [FromBody] UpdateCinemaDTO cinemaDTO)
        {
            var cinema = await _context.Cinemas.FirstOrDefaultAsync(x => x.IdCinema == idCinema);

            if (cinema == null)
                return NotFound();

            _mapper.Map(cinemaDTO, cinema);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Deleta um cinema do banco de dados
        /// </summary>
        /// <param name="idCinema">Objeto com o campo necessário para filtrar o cinema</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a deleção seja feita com sucesso</response>
        [HttpDelete("{idCinema}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeletarCinema(int idCinema)
        {
            var cinema = await _context.Cinemas.FirstOrDefaultAsync(x => x.IdCinema == idCinema);

            if (cinema == null)
                return NotFound();

            _context.Remove(cinema);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
