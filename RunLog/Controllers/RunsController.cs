using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RunLog.Data;
using RunLog.Dto;
using RunLog.DTO;
using RunLog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunLog.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = "BasicAuthentication")]
    [Route("runs")]
    public class RunsController : ControllerBase
    {
        private readonly RunLogContext runLogContext;

        public RunsController()
        {
            runLogContext = new RunLogContext();
        }

        [HttpGet]
        public RunsDto GetRuns()
        {
            RunsDto runsDto = new RunsDto();
            List<Run> runs = runLogContext.Runs.ToList();
            runsDto.Runs = runs.ConvertAll<RunDto>(run => {
                RunDto runDto = new RunDto
                {
                    Id = run.Id.ToString(),
                    Title = run.Title,
                    Description = run.Description,
                    Distance = run.Distance,
                    Duration = run.Duration,
                    HeartRate = run.HeartRate,
                    Date = run.Date,
                };
                return runDto;
            });
            return runsDto;
        }

        [HttpPost]
        public bool CreateRun(CreateRunDto createRunDto)
        {
            Run run = new Run
            {
                Title = createRunDto.Title,
                Description = createRunDto.Description,
                Distance = createRunDto.Distance,
                Duration = createRunDto.Duration,
                HeartRate = createRunDto.HeartRate,
                Date = createRunDto.Date
            };
            runLogContext.Runs.Add(run);
            runLogContext.SaveChanges();
            return true;
        }
        [HttpPut("{id:int}")]
        public bool UpdateRun(int id,  CreateRunDto createRunDto)
        {
            Run newRun = new Run
            {
                Id = id,
                Title = createRunDto.Title,
                Description = createRunDto.Description,
                Distance = createRunDto.Distance,
                Duration = createRunDto.Duration,
                HeartRate = createRunDto.HeartRate,
                Date = createRunDto.Date
            };
            Run oldRun = runLogContext.Runs.Find(id);
            runLogContext.Entry(oldRun).CurrentValues.SetValues(newRun);
            runLogContext.SaveChanges();
            return true;
        }
        [HttpDelete("{id:int}")]
        public bool DeleteRun(int id)
        {
            runLogContext.Runs.Remove(runLogContext.Runs.Find(id));
            runLogContext.SaveChanges();
            return true;
        }
    }
}
