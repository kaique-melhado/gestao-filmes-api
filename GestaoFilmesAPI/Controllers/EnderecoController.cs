using AutoMapper;
using GestaoFilmesAPI.Data;
using GestaoFilmesAPI.Data.DTOs.EnderecoDTO;
using GestaoFilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoFilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : Controller
    {
        private GestaoFilmesContext _context;
        private IMapper _mapper;

        public EnderecoController(GestaoFilmesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Busca uma lista de endereços no banco de dados, podendo delimitar a quantidade de registros ou até mesmo pular registros
        /// </summary>
        /// <param name="skip">Objeto com o campo necessário para pular a quantidade de registros</param>
        /// <param name="take">Objeto com o campo necessário para delimitar a quantidade de registros</param>
        /// <returns>IEnumerable de ReadEnderecoDTO</returns>
        /// <response code="200">Caso a busca seja feita com sucesso</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<ReadEnderecoDTO>> ObterEndereco([FromQuery] int skip = 0, int take = 10)
        {
            return _mapper.Map<List<ReadEnderecoDTO>>(await _context.Enderecos.AsNoTracking().Skip(skip).Take(take).ToListAsync());
        }

        /// <summary>
        /// Busca um endereço específico no banco de dados, através do idEndereco
        /// </summary>
        /// <param name="idEndereco">Objeto com o campo necessário para filtrar o endereço</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a busca seja feita com sucesso</response>
        [HttpGet("{idEndereco}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterEnderecoPorId(int idEndereco)
        {
            var endereco = await _context.Enderecos.FirstOrDefaultAsync(x => x.IdEndereco == idEndereco);

            if (endereco == null)
                return NotFound();

            var enderecoDTO = _mapper.Map<ReadEnderecoDTO>(endereco);

            return Ok(enderecoDTO);
        }

        /// <summary>
        /// Adiciona um endereço ao banco de dados
        /// </summary>
        /// <param name="EnderecoDTO">Objeto com os campos necessários para criação de um endereço</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CadastrarEndereco([FromBody] CreateEnderecoDTO EnderecoDTO)
        {
            Endereco endereco = _mapper.Map<Endereco>(EnderecoDTO);

            await _context.Enderecos.AddAsync(endereco);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObterEnderecoPorId), new { id = endereco.IdEndereco }, endereco);
        }

        /// <summary>
        /// Atualiza todos os dados de um endereço no banco de dados
        /// </summary>
        /// <param name="idEndereco">Objeto com o campo necessário para filtrar o endereço</param>
        /// <param name="EnderecoDTO">Objeto com os campos necessários para atualização do endereço</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a tualização seja feita com sucesso</response>
        [HttpPut("{idEndereco}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> AtualizarEndereco(int idEndereco, [FromBody] UpdateEnderecoDTO EnderecoDTO)
        {
            var endereco = await _context.Enderecos.FirstOrDefaultAsync(x => x.IdEndereco == idEndereco);

            if (endereco == null)
                return NotFound();

            _mapper.Map(EnderecoDTO, endereco);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Deleta um endereço do banco de dados
        /// </summary>
        /// <param name="idEndereco">Objeto com o campo necessário para filtrar o endereço</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a deleção seja feita com sucesso</response>
        [HttpDelete("{idEndereco}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeletarEndereco(int idEndereco)
        {
            var endereco = await _context.Enderecos.FirstOrDefaultAsync(x => x.IdEndereco == idEndereco);

            if (endereco == null)
                return NotFound();

            _context.Remove(endereco);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
