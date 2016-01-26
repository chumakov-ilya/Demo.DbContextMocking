using System.Data.Entity;
using Demo.DbContextMocking.Entities.Mapping;

namespace Demo.DbContextMocking.Entities
{
    public partial class FooContext : DbContext, IFooContext
    {
        static FooContext()
        {
            Database.SetInitializer<FooContext>(null);
        }

        public FooContext()
            : base("Name=FooContext")
        {
        }

        public IDbSet<Report> Reports { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ReportMap());
        }
    }
}
