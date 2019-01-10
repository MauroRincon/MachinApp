namespace MachinApp.Backend.Models
{
    using Domain.Models;

    public class LocalDataContext : DataContext
    {
        public System.Data.Entity.DbSet<MachinApp.Common.Models.Machine> Machines { get; set; }
    }
}