using AutoMapper;
using System.Collections.Generic;
using ToDoList.Application.DTOs;
using ToDoList.Application.Interfaces;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Entities.@base;
using ToDoList.Domain.Interfaces;
using ToDoList.Domain.IRepositories;

namespace ToDoList.Application.Services
{
    public class TarefaService : ITarefaService
    {
        public readonly ITarefaRepository _tarefaRepository;
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public TarefaService(ITarefaRepository tarefaRepository, IMapper mapper, IUnitOfWork unitOfWork) {
            _tarefaRepository = tarefaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<TarefaDTO>> GetAllAsync()
        {
            var tarefas = await _tarefaRepository.GetAllAsync();
            return _mapper.Map<List<TarefaDTO>>(tarefas);
        }

        public async Task<PagedSearchList<TarefaDTO>> FindAsync(string busca, int page, int pageSize) {
            var tarefas = await _tarefaRepository.FindAsync(busca, page, pageSize);

            return _mapper.Map<PagedSearchList<TarefaDTO>>(tarefas);
        }

        public async Task<TarefaDTO> GetByIdAsync(int id)
        {
            var tarefa = await _tarefaRepository.GetByIdAsync(p => p.Id == id);
            return _mapper.Map<TarefaDTO>(tarefa);
        }
        
        public async Task<TarefaDTO> CreateAsync(TarefaDTO tarefa)
        {
            var result = await _tarefaRepository.AddAsync(_mapper.Map<Tarefa>(tarefa));
            await _unitOfWork.Commit();

            return _mapper.Map<TarefaDTO>(result);
        }

        public void Edit(TarefaDTO tarefa)
        {
            _tarefaRepository.Update(_mapper.Map<Tarefa>(tarefa));
            _unitOfWork.Commit();
        }

        public async Task DeleteAsync(int id)
        {
            var tarefa = await _tarefaRepository.GetByIdAsync(p => p.Id == id);

            if (tarefa == null)
            {
                return;
            }

            _tarefaRepository.Delete(tarefa);
            await _unitOfWork.Commit();
        }
    }
}
