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
            await _context.Languages.AddAsync(new Entities.Language
            {
                Code = dto.Code,
                Name = dto.Name,
                Icon = dto.Icon,
            });
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LanguageGeetDto>> GetAllAsync()
        {
            return await _context.Languages
                .Select(x => new LanguageGeetDto
                {
                    Code = x.Code,
                    Name = x.Name,
                    Icon = x.Icon
                }).ToListAsync();
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
                data.Icon = dto.IconUrl;
                await _context.SaveChangesAsync();
            }
        }
    }
}
