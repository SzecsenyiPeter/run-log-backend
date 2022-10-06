using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunLog.Model
{
    public class RunPlan
    {
        public int Id { get; set; }
        public User CreatedBy { get; set; }
        public string Instructions { get; set; }
        public int? Duration { get; set; }
        public int? HeartRate { get; set; }
        public int Distance { get; set; }
        public DateTime Date { get; set; }
    }
}
