

namespace Restaurant.Core.Application.Interfaces.Repositories
{
    public interface IGenericRepository<Entity> where Entity : class
    {
        Task<Entity> AddAsync(Entity entity);
        Task DeleteAsync(Entity entity);
        Task<List<Entity>> GetAllAsync();
        Task<List<Entity>> GetAllWithIncludesAsync(List<string> properties);
        Task<Entity> GetByIdAsync(int id);
        Task<Entity> GetByIdWithIncludeAsync(int id, List<string> properties, List<string> collections);
        Task UpdateAsync(Entity entity, int id);
    }
}