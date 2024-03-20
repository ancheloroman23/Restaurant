using Restaurant.Core.Domain.Common;

namespace Restaurant.Core.Domain.Entities
{
    public class Order : AuditableBaseEntity
    {
        public int TableId { get; set; }
        public double SubTotal { get; set; }
        public string Status { get; set; }

        //navigation property
        public Table Table { get; set; }
        public ICollection<Dish>? Dishes { get; set; }
        public List<OrderDish>? OrderDishes { get; set; }
    }
}