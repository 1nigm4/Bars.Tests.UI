namespace Bars.Tests.UI.AW.AccountClient.Views.Pages
{
    using Bars.Tests.UI.AW.AccountClient.Configurations;
    using Bars.Tests.UI.Browsers;
    using Bars.Tests.UI.Views.Pages;

    /// <summary>
    /// Страница Авторизация
    /// </summary>
    public class AuthPage : Page
    {
        public const string LoginEmailInput = "//input[@type='email']";
        public const string LoginPasswordInput = "//input[@type='password']";
        public const string LoginEntryButton = "//button[@type='submit']";
        public const string LoginValidations = "//div[contains(@class, 'error-div')]";
        public const string ResetPasswordButton = "//div[@class='container-reset-pass']/button";

        public override string Url => base.Url + "auth";

        public AuthPage(Browser driver, AWSettings settings) : base(driver, settings)
        {
        }
    }
}
