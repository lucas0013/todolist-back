using AutoMapper;
using ToDoList.Application.DTOs;
using ToDoList.Application.Interfaces;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Entities.@base;
using ToDoList.Domain.Interfaces;
using ToDoList.Domain.IRepositories;

namespace ToDoList.Application.Services
{
    public class TagService : ITagService
    {
        public readonly ITagRepository _tagRepository;
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public TagService(ITagRepository tagRepository, IMapper mapper, IUnitOfWork unitOfWork) {
            _tagRepository = tagRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<TagDTO>> GetAllAsync()
        {
            var tags = await _tagRepository.GetAllAsync();
            return _mapper.Map<List<TagDTO>>(tags);
        }

        public async Task<PagedSearchList<TagDTO>> FindAsync(string busca, int page, int pageSize)
        {
            var tarefas = await _tagRepository.FindAsync(busca, page, pageSize);

            return _mapper.Map<PagedSearchList<TagDTO>>(tarefas);
        }

        public async Task<TagDTO> GetByIdAsync(int id)
        {
            var tag = await _tagRepository.GetByIdAsync(t => t.Id == id);
            return _mapper.Map<TagDTO>(tag);
        }
        
        public async Task<TagDTO> CreateAsync(TagDTO Tag)
        {
            var result = await _tagRepository.AddAsync(_mapper.Map<Tag>(Tag));
            await _unitOfWork.Commit();
            return _mapper.Map<TagDTO>(result);
        }

        public void Edit(TagDTO Tag)
        {
            _tagRepository.Update(_mapper.Map<Tag>(Tag));
            _unitOfWork.Commit();
        }

        public async Task DeleteAsync(int id)
        {
            var tag = await _tagRepository.GetByIdAsync(p => p.Id == id);

            if (tag == null)
            {
                return;
            }

            _tagRepository.Delete(tag);
            await _unitOfWork.Commit();
        }
    }
}