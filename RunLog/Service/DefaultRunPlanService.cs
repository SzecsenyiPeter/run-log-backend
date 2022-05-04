using RunLog.Data;
using RunLog.Dto;
using RunLog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunLog.Service
{
    public class DefaultRunPlanService : RunPlanService
    {
        private readonly RunLogContext runLogContext;

        public DefaultRunPlanService()
        {
            runLogContext = new RunLogContext();
        }
        public void CreateRunPlan(string username, CreateRunPlanDto createRunPlanDto)
        {
            User user = runLogContext.Users.SingleOrDefault(user => user.Username == username);
            RunPlan runPlan = new RunPlan
            {
                CreatedBy = user,
                Instructions = createRunPlanDto.Instructions,
                Distance = createRunPlanDto.Distance,
                Date = createRunPlanDto.Date,
            };
            runLogContext.RunPlans.Add(runPlan);
            runLogContext.SaveChanges();
            ICollection<User> usersAssignedTo = runLogContext
                .Users
                .Where(user => createRunPlanDto.AssignedTo.Contains(user.Username))
                .ToList();
            foreach (User assignedTo in usersAssignedTo)
            {
                runLogContext.RunPlanAssignments.Add(new RunPlanAssignment{
                    RunPlan = runPlan,
                    RunPlanId = runPlan.Id,
                    User = assignedTo,
                    UserId = assignedTo.Id,
                });
            }
            runLogContext.SaveChanges();
        }
        public ICollection<RunPlanDto> GetRunPlans(string username)
        {
            User user = runLogContext.Users.SingleOrDefault(user => user.Username == username);
            return runLogContext.RunPlanAssignments
                .Where(runPlanAssigment => runPlanAssigment.UserId == user.Id)
                .ToList()
                .ConvertAll(runPlanAssignment => runLogContext.RunPlans.Where(runPlan => runPlan.Id == runPlanAssignment.Id).First())
                .ConvertAll(runPlan => new RunPlanDto
                {
                    Id = runPlan.Id,
                    AssignedTo = username,
                    Instructions = runPlan.Instructions,
                    Distance = runPlan.Distance,
                    Date = runPlan.Date,
                }) ;
        }
    }
}
