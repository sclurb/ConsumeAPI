using ConsumeAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace ConsumeAPI.Data
{
    public class ConsumeApiContext : DbContext
    {

        public DbSet<Stuff> Stuff { get; set; }
        public ConsumeApiContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Data Source=.\\SQLSERVERFORIIS; AttachDbFilename=Z:\\Web\\App_Data\\Original.mdf; Integrated Security=false; User = fred; password = Chainsaw1; MultipleActiveResultSets=True;");
        }
    }
}
