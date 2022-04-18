using RunLog.Data;
using RunLog.Dto;
using RunLog.DTO;
using RunLog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunLog.Service
{
    public class DefaultRunService : RunService
    {
        private readonly RunLogContext runLogContext;

        public DefaultRunService()
        {
            runLogContext = new RunLogContext();
        }
        public bool CreateRun(string username, CreateRunDto createRunDto)
        {
            User user = runLogContext.Users.SingleOrDefault(user => user.Username == username);
            Run run = new Run
            {
                RanBy = user,
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

        public bool DeleteRun(string username, int id)
        {
            runLogContext.Runs.Remove(runLogContext.Runs.Find(id));
            runLogContext.SaveChanges();
            return true;
        }

        public RunsDto GetRuns(string username)
        {
            RunsDto runsDto = new RunsDto();
            List<Run> runs = runLogContext.Runs.Where(run => run.RanBy.Username == username).ToList();
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

        public bool UpdateRun(string username, int id, CreateRunDto createRunDto)
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
    }
}
