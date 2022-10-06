using RunLog.Dto;
using RunLog.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunLog.Service
{
    public interface RunService
    {
        public RunsDto GetRuns(string username);
        public RunDto GetRun(int id);
        public RunsDto GetRunsOfCoachedAthletes(string coachName);
        public bool CreateRun(string username, CreateRunDto createRunDto);
        public void LinkWithRunPlan(int runId, int runPlanId);
        public bool UpdateRun(string username, int id, CreateRunDto createRunDto);
        public bool DeleteRun(string username, int id);


    }
}
