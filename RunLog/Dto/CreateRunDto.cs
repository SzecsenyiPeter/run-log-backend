using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace RunLog.DTO
{
    public class CreateRunDto
    {
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
