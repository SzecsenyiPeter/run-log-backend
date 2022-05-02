using RunLog.Dto;
using RunLog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunLog.Service
{
    public interface RunPlanService
    {
        public void CreateRunPlan(string user, CreateRunPlanDto createRunPlanDto);
        public ICollection<RunPlan> GetRunPlans(string username);
    }
}
