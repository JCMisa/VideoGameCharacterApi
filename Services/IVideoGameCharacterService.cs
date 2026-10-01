

using VideoGameCharacterApi.DTOs;

namespace VideoGameCharacterApi.Services
{
    public interface IVideoGameCharacterService
    {
        Task<List<CharacterResponse>> GetAllCharactersAsync();
        Task<CharacterResponse> GetCharacterByIdAsync(int id);
        Task<CharacterResponse> AddCharacterAsync(Models.Character character);
        Task<bool> UpdateCharacterAsync(int id, Models.Character character);
        Task<bool> DeleteCharacterAsync(int id);
    }
}