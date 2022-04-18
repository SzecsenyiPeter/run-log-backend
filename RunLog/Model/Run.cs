using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunLog.Model
{
    public class Run
    {
        public int Id { get; set; }
        public User RanBy { get; set; }
        public RunPlan CompletedPlan { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int Duration { get; set; }

        public int Distance { get; set; }

        public int HeartRate { get; set; }

        public DateTime Date { get; set; }
    }
}
