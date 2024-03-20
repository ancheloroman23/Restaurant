using AutoMapper;
using Restaurant.Core.Application.Interfaces.Repositories;
using Restaurant.Core.Application.Interfaces.Services;
using Restaurant.Core.Application.ViewModels.Dishes;
using Restaurant.Core.Application.ViewModels.IngredientDishes;
using Restaurant.Core.Domain.Entities;

namespace Restaurant.Core.Application.Services
{
    public class DishService : GenericService<SaveDishViewModel, 
                                              DishViewModel, 
                                              Dish>, IDishService
    {
        private readonly IDishRepository _dishRepository;
        private readonly IMapper _mapper;
        private readonly IIngredientDishRepository _ingdishRepository;        

        public DishService(IDishRepository dishRepository, IMapper mapper, IIngredientDishRepository ingdishRepository) : base(dishRepository, mapper)
        {
            _dishRepository = dishRepository;
            _mapper = mapper;
            _ingdishRepository = ingdishRepository;
        }

        public async Task AddIngredientDish(int dishId, int ingredientId)
        {
            IngredientDish ingredientDish = new()
            {
                DishId = dishId,
                IngredientId = ingredientId
            };
            await _ingdishRepository.AddAsync(ingredientDish);
        }

        public async Task DeleteIngredientDish(int dishId, int ingredientId)
        {
            IngredientDish ingredientDish = new()
            {
                DishId = dishId,
                IngredientId = ingredientId
            };

            await _ingdishRepository.DeleteAsync(ingredientDish);
        }

        public async Task<List<DishViewModel>> GetAllWithIngredients()
        {
            var dishes = await _dishRepository.GetAllWithIncludesAsync(new List<string> { "Ingredients" });
            return _mapper.Map<List<DishViewModel>>(dishes);
        }

        public async Task<DishViewModel> GetDishWithIngredients(int id)
        {
            var dish = await _dishRepository.GetByIdWithIncludeAsync(id, new List<string>(), new List<string> { "Ingredients" });
            return _mapper.Map<DishViewModel>(dish);
        }

        public async Task<double> GetPriceById(int id)
        {
            var dish = await _dishRepository.GetByIdAsync(id);
            return dish.Price;
        }

        public async Task<List<IngredientDishViewModel>> GetAllIngredientByDish(int dishId)
        {
            var ingredients = await _ingdishRepository.GetAllAsync();
            var ingByDish = ingredients.FindAll(i => i.DishId == dishId);
            return _mapper.Map<List<IngredientDishViewModel>>(ingByDish);
        }
    }
}
