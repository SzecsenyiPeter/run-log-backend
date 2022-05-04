using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RunLog.Dto;
using RunLog.Service;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;

namespace RunLog.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = "BasicAuthentication")]
    [Route("run-plans")]
    public class RunPlansController : ControllerBase
    {
        private readonly RunPlanService runPlanService;

        public RunPlansController(RunPlanService runPlanService)
        {
            this.runPlanService = runPlanService;
        }
        [HttpPost]
        public void CreateRunPlan(CreateRunPlanDto createRunPlanDto)
        {
            runPlanService.CreateRunPlan(User.FindFirstValue(ClaimTypes.Name), createRunPlanDto);
        }
        [HttpGet]
        public ICollection<RunPlanDto> GetRunPlans([FromQuery(Name = "athlete")]string athlete)
        {
            return runPlanService.GetRunPlans(athlete ?? User.FindFirstValue(ClaimTypes.Name));
        }
    }
}
