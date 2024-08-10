namespace Bars.Tests.UI.Services.Interfaces
{
    using Bars.Tests.UI.Browsers;
    using Bars.Tests.UI.Configuration;

    /// <summary>
    /// Билдер браузера
    /// </summary>
    public interface IBrowserBuilder
    {
        /// <summary>
        /// Создает браузер.
        /// </summary>
        /// <param name="settings">Настройки</param>
        /// <returns>Браузер</returns>
        Browser Build(Settings settings);
    }
}
