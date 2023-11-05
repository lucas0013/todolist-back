using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.DTOs;
using ToDoList.Application.Interfaces;
using ToDoList.Application.Services;
using ToDoList.Domain.Entities;

namespace ToDoList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TagsController : ControllerBase
    {
        private readonly ITagService _tagService;
        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TagDTO>>> Get([FromQuery] string? busca = "", [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            if (busca == null) busca = "";
            var tags = await _tagService.FindAsync(busca, page, pageSize);
            return Ok(tags);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TagDTO>> GetById(int id)
        {
            var Tag = await _tagService.GetByIdAsync(id);
            if (Tag == null)
            {
                return NotFound("Tag não encontrada");
            }
            return Ok(Tag);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TagDTO Tag)
        {
            return Ok((await _tagService.CreateAsync(Tag)).Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(TagDTO Tag)
        {
            var TagCheck = await _tagService.GetByIdAsync(Tag.Id);
            if (TagCheck == null)
            {
                return NotFound("Tag não encontrada");
            }

            _tagService.Edit(Tag);
            return Ok("Categoria Atualizada!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var TagCheck = await _tagService.GetByIdAsync(id);
            if (TagCheck == null)
            {
                return NotFound("Tag não encontrada");
            }

            await _tagService.DeleteAsync(id);
            return Ok("Deletado com sucesso!");
        }
    }
}