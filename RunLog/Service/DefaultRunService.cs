using RunLog.Data;
using RunLog.Dto;
using RunLog.DTO;
using RunLog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RunLog.Service
{
    public class DefaultRunService : RunService
    {
        private readonly RunLogContext runLogContext;

        public DefaultRunService(RunLogContext runLogContext)
        {
            this.runLogContext = runLogContext;
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

        public RunDto GetRun(int id)
        {
            Run run = runLogContext.Runs
                .Include(run => run.RanBy)
                .Include(run => run.CompletedPlan)
                .First(run => run.Id == id);
            return toRunDto(run);
        }

        public RunsDto GetRuns(string username)
        {
            RunsDto runsDto = new RunsDto();
            List<Run> runs = runLogContext.Runs
                .Where(run => username.Equals(run.RanBy.Username))
                .Include(run => run.RanBy)
                .Include(run => run.CompletedPlan)
                .ToList();
            runsDto.Runs = toListOfRunDto(runs);
            return runsDto;
        }
        public RunsDto GetRunsOfCoachedAthletes(string coachName)
        {
            RunsDto runsDto = new RunsDto();
            List<Run> runs = runLogContext.Runs
                .Where(run => run.RanBy.CoachedBy.Username == coachName)
                .Include(run => run.RanBy)
                .ToList();
            runsDto.Runs = toListOfRunDto(runs);
            return runsDto;
        }

        public void LinkWithRunPlan(int runId, int runPlanId)
        {
            Run run = runLogContext.Runs.Find(runId);
            RunPlan runPlan = runLogContext.RunPlans.Find(runPlanId);
            run.CompletedPlan = runPlan;
            runLogContext.SaveChanges();

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
        private List<RunDto> toListOfRunDto(List<Run> runs)
        {
            return runs.ConvertAll<RunDto>(toRunDto);
        }

        private RunDto toRunDto(Run run)
        {
            RunPlanDto linkedRun = null;
            if(run.CompletedPlan != null)
            {
                linkedRun = new RunPlanDto
                {
                    Id = run.CompletedPlan.Id,
                    Instructions = run.CompletedPlan.Instructions,
                    Distance = run.CompletedPlan.Distance,
                    Duration = run.CompletedPlan.Duration,
                    HeartRate = run.CompletedPlan.HeartRate,
                    Date = run.CompletedPlan.Date,
                };
            }
            return new RunDto
            {
                Id = run.Id.ToString(),
                Title = run.Title,
                Description = run.Description,
                Distance = run.Distance,
                Duration = run.Duration,
                HeartRate = run.HeartRate,
                Name = run.RanBy.Username,
                CompletedRunPlan = linkedRun,
                Date = run.Date,
            };
        }
    }
}
