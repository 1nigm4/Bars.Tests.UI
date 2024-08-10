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
        /// Создает браузер по имени с параметрами запуска.
        /// </summary>
        /// <param name="name">Наименование браузера</param>
        /// <returns>Браузер</returns>
        Browser Build(Settings settings);
    }
}
