using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DataContext
{
    class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var opsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            opsBuilder.UseSqlServer(new AppConfiguration().sqlConnectionString);
            return new AppDbContext(opsBuilder.Options);
        }
    }
}
