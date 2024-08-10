namespace Bars.Tests.UI.Configuration
{
    /// <summary>
    /// Настройки тестирования.
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// Базовый адрес
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Наименование браузера
        /// </summary>
        public string Browser { get; set; }

        /// <summary>
        /// Параметры запуска браузера
        /// </summary>
        public string[] Arguments { get; set; }

        /// <summary>
        /// Адрес Selenoid
        /// </summary>
        public string RemoteUrl { get; set; }

        /// <summary>
        /// В удаленном режиме
        /// </summary>
        public bool InRemoteMode { get; set; }

        /// <summary>
        /// Настройки Selenoid
        /// </summary>
        public RemoteSettings RemoteSettings { get; set; }
    }
}
