﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RunLog.Dto;
using RunLog.DTO;
using RunLog.Service;
using System.Security.Claims;

namespace RunLog.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = "BasicAuthentication")]
    [Route("runs")]
    public class RunsController : ControllerBase
    {
        private readonly RunService runService;

        public RunsController(RunService runService)
        {
            this.runService = runService;
        }

        [HttpGet]
        public RunsDto GetRuns()
        {
            return runService.GetRuns(User.FindFirstValue(ClaimTypes.Name));
        }

        [HttpPost]
        public bool CreateRun(CreateRunDto createRunDto)
        {
            return runService.CreateRun(User.FindFirstValue(ClaimTypes.Name),createRunDto);
        }
        [HttpPut("{id:int}")]
        public bool UpdateRun(int id,  CreateRunDto createRunDto)
        {
            return runService.UpdateRun(User.FindFirstValue(ClaimTypes.Name), id, createRunDto);
        }
        [HttpDelete("{id:int}")]
        public bool DeleteRun(int id)
        {
            return runService.DeleteRun(User.FindFirstValue(ClaimTypes.Name), id);
        }
    }
}
