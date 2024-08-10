namespace Bars.Tests.UI.AW.AccountClient.Views.Pages.Authentication
{
    using Allure.NUnit.Attributes;
    using Bars.Tests.UI.Attributes;
    using Bars.Tests.UI.Browsers;
    using Bars.Tests.UI.Configuration;
    using Bars.Tests.UI.Services.Interfaces;
    using Bars.Tests.UI.Views.Pages;

    /// <summary>
    /// Страница Восстановление пароля
    /// </summary>
    [AllureParentSuite("Проект AW.AccountClient")]
    [AllureSuite("Аутентификация")]
    [AllureSubSuite("Забыли пароль")]
    public class ResetPasswordPage(
        Browser browser,
        IAllureService allureService,
        Settings settings) : Page(browser, allureService, settings)
    {
        [Element("Поле Почта")]
        public const string EmailInput = "//input[@type='email']";

        [Element("Валидация поля Почта")]
        public const string Validation = EmailInput + "/../div";

        [Element("Всплывающая валидации")]
        public const string ValidationToast = "//div[@class='base-toast']/*/span";

        [Element("Кнопка Продолжить")]
        public const string ContinueButton = "//button[contains(@class, 'but-res-pass')]";

        public override string Url => base.Url + "reset-password";
    }
}
