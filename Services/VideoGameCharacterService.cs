

using VideoGameCharacterApi.Models;

namespace VideoGameCharacterApi.Services
{
    public class VideoGameCharacterService : IVideoGameCharacterService
    {
        static List<Character> characters = new List<Character>
        {
            new Character { Id = 1, Name = "Mario", Game = "Super Mario Bros.", Role = "Hero" },
            new Character { Id = 2, Name = "Link", Game = "The Legend of Zelda", Role = "Hero" },
            new Character { Id = 3, Name = "Samus Aran", Game = "Metroid", Role = "Hero" },
            new Character { Id = 4, Name = "Master Chief", Game = "Halo", Role = "Hero" },
            new Character { Id = 5, Name = "Lara Croft", Game = "Tomb Raider", Role = "Hero" },
            new Character { Id = 6, Name = "Bowser", Game = "Super Mario Bros.", Role = "Villain" },
        };

        public async Task<List<Character>> GetAllCharactersAsync()
        {
            return await Task.FromResult(characters);
        }

        public async Task<Character> GetCharacterByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be greater than 0", nameof(id));
            }

            var character = characters.FirstOrDefault(c => c.Id == id);

            if (character == null)
            {
                throw new KeyNotFoundException($"Character with Id {id} not found");
            }

            return await Task.FromResult(character);
        }

        public Task<Character> AddCharacterAsync(Character character)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCharacterAsync(int id, Character character)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCharacterAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}