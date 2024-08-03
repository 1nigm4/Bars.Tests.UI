namespace Bars.Tests.UI.AW.AccountClient.Configurations
{
    using Bars.Tests.UI.Configuration;

    /// <summary>
    /// <inheritdoc/>
    /// Конфигурация сайта.
    /// </summary>
    public class AWSettings : Settings
    {
        /// <summary>
        /// Логин (почта)
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }
    }
}
