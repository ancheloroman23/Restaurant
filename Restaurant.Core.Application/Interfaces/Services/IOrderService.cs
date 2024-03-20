using Restaurant.Core.Application.ViewModels.OrderDishes;
using Restaurant.Core.Application.ViewModels.Orders;
using Restaurant.Core.Domain.Entities;

namespace Restaurant.Core.Application.Interfaces.Services
{
    public interface IOrderService : IGenericService<SaveOrderViewModel, OrderViewModel, Order>
    {
        Task AddDishOrder(int dishId, int orderId);
        Task DeleteDishOrder(int dishId, int orderId);
        Task<List<OrderDishViewModel>> GetAllDishesOrder(int orderId);
        Task<List<OrderViewModel>> GetAllWithDishes();
        Task<List<OrderViewModel>> GetOrdersTable(int tableId);
        Task<OrderViewModel> GetOrderWithDishes(int id);
    }
}
