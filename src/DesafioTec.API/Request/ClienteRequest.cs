using System.Text.Json.Serialization;

namespace DesafioTec.API.Request
{
    public class ClienteRequest
    {
        [JsonIgnore]
        public int ClienteId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
