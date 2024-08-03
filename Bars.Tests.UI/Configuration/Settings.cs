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
    }
}
