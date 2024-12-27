using Tabu.DTOs.Word;

namespace Tabu.Services.Abstracts
{
    public interface IWordService
    {
        Task CreateAsync(WordCreateDto dto);
        Task<IEnumerable<WordGetDto>> GetAllAsync();
        Task<WordGetDto> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, WordUpdateDto dto);
        Task DeleteAsync(int id);
    }
}
