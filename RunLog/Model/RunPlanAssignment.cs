﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunLog.Model
{
    public class RunPlanAssignment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public int RunPlanId { get; set; }
        public RunPlan RunPlan { get; set; }
    }
}
