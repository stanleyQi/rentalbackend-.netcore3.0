using DAL.DataContext;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions
{
    public interface IApplicationRepository
    {
        // add a new application
        Task<Application> addApplication(string title);

        // get the all applications 
        Task<List<Application>> getAllApplication();

    }
}
