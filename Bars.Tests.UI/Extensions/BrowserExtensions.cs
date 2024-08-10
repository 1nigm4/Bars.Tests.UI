namespace Bars.Tests.UI.Extensions
{
    using Allure.Net.Commons;
    using Bars.Tests.UI.Browsers;
    using Bars.Tests.UI.Configuration;
    using Bars.Tests.UI.Services;
    using Bars.Tests.UI.Services.Interfaces;
    using Bars.Tests.UI.Views.Pages;

    /// <summary>
    /// Расширения для браузера
    /// </summary>
    public static class BrowserExtensions
    {
        /// <inheritdoc cref="CreatePage{TPage}(Browser, IAllureService, Settings)"/>
        /// <param name="lifecycle">Allure контекст</param>
        public static TPage CreatePage<TPage>(
            this Browser browser,
            AllureLifecycle lifecycle,
            Settings settings) where TPage : Page
        {
            var allureService = new AllureService(lifecycle);
            return browser.CreatePage<TPage>(allureService, settings);
        }

        /// <summary>
        /// Создание страницы.
        /// Метод создан для извлечения Url адреса страницы.
        /// </summary>
        /// <typeparam name="TPage">Тип страницы</typeparam>
        /// <param name="browser">Браузер</param>
        /// <param name="allureService">Allure сервис</param>
        /// <param name="settings">Настройки</param>
        /// <returns>Страница</returns>
        public static TPage CreatePage<TPage>(
            this Browser browser,
            IAllureService allureService,
            Settings settings) where TPage : Page
        {
            return (TPage)Activator.CreateInstance(typeof(TPage), browser, allureService, settings)!;
        }
    }
}
