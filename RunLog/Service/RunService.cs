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
        public bool CreateRun(string username, CreateRunDto createRunDto);
        public bool UpdateRun(string username, int id, CreateRunDto createRunDto);
        public bool DeleteRun(string username, int id);


    }
}
