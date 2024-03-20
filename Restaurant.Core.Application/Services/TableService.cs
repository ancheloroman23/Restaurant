using AutoMapper;
using Restaurant.Core.Application.Interfaces.Repositories;
using Restaurant.Core.Application.Interfaces.Services;
using Restaurant.Core.Application.ViewModels.Tables;
using Restaurant.Core.Domain.Entities;

namespace Restaurant.Core.Application.Services
{
    public class TableService : GenericService<SaveTableViewModel, 
                                               TableViewModel, 
                                               Table>, ITableService
    {
        private readonly ITableRepository _Repository;
        private readonly IMapper _mapper;

        public TableService(ITableRepository Repository, IMapper mapper) : base(Repository, mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }

        public async Task ChangeTableStatus(int status, int tableId)
        {
            Table table = await _Repository.GetByIdAsync(tableId);
            table.Status = status;

            await _Repository.UpdateAsync(table, tableId);
        }
    }
}
