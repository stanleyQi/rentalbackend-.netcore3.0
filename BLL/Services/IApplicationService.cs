using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IApplicationService
    {
        Task<bool> createNewApplication(string title);

        Task<List<Application>> getAllApplications();
    }
}
