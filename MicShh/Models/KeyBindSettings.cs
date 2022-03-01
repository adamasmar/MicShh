using System.Text.Json.Serialization;

namespace MicShh.Models
{
    public class KeyBindSettings
    {
        [JsonPropertyName("DefaultKeyBind")]
        public KeyBind? DefaultKeyBind { get; set; }

        [JsonPropertyName("UserKeyBind")]
        public KeyBind? UserKeyBind { get; set; }
    }
}
