
using Microsoft.AspNetCore.Mvc;

namespace VideoGameCharacterApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideoGameCharacterController : ControllerBase
    {
        static List<Models.Character> characters = new List<Models.Character>
        {
            new Models.Character { Id = 1, Name = "Mario", Game = "Super Mario Bros.", Role = "Hero" },
            new Models.Character { Id = 2, Name = "Link", Game = "The Legend of Zelda", Role = "Hero" },
            new Models.Character { Id = 3, Name = "Samus Aran", Game = "Metroid", Role = "Hero" },
            new Models.Character { Id = 4, Name = "Master Chief", Game = "Halo", Role = "Hero" },
            new Models.Character { Id = 5, Name = "Lara Croft", Game = "Tomb Raider", Role = "Hero" }
        };

        [HttpGet]
        public async Task<ActionResult<List<Models.Character>>> GetCharacters()
        {
            return Ok(characters);
        }
    }
}