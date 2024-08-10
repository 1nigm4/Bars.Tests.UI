namespace Bars.Tests.UI.Configuration
{
    using Newtonsoft.Json;

    /// <summary>
    /// Настройки Selenoid
    /// </summary>
    public class RemoteSettings
    {
        /// <summary>
        /// Включить показ экрана браузера
        /// </summary>
        [JsonProperty("enableVNC")]
        public bool EnableVNC { get; set; }

        /// <summary>
        /// Включить запись экрана браузера
        /// </summary>
        [JsonProperty("enableVideo")]
        public bool EnableVideo { get; set; }

        /// <summary>
        /// Версия браузера
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
