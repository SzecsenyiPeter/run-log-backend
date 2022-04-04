using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RunLog.Dto
{
    public class LoginUserDto
    {
        [JsonPropertyName("username")]
        [Required]
        public string Username { get; set; }
        [JsonPropertyName("password")]
        [Required]
        public string Password { get; set; }
    }
}
