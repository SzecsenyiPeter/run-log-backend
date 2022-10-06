using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RunLog.Dto
{
    public class CreateRunPlanDto
    {
        [JsonPropertyName("assignedTo")]
        [Required]
        public List<String> AssignedTo { get; set; }
        [JsonPropertyName("instructions")]
        [Required]
        public string Instructions { get; set; }
        [JsonPropertyName("distance")]
        [Required]
        public int Distance { get; set; }
        [JsonPropertyName("heartRate")]
        public int? HeartRate { get; set; }
        [JsonPropertyName("duration")]
        public int? Duration { get; set; }
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
    }
}
