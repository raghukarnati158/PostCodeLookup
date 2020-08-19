using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PostCodeLookupAPI.Entities;

namespace PostCodeLookupAPI.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDBConnection"));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<PostcodeLookup> PostCodeLookup { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostcodeLookup>().HasData(
                new PostcodeLookup() { Id = 1, PostCode = "TN9", DeliveryInfo = "Delivery from Warehouse" },
                new PostcodeLookup() { Id = 2, PostCode = "TN9 1AP", DeliveryInfo = "No Deliveries" },
                new PostcodeLookup() { Id = 3, PostCode = "TN8", DeliveryInfo = "Delivery from Warehouse" },
                new PostcodeLookup() { Id = 4, PostCode = "TN11", DeliveryInfo = "Delivery from Warehouse" },
                new PostcodeLookup() { Id = 5, PostCode = "TN1", DeliveryInfo = "Van Delivery, Collect from Tunbridge Wells" },
                new PostcodeLookup() { Id = 6, PostCode = "TN2", DeliveryInfo = "Van Delivery, Collect from Tunbridge Wells" },
                new PostcodeLookup() { Id = 7, PostCode = "TN10", DeliveryInfo = "Van Delivery" },
                new PostcodeLookup() { Id = 8, PostCode = "TN13", DeliveryInfo = "Delivery from Sevenoaks, Collect from Sevenoaks" },
                new PostcodeLookup() { Id = 9, PostCode = "TN14", DeliveryInfo = "Delivery from Sevenoaks, Collect from Sevenoaks" },
                new PostcodeLookup() { Id = 10, PostCode = "TN15", DeliveryInfo = "Collect from Sevenoaks" },
                new PostcodeLookup() { Id = 11, PostCode = "ME", DeliveryInfo = "No Deliveries" },
                new PostcodeLookup() { Id = 12, PostCode = "ME10", DeliveryInfo = "Collect from Kitchen" },
                new PostcodeLookup() { Id = 13, PostCode = "ME10 3", DeliveryInfo = "Collect from Kitchen, Delivery from Sittingbourne" },
                new PostcodeLookup() { Id = 14, PostCode = "IV", DeliveryInfo = "No Deliveries" },
                new PostcodeLookup() { Id = 15, PostCode = "", DeliveryInfo = "Delivery by Courier" });
        }
    }
}
