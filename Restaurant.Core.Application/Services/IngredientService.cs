using AutoMapper;
using Restaurant.Core.Application.Interfaces.Repositories;
using Restaurant.Core.Application.Interfaces.Services;
using Restaurant.Core.Application.ViewModels.Ingredients;
using Restaurant.Core.Domain.Entities;

namespace Restaurant.Core.Application.Services
{
    public class IngredientService : GenericService<SaveIngredientViewModel, 
                                                    IngredientViewModel, 
                                                    Ingredient>, IIngredientService
    {
        private readonly IIngredientRepository _Repository;
        private readonly IMapper _mapper;

        public IngredientService(IIngredientRepository Repository, IMapper mapper) : base(Repository, mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }
    }
}
