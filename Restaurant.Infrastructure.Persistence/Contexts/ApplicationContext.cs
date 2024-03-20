using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Domain.Entities;


namespace Restaurant.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Table> Tables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region tables

            modelBuilder.Entity<Dish>()
                .ToTable("Dishes");

            modelBuilder.Entity<Ingredient>()
                .ToTable("Ingredients");

            modelBuilder.Entity<Order>()
                .ToTable("Orders");

            modelBuilder.Entity<Table>()
                .ToTable("Tables");

            #endregion

            #region "primary keys"

            modelBuilder.Entity<Dish>()
                .HasKey(dish => dish.Id);

            modelBuilder.Entity<Ingredient>()
                .HasKey(ingredient => ingredient.Id);

            modelBuilder.Entity<Order>()
                .HasKey(order => order.Id);

            modelBuilder.Entity<Table>()
                .HasKey(table => table.Id);

            #endregion

            #region "Relationships"

            modelBuilder.Entity<Ingredient>()
                .HasMany(i => i.Dishes)
                .WithMany(d => d.Ingredients)
                .UsingEntity<IngredientDish>(
                    r => r
                        .HasOne(indish => indish.Dish)
                        .WithMany(i => i.IngredientDishes)
                        .HasForeignKey(indish => indish.DishId),
                    r => r
                        .HasOne(indish => indish.Ingredient)
                        .WithMany(d => d.IngredientDishes)
                        .HasForeignKey(indish => indish.IngredientId),
                    r =>
                    {
                        r.ToTable("IngredientDish");
                        r.HasKey(x => new { x.DishId, x.IngredientId });
                    }
                );

            modelBuilder.Entity<Order>()
                .HasMany(o => o.Dishes)
                .WithMany(d => d.Orders)
                .UsingEntity<OrderDish>(
                    r => r
                        .HasOne(odish => odish.Dish)
                        .WithMany(o => o.OrderDishes)
                        .HasForeignKey(odish => odish.DishId),
                    r => r
                        .HasOne(odish => odish.Order)
                        .WithMany(d => d.OrderDishes)
                        .HasForeignKey(odish => odish.OrderId),
                    r =>
                    {
                        r.ToTable("OrderDish");
                        r.HasKey(x => new { x.DishId, x.OrderId });
                    }
                );

            modelBuilder.Entity<Table>()
                .HasMany<Order>(t => t.Orders)
                .WithOne(o => o.Table)
                .HasForeignKey(o => o.TableId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region "Property configurations"

            #region Dishes

            modelBuilder.Entity<Dish>()
                .Property(dish => dish.Name)
                .IsRequired();

            modelBuilder.Entity<Dish>()
                .Property(dish => dish.Price)
                .IsRequired();

            modelBuilder.Entity<Dish>()
                .Property(dish => dish.People)
                .IsRequired();

            modelBuilder.Entity<Dish>()
                .Property(dish => dish.Category)
                .IsRequired();

            #endregion

            #region Ingredients

            modelBuilder.Entity<Ingredient>()
                .Property(ingredient => ingredient.Name)
                .IsRequired();

            #endregion

            #region Orders

            modelBuilder.Entity<Order>()
                .Property(order => order.TableId)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(order => order.SubTotal)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(order => order.Status)
                .IsRequired();

            #endregion

            #region Tables

            modelBuilder.Entity<Table>()
                .Property(table => table.CapacityTable)
                .IsRequired();

            modelBuilder.Entity<Table>()
                .Property(table => table.Description)
                .IsRequired();

            modelBuilder.Entity<Table>()
                .Property(table => table.Status)
                .IsRequired();

            #endregion

            #endregion
        }
    }
}
