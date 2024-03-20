using AutoMapper;
using Restaurant.Core.Application.Dtos.Account;
using Restaurant.Core.Application.ViewModels.Dishes;
using Restaurant.Core.Application.ViewModels.IngredientDishes;
using Restaurant.Core.Application.ViewModels.Ingredients;
using Restaurant.Core.Application.ViewModels.OrderDishes;
using Restaurant.Core.Application.ViewModels.Orders;
using Restaurant.Core.Application.ViewModels.Tables;
using Restaurant.Core.Application.ViewModels.User;
using Restaurant.Core.Domain.Entities;

namespace Restaurant.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {

            #region DishProfile

            CreateMap<Dish, DishViewModel>()
                .ReverseMap()
                .ForMember(d => d.Created, o => o.Ignore())
                .ForMember(d => d.CreatedBy, o => o.Ignore())
                .ForMember(d => d.LastModified, o => o.Ignore())
                .ForMember(d => d.LastModifiedBy, o => o.Ignore())
                .ForMember(d => d.IngredientDishes, o => o.Ignore())
                .ForMember(d => d.OrderDishes, o => o.Ignore())
                ;

            CreateMap<Dish, SaveDishViewModel>()
                .ForMember(d => d.Ingredients, o => o.Ignore())
                .ReverseMap()
                .ForMember(d => d.Created, o => o.Ignore())
                .ForMember(d => d.CreatedBy, o => o.Ignore())
                .ForMember(d => d.LastModified, o => o.Ignore())
                .ForMember(d => d.LastModifiedBy, o => o.Ignore())
                .ForMember(d => d.Ingredients, o => o.Ignore())
                .ForMember(d => d.IngredientDishes, o => o.Ignore())
                .ForMember(d => d.Orders, o => o.Ignore())
                .ForMember(d => d.OrderDishes, o => o.Ignore())
                ;

            #endregion

            #region IngredientProfile

            CreateMap<Ingredient, IngredientViewModel>()
                .ReverseMap()
                .ForMember(i => i.Created, o => o.Ignore())
                .ForMember(i => i.CreatedBy, o => o.Ignore())
                .ForMember(i => i.LastModified, o => o.Ignore())
                .ForMember(i => i.LastModifiedBy, o => o.Ignore())
                .ForMember(i => i.IngredientDishes, o => o.Ignore())
                .ForMember(i => i.Dishes, o => o.Ignore())
                ;

            CreateMap<Ingredient, SaveIngredientViewModel>()
                .ReverseMap()
                .ForMember(i => i.Created, o => o.Ignore())
                .ForMember(i => i.CreatedBy, o => o.Ignore())
                .ForMember(i => i.LastModified, o => o.Ignore())
                .ForMember(i => i.LastModifiedBy, o => o.Ignore())
                .ForMember(i => i.IngredientDishes, o => o.Ignore())
                .ForMember(i => i.Dishes, o => o.Ignore())
                ;

            #endregion

            #region IngredientDishProfile

            CreateMap<IngredientDish, IngredientDishViewModel>()
                .ReverseMap()
                .ForMember(i => i.Created, o => o.Ignore())
                .ForMember(i => i.CreatedBy, o => o.Ignore())
                .ForMember(i => i.LastModified, o => o.Ignore())
                .ForMember(i => i.LastModifiedBy, o => o.Ignore())
                .ForMember(i => i.Ingredient, o => o.Ignore())
                .ForMember(i => i.Dish, o => o.Ignore())
                ;

            #endregion

            #region OrderDishesProfile

            CreateMap<OrderDish, OrderDishViewModel>()
                .ReverseMap()
                .ForMember(o => o.Created, o => o.Ignore())
                .ForMember(o => o.CreatedBy, o => o.Ignore())
                .ForMember(o => o.LastModified, o => o.Ignore())
                .ForMember(o => o.LastModifiedBy, o => o.Ignore())                
                .ForMember(o => o.Dish, o => o.Ignore())
                .ForMember(o => o.Order, o => o.Ignore())
                ;

            #endregion

            #region OrderProfile

            CreateMap<Order, OrderViewModel>()                
                .ReverseMap()
                .ForMember(o => o.Created, o => o.Ignore())
                .ForMember(o => o.CreatedBy, o => o.Ignore())
                .ForMember(o => o.LastModified, o => o.Ignore())
                .ForMember(o => o.LastModifiedBy, o => o.Ignore())
                .ForMember(o => o.OrderDishes, o => o.Ignore())
                ;

            CreateMap<Order, SaveOrderViewModel>()
                .ForMember(o => o.Dishes, o => o.Ignore())
                .ReverseMap()
                .ForMember(o => o.Created, o => o.Ignore())
                .ForMember(o => o.CreatedBy, o => o.Ignore())
                .ForMember(o => o.LastModified, o => o.Ignore())
                .ForMember(o => o.LastModifiedBy, o => o.Ignore())
                .ForMember(o => o.Table, o => o.Ignore())
                .ForMember(o => o.Dishes, o => o.Ignore())
                .ForMember(o => o.OrderDishes, o => o.Ignore())
                ;

            #endregion

            #region TableProfile

            CreateMap<Table, TableViewModel>()
                .ReverseMap()
                .ForMember(d => d.Created, o => o.Ignore())
                .ForMember(d => d.CreatedBy, o => o.Ignore())
                .ForMember(d => d.LastModified, o => o.Ignore())
                .ForMember(d => d.LastModifiedBy, o => o.Ignore())
                ;

            CreateMap<Table, SaveTableViewModel>()
                .ReverseMap()
                .ForMember(d => d.Created, o => o.Ignore())
                .ForMember(d => d.CreatedBy, o => o.Ignore())
                .ForMember(d => d.LastModified, o => o.Ignore())
                .ForMember(d => d.LastModifiedBy, o => o.Ignore())
                .ForMember(d => d.Orders, o => o.Ignore())
                ;

            #endregion

            #region UserProfile

            CreateMap<LoginRequest, LoginViewModel>()
                .ReverseMap();

            CreateMap<RegisterRequest, SaveUserViewModel>()
                .ReverseMap();

            CreateMap<RegisterResponse, UserViewModel>()
                .ReverseMap()
                .ForMember(d => d.Error, o => o.Ignore())
                .ForMember(d => d.HasError, o => o.Ignore());                
            
            #endregion
        }
    }
}
