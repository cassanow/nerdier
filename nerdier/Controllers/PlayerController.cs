using Microsoft.AspNetCore.Mvc;
using nerdier.DTO;
using nerdier.Interface;
using nerdier.Model;

namespace nerdier.Controllers
{
    [ApiController]
    [Route("nerdier/[controller]")]
    public class PlayerController : Controller
    {
        private readonly IPlayerRepository _playerRepository;
        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllPlayers()
        {
            var players = await _playerRepository.GetAllPlayers();

            if (players == null || players.Count == 0)
            {
                return NotFound("No players found.");
            }

            return Ok(players);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetPlayerById(int id)
        {
            var player = await _playerRepository.GetPlayerById(id);

            if (player == null)
            {
                return NotFound($"Player with ID {id} not found.");
            }
            return Ok(player);
        }

        [HttpPost("AddPlayer")]
        public async Task<IActionResult> AddPlayer(AddPlayerDTO dto)
        {

            var existe = await _playerRepository.PlayerExists(dto.Nome);

            if (existe) return BadRequest("Player already exists.");

            var response = new Player
            {
                Nome = dto.Nome,
                Pontos = 0,
            };

            await _playerRepository.AddPlayer(response);

            return Ok(response);
        }

        [HttpPost("UpdatePlayer/{id}")]
        public async Task<IActionResult> UpdatePlayer(int id, AddPlayerDTO dto)
        {

            var player = await _playerRepository.GetPlayerById(id);

            if (player == null) return NotFound("Player not found.");

            var response = new Player
            {
                Nome = dto.Nome,
            };

            var existe = await _playerRepository.PlayerExists(dto.Nome);
            if (existe) return BadRequest("A Player with that name already exists");


            await _playerRepository.UpdatePlayer(response);

            return Ok(dto);
        }

        [HttpDelete("DeletePlayer/{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            var player = await _playerRepository.GetPlayerById(id);

            if (player == null) return NotFound("Player not found.");

            await _playerRepository.DeletePlayer(player);

            return Ok("Player deleted successfully.");
        }
    }
}
