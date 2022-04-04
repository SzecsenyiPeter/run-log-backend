using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using RunLog.Model;

namespace RunLog.Dto
{
    public class UserDto
    {
        [JsonPropertyName("username")]
        [Required]
        public string Username { get; set; }
        [JsonPropertyName("password")]
        [Required]
        public string Password { get; set; }

        [JsonPropertyName("userType")]
        [Required]
        public UserTypes UserType { get; set; }

    }
}
