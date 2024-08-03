namespace Bars.Tests.UI.Extensions
{
    using Bars.Tests.UI.Browsers;
    using Bars.Tests.UI.Configuration;
    using Bars.Tests.UI.Views.Pages;

    /// <summary>
    /// Расширения для браузера
    /// </summary>
    public static class BrowserExtensions
    {
        /// <summary>
        /// Создание страницы.
        /// Метод создан для извлечения Url адреса страницы.
        /// </summary>
        /// <typeparam name="TPage">Тип страницы</typeparam>
        /// <param name="browser">Браузер</param>
        /// <param name="settings">Настройки</param>
        /// <returns>Страница</returns>
        public static TPage CreatePage<TPage>(this Browser browser, Settings settings) where TPage : Page
        {
            return (TPage)Activator.CreateInstance(typeof(TPage), browser, settings)!;
        }
    }
}
