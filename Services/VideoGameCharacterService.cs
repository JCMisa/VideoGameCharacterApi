

using Microsoft.EntityFrameworkCore;
using VideoGameCharacterApi.Data;
using VideoGameCharacterApi.DTOs;
using VideoGameCharacterApi.Models;

namespace VideoGameCharacterApi.Services
{
    public class VideoGameCharacterService(ApplicationDbContext context) : IVideoGameCharacterService
    {
        public async Task<List<CharacterResponse>> GetAllCharactersAsync()
        {
            return await context.Characters.Select(c => new CharacterResponse
            {
                Name = c.Name,
                Game = c.Game,
                Role = c.Role
            }).ToListAsync();
        }

        public async Task<CharacterResponse> GetCharacterByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be greater than 0", nameof(id));
            }

            var character = await context.Characters.FindAsync(id);

            if (character == null)
            {
                throw new KeyNotFoundException($"Character with Id {id} not found");
            }

            return await Task.FromResult(new CharacterResponse
            {
                Name = character.Name,
                Game = character.Game,
                Role = character.Role
            });
        }

        public async Task<CharacterResponse> AddCharacterAsync(Character character)
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