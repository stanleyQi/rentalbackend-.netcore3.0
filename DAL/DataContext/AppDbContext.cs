using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DataContext
{
    public class AppDbContext:DbContext
    {
        public static OptionBuilder ops = new OptionBuilder();

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        //Dbset goes there
        public DbSet<Application> Applications { get; set; }
        public DbSet<Report> Reports { get; set; }

        public class OptionBuilder
        {
            public DbContextOptionsBuilder<AppDbContext> opsBuilder { get; set; }
            public DbContextOptions<AppDbContext> dbOptions { get; set; }
            private AppConfiguration settings { get; set; }
            public OptionBuilder()
            {
                settings = new AppConfiguration();
                opsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                opsBuilder.UseSqlServer(settings.sqlConnectionString);
                dbOptions = opsBuilder.Options;
            }

        }

        

    }
}
