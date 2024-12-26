using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tabu.DAL;
using Tabu.DTOs.Languages;
using Tabu.Entities;
using Tabu.Exceptions.Languages;
using Tabu.Services.Abstracts;

namespace Tabu.Services.Implements
{
    public class LanguageService(TabuDbContext _context , IMapper _mapper) : ILanguageService
    {       

        public async Task CreateAsync(LanguageCreateDto dto)
        {
            if (await _context.Languages.AnyAsync(x => x.Code == dto.Code))
                throw new LanguageExistException();
            await _context.Languages.AddAsync(_mapper.Map<Language>(dto));
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LanguageGeetDto>> GetAllAsync()
        {
            var data= await _context.Languages.ToListAsync();
            return _mapper.Map<IEnumerable<LanguageGeetDto>>(data);
        }

        public async Task DeleteAsync(string? code)
        {
            var data = await _context.Languages.FirstOrDefaultAsync(x => x.Code == code);
            if (data == null)
            {
                _context.Languages.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateAsync(string code, LanguageUpdateDto dto)
        {
            var data = await _context.Languages.FirstOrDefaultAsync(x=>x.Code == code);
            if(data != null)
            {
                data.Name = dto.Name;
                data.IconUrl = dto.IconUrl;
                await _context.SaveChangesAsync();
            }
        }
    }
}
