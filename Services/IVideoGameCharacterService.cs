

namespace VideoGameCharacterApi.Services
{
    public interface IVideoGameCharacterService
    {
        Task<List<Models.Character>> GetAllCharactersAsync();
        Task<Models.Character> GetCharacterByIdAsync(int id);
        Task<Models.Character> AddCharacterAsync(Models.Character character);
        Task<bool> UpdateCharacterAsync(int id, Models.Character character);
        Task<bool> DeleteCharacterAsync(int id);
    }
}