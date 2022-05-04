using System;
using System.Text.Json.Serialization;

namespace RunLog.Dto
{
    public class RunPlanDto
    {

        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("assignedTo")]
        public String AssignedTo { get; set; }
        [JsonPropertyName("instructions")]
        public string Instructions { get; set; }
        [JsonPropertyName("distance")]
        public int Distance { get; set; }
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
    }
}
