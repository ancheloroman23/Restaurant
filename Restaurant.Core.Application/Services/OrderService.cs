using AutoMapper;
using Restaurant.Core.Application.Interfaces.Repositories;
using Restaurant.Core.Application.Interfaces.Services;
using Restaurant.Core.Application.ViewModels.OrderDishes;
using Restaurant.Core.Application.ViewModels.Orders;
using Restaurant.Core.Domain.Entities;

namespace Restaurant.Core.Application.Services
{
    public class OrderService : GenericService<SaveOrderViewModel, 
                                               OrderViewModel, 
                                               Order>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;        
        private readonly IMapper _mapper;
        private readonly IOrderDishRepository _orderdishRepository;

        public OrderService(IOrderRepository orderRepository, IMapper mapper, IOrderDishRepository orderdishRepository) : base(orderRepository, mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _orderdishRepository = orderdishRepository;
        }

        public async Task AddDishOrder(int dishId, int orderId)
        {
            OrderDish orderDish = new()
            {
                DishId = dishId,
                OrderId = orderId                
            };
            await _orderdishRepository.AddAsync(orderDish);
        }

        public async Task DeleteDishOrder(int dishId, int orderId)
        {
            OrderDish orderDish = new()
            {
                DishId = dishId,
                OrderId = orderId                
            };

            await _orderdishRepository.DeleteAsync(orderDish);
        }

        public async Task<List<OrderViewModel>> GetOrdersTable(int tableId)
        {
            var orders = await _orderRepository.GetAllAsync();
            var ordersTable = orders.FindAll(o => o.TableId == tableId);

            return _mapper.Map<List<OrderViewModel>>(ordersTable);
        }

        public async Task<List<OrderDishViewModel>> GetAllDishesOrder(int orderId)
        {
            var dishes = await _orderdishRepository.GetAllAsync();
            var dishOrder = dishes.FindAll(o => o.OrderId == orderId);

            return _mapper.Map<List<OrderDishViewModel>>(dishOrder);
        }

        public async Task<OrderViewModel> GetOrderWithDishes(int id)
        {
            var order = await _orderRepository.GetByIdWithIncludeAsync(id, new List<string>(), new List<string> { "Dishes" });
            return _mapper.Map<OrderViewModel>(order);
        }

        public async Task<List<OrderViewModel>> GetAllWithDishes()
        {
            var orders = await _orderRepository.GetAllWithIncludesAsync(new List<string> { "Dishes" });
            return _mapper.Map<List<OrderViewModel>>(orders);
        }
    }
}
