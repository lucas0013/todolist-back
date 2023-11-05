using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.DTOs;
using ToDoList.Application.Interfaces;
using ToDoList.Domain.Entities;

namespace ToDoList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;
        public TarefasController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TarefaDTO>>> Get([FromQuery] string? busca= "", [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            if (busca == null) busca = "";
            var tarefas = await _tarefaService.FindAsync(busca, page, pageSize);
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaDTO>> GetById(int id)
        {
            var tarefa = await _tarefaService.GetByIdAsync(id);
            if(tarefa == null) return NotFound("Tarefa não encontrada");
            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<ActionResult> Post(TarefaDTO tarefa)
        {
            return Ok((await _tarefaService.CreateAsync(tarefa)).Id);
        }

        [HttpPut]
        public async Task<ActionResult> Put(TarefaDTO tarefa)
        {
            var tarefaCheck = await _tarefaService.GetByIdAsync(tarefa.Id);
            if (tarefaCheck == null) return NotFound("Tarefa não encontrada");
            _tarefaService.Edit(tarefa);
            return Ok("Tarefa Atualizada!");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var tarefaCheck = await _tarefaService.GetByIdAsync(id);
            if (tarefaCheck == null) return NotFound("Tarefa não encontrada");
            await _tarefaService.DeleteAsync(id);
            return Ok("Deletado com sucesso!");
        }
    }
}
