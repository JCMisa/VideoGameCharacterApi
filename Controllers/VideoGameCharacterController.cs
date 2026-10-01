
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

        [HttpPost]
        public async Task<ActionResult<CharacterResponse>> AddCharacter(CreateCharacterRequest character)
        {
            var createdCharacter = await service.AddCharacterAsync(character);
            return CreatedAtAction(nameof(GetCharacter), new { id = createdCharacter.Id }, createdCharacter);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCharacter(int id, UpdateCharacterRequest character)
        {
            if (id != character.Id)
            {
                return BadRequest("Id in URL does not match Id in request body");
            }

            var result = await service.UpdateCharacterAsync(id, character);
            if (!result)
            {
                return NotFound($"Character with Id {id} not found");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            var result = await service.DeleteCharacterAsync(id);
            if (!result)
            {
                return NotFound($"Character with Id {id} not found");
            }

            return NoContent();
        }
    }
}