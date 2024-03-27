using AutoMapper;
using GestaoFilmesAPI.Data.DTOs.FilmeDTO;
using GestaoFilmesAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using GestaoFilmesAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace GestaoFilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private GestaoFilmesContext _context;
        private IMapper _mapper;

        public FilmeController(GestaoFilmesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Busca uma lista de filmes no banco de dados, podendo delimitar a quantidade de registros ou até mesmo pular registros
        /// </summary>
        /// <param name="skip">Objeto com o campo necessário para pular a quantidade de registros</param>
        /// <param name="take">Objeto com o campo necessário para delimitar a quantidade de registros</param>
        /// <returns>IEnumerable de ReadFilmeDTO</returns>
        /// <response code="200">Caso a busca seja feita com sucesso</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<ReadFilmeDTO>> ObterFilme([FromQuery] int skip = 0, int take = 10)
        {
            return _mapper.Map<List<ReadFilmeDTO>>(await _context.Filmes.AsNoTracking().Skip(skip).Take(take).ToListAsync());
        }

        /// <summary>
        /// Busca um filme específico no banco de dados, através do idFilme
        /// </summary>
        /// <param name="idFilme">Objeto com o campo necessário para filtrar o filme</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a busca seja feita com sucesso</response>
        [HttpGet("{idFilme}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterFilmePorId(int idFilme)
        {
            var filme = await _context.Filmes.FirstOrDefaultAsync(x => x.IdFilme == idFilme);

            if (filme == null)
                return NotFound();

            var filmeDTO = _mapper.Map<ReadFilmeDTO>(filme);

            return Ok(filmeDTO);
        }

        /// <summary>
        /// Adiciona um filme ao banco de dados
        /// </summary>
        /// <param name="filmeDTO">Objeto com os campos necessários para criação de um filme</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CadastrarFilme([FromBody] CreateFilmeDTO filmeDTO)
        {
            Filme filme = _mapper.Map<Filme>(filmeDTO);

            await _context.Filmes.AddAsync(filme);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObterFilmePorId), new { id = filme.IdFilme }, filme);
        }

        /// <summary>
        /// Atualiza todos os dados de um filme no banco de dados
        /// </summary>
        /// <param name="idFilme">Objeto com o campo necessário para filtrar o filme</param>
        /// <param name="filmeDTO">Objeto com os campos necessários para atualização do filme</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a tualização seja feita com sucesso</response>
        [HttpPut("{idFilme}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> AtualizarFilme(int idFilme, [FromBody] UpdateFilmeDTO filmeDTO)
        {
            var filme = await _context.Filmes.FirstOrDefaultAsync(x => x.IdFilme == idFilme);

            if (filme == null)
                return NotFound();

            _mapper.Map(filmeDTO, filme);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Atualiza apenas os dados necessários de um filme no banco de dados
        /// </summary>
        /// <param name="idFilme">Objeto com o campo necessário para filtrar o filme</param>
        /// <param name="patch">Objeto com os campos necessários para atualização do filme</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a tualização seja feita com sucesso</response>
        [HttpPatch("{idFilme}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> AtualizarFilmeParcial(int idFilme, [FromBody] JsonPatchDocument<UpdateFilmeDTO> patch)
        {
            var filme = _context.Filmes.FirstOrDefaultAsync(x => x.IdFilme == idFilme);

            if (filme == null)
                return NotFound();

            var filmeUpdateDTO = _mapper.Map<UpdateFilmeDTO>(filme);

            patch.ApplyTo(filmeUpdateDTO, ModelState);

            if (!TryValidateModel(filmeUpdateDTO))
                return ValidationProblem(ModelState);

            await _mapper.Map(filmeUpdateDTO, filme);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Deleta um filme do banco de dados
        /// </summary>
        /// <param name="idFilme">Objeto com o campo necessário para filtrar o filme</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a deleção seja feita com sucesso</response>
        [HttpDelete("{idFilme}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeletarFilme(int idFilme)
        {
            var filme = await _context.Filmes.FirstOrDefaultAsync(x => x.IdFilme == idFilme);

            if (filme == null)
                return NotFound();

            _context.Remove(filme);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
