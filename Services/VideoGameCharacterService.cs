

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
                Id = c.Id,
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
                Id = character.Id,
                Name = character.Name,
                Game = character.Game,
                Role = character.Role
            });
        }

        public async Task<CharacterResponse> AddCharacterAsync(CreateCharacterRequest character)
        {
            var newCharacter = new Character
            {
                Name = character.Name,
                Game = character.Game,
                Role = character.Role
            };

            context.Characters.Add(newCharacter);
            await context.SaveChangesAsync();

            return await Task.FromResult(new CharacterResponse
            {
                Id = newCharacter.Id,
                Name = newCharacter.Name,
                Game = newCharacter.Game,
                Role = newCharacter.Role
            });
        }

        public async Task<bool> UpdateCharacterAsync(int id, UpdateCharacterRequest character)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be greater than 0", nameof(id));
            }

            var existingCharacter = await context.Characters.FindAsync(id);

            if (existingCharacter == null)
            {
                return await Task.FromResult(false);
            }

            existingCharacter.Name = character.Name;
            existingCharacter.Game = character.Game;
            existingCharacter.Role = character.Role;

            context.Characters.Update(existingCharacter);
            await context.SaveChangesAsync();

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteCharacterAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be greater than 0", nameof(id));
            }

            var existingCharacter = await context.Characters.FindAsync(id);

            if (existingCharacter == null)
            {
                return await Task.FromResult(false);
            }

            context.Characters.Remove(existingCharacter);
            await context.SaveChangesAsync();

            return await Task.FromResult(true);
        }
    }
}