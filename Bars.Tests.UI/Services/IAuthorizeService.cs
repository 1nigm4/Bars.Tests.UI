namespace Bars.Tests.UI.Services
{
    using Bars.Tests.UI.Browsers;
    using Bars.Tests.UI.Views.Pages;

    /// <summary>
    /// Сервис авторизации
    /// </summary>
    public interface IAuthorizeService
    {
        /// <summary>
        /// Авторизация.
        /// </summary>
        /// <param name="browser">Браузер</param>
        /// <param name="returnPage">Страница возврата</param>
        /// <returns>True, если авторизация прошла успешно</returns>
        bool Authorize(Browser browser, Page returnPage, int timeoutInSec = 30);
    }
}
