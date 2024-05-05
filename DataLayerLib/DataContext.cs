using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerLib
{
    public class DataContext:DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Tomography> Tomographies { get; set; }

        public DataContext()
        {
            
        }
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            Console.WriteLine($"On Configuring {optionsBuilder.IsConfigured}");
            if(optionsBuilder != null && !optionsBuilder.IsConfigured )
            {
                string constring = @"server=(LocalDB)\mssqllocaldb;attachdbfilename=
                                C:\Users\klaus\Downloads\UebungHaupttermin2021\DataLayerLib\DataContext.mdf; 
                                database=DataContext;integrated security=True;MultipleActiveResultSets=True;";
                optionsBuilder.UseSqlServer(constring);
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
