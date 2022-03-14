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
        public void CreateRun(CreateRunDto createRunDto)
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
        }
    }
}
