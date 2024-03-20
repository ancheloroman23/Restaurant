using System.Text.Json.Serialization;

namespace Restaurant.Core.Application.Dtos.Account
{
    public class LoginResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Error { get; set; }
        public bool HasError { get; set; }        
        public string JWToken { get; set; }
        public List<string> Roles { get; set; }

        [JsonIgnore]
        public string RefreshToken { get; set; }
    }
}
