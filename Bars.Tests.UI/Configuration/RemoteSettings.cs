namespace Bars.Tests.UI.Configuration
{
    using Newtonsoft.Json;

    public class RemoteSettings
    {
        [JsonProperty("enableVNC")]
        public bool EnableVNC { get; set; }

        [JsonProperty("enableVideo")]
        public bool EnableVideo { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
