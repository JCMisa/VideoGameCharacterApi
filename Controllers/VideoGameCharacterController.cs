
using Microsoft.AspNetCore.Mvc;
using VideoGameCharacterApi.DTOs;
using VideoGameCharacterApi.Services;

namespace VideoGameCharacterApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideoGameCharacterController(IVideoGameCharacterService service) : ControllerBase
    {


        [HttpGet]
        public async Task<ActionResult<List<CharacterResponse>>> GetCharacters()
        {
            return Ok(await service.GetAllCharactersAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterResponse>> GetCharacter(int id)
        {
            try
            {
                var character = await service.GetCharacterByIdAsync(id);
                return Ok(character);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}