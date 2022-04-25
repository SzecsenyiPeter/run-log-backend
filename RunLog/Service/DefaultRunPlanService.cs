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
            List<User> assignedTo = runLogContext
                .Users
                .Where(user => createRunPlanDto.AssignedTo.Contains(user.Username))
                .ToList();
            RunPlan runPlan = new RunPlan
            {
                CreatedBy = user,
                AssignedTo = assignedTo,
                Instructions = createRunPlanDto.Instructions,
                Distance = createRunPlanDto.Distance,
                Date = createRunPlanDto.Date,
            };
            runLogContext.RunPlans.Add(runPlan);
            runLogContext.SaveChanges();
        }
    }
}
