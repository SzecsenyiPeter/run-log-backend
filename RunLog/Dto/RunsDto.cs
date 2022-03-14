using RunLog.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace RunLog.Dto
{
    public class RunsDto
    {
        [DataMember(Name="runs")]
        [Required]
        public List<RunDto> Runs { get; set; }
    }
}
