using Restaurant.Core.Application.ViewModels.Dishes;
using Restaurant.Core.Application.ViewModels.IngredientDishes;
using Restaurant.Core.Domain.Entities;

namespace Restaurant.Core.Application.Interfaces.Services
{
    public interface IDishService : IGenericService<SaveDishViewModel, DishViewModel, Dish>
    {
        Task AddIngredientDish(int dishId, int ingredientId);
        Task DeleteIngredientDish(int dishId, int ingredientId);
        Task<List<IngredientDishViewModel>> GetAllIngredientByDish(int dishId);
        Task<List<DishViewModel>> GetAllWithIngredients();
        Task<DishViewModel> GetDishWithIngredients(int id);
        Task<double> GetPriceById(int id);
    }
}
