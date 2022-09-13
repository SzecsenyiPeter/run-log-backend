using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RunLog.DTO
{
    public class RunDto
    {
        [JsonPropertyName("id")]
        [Required]
        public string Id { get; set; }
        [JsonPropertyName("title")]
        [Required]
        public string Title { get; set; }

        [JsonPropertyName("name")]
        [Required]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("durationInSeconds")]
        [Required]
        public int Duration { get; set; }

        [JsonPropertyName("distanceInMeters")]
        [Required]
        public int Distance { get; set; }

        [JsonPropertyName("heartRate")]
        [Required]
        public int HeartRate { get; set; }

        [JsonPropertyName("date")]
        [Required]
        public DateTime Date { get; set; }
    }
}
