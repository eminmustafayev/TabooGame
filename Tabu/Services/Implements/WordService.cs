
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tabu.DAL;
using Tabu.DTOs.Languages;
using Tabu.DTOs.Word;
using Tabu.Entities;
using Tabu.Services.Abstracts;

namespace Tabu.Services.Implements
{
    public class WordService(TabuDbContext _context, IMapper _mapper) : IWordService
    {
        public async Task CreateAsync (WordCreateDto dto)
        {
            await _context.AddAsync(new Entities.Word
            {
                Text = dto.Text,
                LanguageCode = dto.LanguageCode,
                BannedWords = dto.BannedWords.Select(x => new Entities.BannedWord
                {
                    Text = x
                }).ToList()

            });
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _context.Wordss.FirstOrDefaultAsync(x => x.Id == id);
            if (data != null)
            {
                _context.Wordss.Remove(data);
                await _context.SaveChangesAsync();
            }
        }

        

        public async Task<IEnumerable<WordGetDto>> GetAllAsync()
        {
            return await _context.Wordss
               .Include(x => x.BannedWords)
               .Select(x => new WordGetDto
               {
                   LanguageCode = x.LanguageCode,
                   Text = x.Text,
                   BannedWords = x.BannedWords.Select(x => x.Text).ToList()
               }).ToListAsync();
        }

        public async Task<WordGetDto> GetByIdAsync(int id)
        {
            var data = await _context.Wordss
                .Include(x => x.BannedWords)
                .FirstOrDefaultAsync(x => x.Id == id);
            
            var dto = new WordGetDto
            {
                Text = data.Text,
                LanguageCode = data.LanguageCode,
                BannedWords = data.BannedWords.Select(x => x.Text).ToList()
            };
            return dto;
        }
        

        public Task<bool> UpdateAsync(int id, WordUpdateDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task <IEnumerable<WordGetDto>> GetAllAsync()
        {
            return await _context.Wordss
               .Include(x => x.BannedWords)
               .Select(x => new WordGetDto
               {
                   LanguageCode = x.LanguageCode,
                   Text = x.Text,
                   BannedWords = x.BannedWords.Select(x => x.Text).ToList()
               }).ToListAsync();
        }
    }
}
