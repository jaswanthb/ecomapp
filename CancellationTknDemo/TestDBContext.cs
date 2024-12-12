using Microsoft.EntityFrameworkCore;

namespace CancellationTknDemo
{
    public class TestDBContext : DbContext
    {
        public TestDBContext(DbContextOptions<TestDBContext> options) : base(options)
        {

        }

        public DbSet<TknModel> TknModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TknModel>().HasData(
                new TknModel() { Id = 1, Name = "I am a test", Description = "desc", Email = "Test@gmail.com" }
                );


            base.OnModelCreating(modelBuilder);
        }
    }
}
