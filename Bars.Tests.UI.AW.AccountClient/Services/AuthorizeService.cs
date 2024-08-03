namespace Bars.Tests.UI.AW.AccountClient.Services
{
    using Bars.Tests.UI.AW.AccountClient.Configurations;
    using Bars.Tests.UI.AW.AccountClient.Views.Pages;
    using Bars.Tests.UI.Browsers;
    using Bars.Tests.UI.Extensions;
    using Bars.Tests.UI.Services;
    using Bars.Tests.UI.Views.Pages;

    /// <summary>
    /// <inheritdoc cref="IAuthorizeService"/>
    /// </summary>
    public class AuthorizeService : IAuthorizeService
    {
        /// <summary>
        /// <inheritdoc/>
        /// <para>Если не получилось автоматически авторизоваться, то в течении <paramref name="timeoutInSec"/> секунд
        /// есть возможность вручную авторизоваться</para>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public bool Authorize(Browser browser, Page returnPage, int timeoutInSec = 30)
        {
            if (returnPage.Settings is not AWSettings awSettings)
            {
                throw new ArgumentNullException(nameof(returnPage.Settings));
            }

            var authPage = browser.CreatePage<AuthPage>(awSettings);
            var needAuthorize = browser.Driver.Url.Contains(authPage.Url);
            if (needAuthorize)
            {
                authPage.Write(AuthPage.LoginEmailInput, awSettings.Login);
                authPage.Write(AuthPage.LoginPasswordInput, awSettings.Password);
                authPage.Click(AuthPage.LoginEntryButton);
                authPage.WaitNavigate(returnPage, timeoutInSec: timeoutInSec);
            }

            return true;
        }
    }
}
