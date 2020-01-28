using DAL.DataContext;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions
{
    public class ApplicationRepository: IApplicationRepository
    {
        // add a new application
        async Task<Application> IApplicationRepository.addApplication(string title)
        {
            Application newApplication = new Application
            {
                Title = title
            };

            using (var context = new AppDbContext(AppDbContext.ops.dbOptions))
            {
                await context.Applications.AddAsync(newApplication);
                await context.SaveChangesAsync();
            }

            return newApplication;
        }

        // get application list
        async Task<List<Application>> IApplicationRepository.getAllApplication()
        {
            List<Application> applications = new List<Application>();

            using (var context = new AppDbContext(AppDbContext.ops.dbOptions))
            {
                applications = await context.Applications.ToListAsync();
            }
            return applications;
        }
    }
}
