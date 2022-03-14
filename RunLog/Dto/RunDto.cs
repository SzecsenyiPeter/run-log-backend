using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace RunLog.DTO
{
    public class RunDto
    {
        [DataMember(Name="id")]
        [Required]
        public string Id { get; set; }
        [DataMember(Name="title")]
        [Required]
        public string Title { get; set; }
        [DataMember(Name="description")]
        public string Description { get; set; }

        [DataMember(Name="durationInSeconds")]
        [Required]
        public int Duration { get; set; }

        [DataMember(Name="distanceInMeters")]
        [Required]
        public int Distance { get; set; }

        [DataMember(Name="heartRate")]
        [Required]
        public int HeartRate { get; set; }

        [DataMember(Name="date")]
        [Required]
        public DateTime Date { get; set; }
    }
}
