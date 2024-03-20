using Restaurant.Core.Application.ViewModels.Tables;
using Restaurant.Core.Domain.Entities;

namespace Restaurant.Core.Application.Interfaces.Services
{
    public interface ITableService : IGenericService<SaveTableViewModel, TableViewModel, Table>
    {
        Task ChangeTableStatus(int status, int tableId);
    }
}
