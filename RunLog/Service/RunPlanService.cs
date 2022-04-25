using RunLog.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunLog.Service
{
    public interface RunPlanService
    {
        public void CreateRunPlan(string user, CreateRunPlanDto createRunPlanDto);
    }
}
