using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.Application.Interfaces.Services;
using Restaurant.Core.Application.ViewModels.Dishes;

namespace Retaurant.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public class DishController : BaseApiController
    {
        private readonly IDishService _dishService;
        private readonly IIngredientService _ingredientService;

        public DishController(IDishService dishService, IIngredientService ingredientService)
        {
            _dishService = dishService;
            _ingredientService = ingredientService;
        }

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(SaveDishViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {                    
                    return BadRequest(ModelState);
                }

                if (vm.Ingredients.Count == 0 || vm.Ingredients == null)
                {                    
                    ModelState.AddModelError("Ingredients", "Debes añadir al menos un ingrediente.");
                    return BadRequest(ModelState);
                }

                foreach (var id in vm.Ingredients)
                {
                    var ingredient = await _ingredientService.GetByIdSaveViewModel(id);
                    if (ingredient == null)
                    {                        
                        ModelState.AddModelError("Ingredients", $"No existe un ingrediente con el id {id}.");
                        return BadRequest(ModelState);
                    }
                }

                var dish = await _dishService.Add(vm);
                if (dish == null)
                {                    
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear el plato.");
                }

                foreach (var id in vm.Ingredients)
                {
                    await _dishService.AddIngredientDish(dish.Id, id);
                }

                return NoContent();
            }
            catch (Exception ex)
            {                
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut("Update/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DishViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, SaveDishViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(vm);
                }

                var dish = await _dishService.GetByIdViewModel(id);
                if (dish == null)
                {
                    ModelState.AddModelError("Dish no Existe", $"No existe un plato con el id {id}");
                    return BadRequest(ModelState);
                }

                if (vm.Ingredients.Count == 0 || vm.Ingredients == null)
                {
                    ModelState.AddModelError("no hay Ingredientes", "Debes añadir al menos un ingrediente");
                    return BadRequest(ModelState);
                }

                foreach (var ingId in vm.Ingredients)
                {
                    var ingredient = await _ingredientService.GetByIdSaveViewModel(ingId);
                    if (ingredient == null)
                    {
                        ModelState.AddModelError("No existe ingrediente", $"No existe un ingrediente con el id {ingId}");
                        return BadRequest(ModelState);
                    }
                }

                List<int> forAdd = new();
                List<int> forDelete = new();

                var ingsByDish = await _dishService.GetAllIngredientByDish(id);

                foreach (int ingId in vm.Ingredients)
                {
                    if (!ingsByDish.Any(i => i.IngredientId == ingId))
                        forAdd.Add(ingId);
                }

                foreach (var ing in ingsByDish)
                {
                    if (!vm.Ingredients.Contains(ing.IngredientId))
                        forDelete.Add(ing.IngredientId);
                }

                foreach (var del in forDelete)
                {
                    await _dishService.DeleteIngredientDish(del, id);
                }

                vm.Id = id;
                await _dishService.Update(vm, id);

                foreach (var add in forAdd)
                {
                    await _dishService.AddIngredientDish(id, add);
                }

                return Ok(await _dishService.GetDishWithIngredients(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DishViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<DishViewModel> dishes = await _dishService.GetAllWithIngredients();

                if (dishes.Count == 0 || dishes == null)
                    return NotFound();

                return Ok(dishes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DishViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var dish = await _dishService.GetByIdSaveViewModel(id);

                if (dish == null)
                    return NotFound();

                return Ok(await _dishService.GetDishWithIngredients(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
