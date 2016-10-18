using System.Data.Entity;
using KCKTest.Models;

namespace KCKTest
{
    public class Model : DbContext
    {
        public Model()
            : base("name=ModelKCK")
        {
        }

        public virtual DbSet<Activity> activities { get; set; }
        public virtual DbSet<User> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}