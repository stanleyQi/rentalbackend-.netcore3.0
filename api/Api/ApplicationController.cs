using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto;
using BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Api
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles ="tenant")]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }




        // GET: api/<controller>
        [HttpGet]
        [AllowAnonymous]
        public async Task<List<ApplicationDto>> Get()
        {
            List<ApplicationDto> applicationList = new List<ApplicationDto>();
            var applications = await _applicationService.getAllApplications();
            if (applications.Count>0)
            {
                foreach (var application in applications)
                {
                    ApplicationDto item = new ApplicationDto
                    {
                        Title = application.Title
                    };
                    applicationList.Add(item);
                }
            }
            return applicationList;
        }

        
        
        
        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            Console.Out.WriteLine(id);
            return "Secrit info: Only household or agent can access.";
        }

        // POST api/<controller>
        [HttpPost]
        public async Task PostAsync([FromBody]ApplicationDto ApplicationDto)
        {
            bool result = await _applicationService.createNewApplication(ApplicationDto.Title);
        }





        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
