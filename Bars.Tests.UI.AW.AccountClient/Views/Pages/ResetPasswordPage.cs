namespace Bars.Tests.UI.AW.AccountClient.Views.Pages
{
    using Bars.Tests.UI.Browsers;
    using Bars.Tests.UI.Configuration;
    using Bars.Tests.UI.Views.Pages;

    /// <summary>
    /// Страница Восстановление пароля
    /// </summary>
    public class ResetPasswordPage(Browser browser, Settings settings) : Page(browser, settings)
    {
        public const string EmailInput = "//input[@type='email']";
        public const string Validation = EmailInput + "/../div";
        public const string ValidationToast = "//div[@class='base-toast']/*/span";
        public const string ContinueButton = "//button[contains(@class, 'but-res-pass')]";

        public override string Url => base.Url + "reset-password";
    }
}
