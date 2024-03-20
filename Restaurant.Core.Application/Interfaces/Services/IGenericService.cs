

namespace Restaurant.Core.Application.Interfaces.Services
{
    public interface IGenericService<SaveViewModel, ViewModel, Entity>
           where SaveViewModel : class
           where ViewModel : class
           where Entity : class
    {
        Task<SaveViewModel> Add(SaveViewModel saveViewModel);
        Task Update(SaveViewModel saveViewModel, int id);
        Task Delete(int id);
        Task<List<ViewModel>> GetAllViewModel();
        Task<SaveViewModel> GetByIdSaveViewModel(int id);
        Task<ViewModel> GetByIdViewModel(int id);
    }
}
