using AutoMapper;
using Restaurant.Core.Application.Interfaces.Repositories;
using Restaurant.Core.Application.Interfaces.Services;

namespace Restaurant.Core.Application.Services
{
    public class GenericService<SaveViewModel, ViewModel, Entity> : IGenericService<SaveViewModel, ViewModel, Entity>
           where SaveViewModel : class
           where ViewModel : class
           where Entity : class
    {
        private readonly IGenericRepository<Entity> _repository;
        private readonly IMapper _mapper;

        public GenericService(IGenericRepository<Entity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<SaveViewModel> Add(SaveViewModel saveViewModel)
        {
            Entity entity = _mapper.Map<Entity>(saveViewModel);
            entity = await _repository.AddAsync(entity);
            SaveViewModel vm = _mapper.Map<SaveViewModel>(entity);

            return vm;
        }

        public virtual async Task Delete(int id)
        {
            Entity entity = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(entity);
        }

        public virtual async Task<List<ViewModel>> GetAllViewModel()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<ViewModel>>(entities);
        }

        public virtual async Task<SaveViewModel> GetByIdSaveViewModel(int id)
        {
            Entity entity = await _repository.GetByIdAsync(id);
            SaveViewModel saveVM = _mapper.Map<SaveViewModel>(entity);

            return saveVM;
        }

        public virtual async Task<ViewModel> GetByIdViewModel(int id)
        {
            Entity entity = await _repository.GetByIdAsync(id);
            ViewModel vm = _mapper.Map<ViewModel>(entity);

            return vm;
        }

        public virtual async Task Update(SaveViewModel saveViewModel, int id)
        {
            Entity entity = _mapper.Map<Entity>(saveViewModel);
            await _repository.UpdateAsync(entity, id);
        }
    }
}
