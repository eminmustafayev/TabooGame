using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tabu.DTOs.Languages;
using Tabu.Exceptions;
using Tabu.Services.Implements;

namespace Tabu.Controllers
{
    public class WordController(WordService _service , IMapper _mapper) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(LanguageCreateDto dto)
        {
           /* try
            {
                await _service.CreateAsync(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex is IBaseException bEx)
                {
                    return StatusCode(bEx.StatusCode, new
                    {
                        Message = bEx.ErrorMessage
                    });

                }
                else
                {
                    return BadRequest(ex.Message);
                }
            }*/
           return BadRequest(dto);

        }

        [HttpPut("{code}")]
        public async Task<IActionResult> Update(string code, LanguageUpdateDto dto)
        {
            await _service.UpdateAsync(code, dto);
            return Ok();
        }
        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            await _service.DeleteAsync(code);
            return Ok();
        }

    }
}
