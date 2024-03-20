using Restaurant.Core.Application.Interfaces.Repositories;
using Restaurant.Core.Domain.Entities;
using Restaurant.Infrastructure.Persistence.Contexts;

namespace Restaurant.Infrastructure.Persistence.Repositories
{
    public class IngredientDishRepository : GenericRepository<IngredientDish>, IIngredientDishRepository
    {
        private readonly ApplicationContext _dbContext;

        public IngredientDishRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
