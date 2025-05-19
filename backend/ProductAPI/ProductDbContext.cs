using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ProductAPI.models;

namespace ProductAPI
{
    public class ProductDbContext: DbContext
    {
        //create constructor of Product DB 
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        { 
                    
        }
        //products table in the db
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed initial data
            modelBuilder.Entity<Product>()
                .HasData( 
                new Product { Id = 1, Name = "Apple iPhone 16", Description = "iPhone 16 has a sturdy, aerospace-grade aluminium design with a 6.1-inch Super Retina XDR display.4 It’s remarkably durable with the latest-generation Ceramic Shield\r\n\r\nfront that’s 2x tougher than any smartphone glass.", Price = 19000 },
                new Product { Id = 2, Name = "MacBook Air 15-inch", Description = "The 15-inch MacBook Air with the M4 chip lets you fly through work and play. With Apple Intelligence,1 a spacious Liquid Retina display, up to 18 hours of battery life2 and a strikingly thin and light design, it’s built to last and can take on just about anything, anywhere.", Price = 30000  },
                new Product { Id = 3, Name = "Apple Airpods 4", Description = "AirPods 4. A totally transformed audio experience with Voice Isolation1 Siri Interactions¹ and Personalised Spatial Audio.² Featuring an updated fit for all-day comfort.\r\n\r\nRedesigned for exceptional fit and audio performance", Price = 2459 }
            );
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
        }
    }
}
