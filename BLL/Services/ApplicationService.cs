using DAL.Entities;
using DAL.Functions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationService(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        async Task<bool> IApplicationService.createNewApplication(string title)
        {
            try
            {
                var result = await _applicationRepository.addApplication(title);
                return result.Id > 0 ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        async Task<List<Application>> IApplicationService.getAllApplications()
        {
            List<Application> applications = await _applicationRepository.getAllApplication();
            return applications;
        }
    }
}
