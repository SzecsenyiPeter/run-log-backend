using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace RunLog.DTO
{
    public class CreateRunDto
    {
        [JsonPropertyName("title")]
        [Required]
        public string Title { get; set; }
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
