using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Application.Interfaces.Repositories;
using Restaurant.Core.Domain.Entities;
using Restaurant.Infrastructure.Persistence.Contexts;

namespace Restaurant.Infrastructure.Persistence.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly ApplicationContext _dbContext;

        public OrderRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


        public override async Task<List<Order>> GetAllAsync()
        {
            return await _dbContext.Set<Order>()
                .Include(o => o.Table)
                .Include(o => o.Dishes)
                .AsNoTracking()
                .ToListAsync();


        }
    }
}
