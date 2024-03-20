using Restaurant.Core.Domain.Common;

namespace Restaurant.Core.Domain.Entities
{
    public class Table : AuditableBaseEntity
    {

        public int CapacityTable { get; set; }

        public string? Description { get; set; }

        public int Status { get; set; }


        //navigation property
        public ICollection<Order>? Orders { get; set; }
    }
}
