namespace MachinApp.Domain.Models
{
    using System.Data.Entity;

    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<MachinApp.Common.Models.Machine> Machines { get; set; }
    }
}
