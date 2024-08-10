namespace Bars.Tests.UI.AW.AccountClient.Views.Pages.Authentication
{
    using Allure.NUnit.Attributes;
    using Bars.Tests.UI.Attributes;
    using Bars.Tests.UI.AW.AccountClient.Configurations;
    using Bars.Tests.UI.Browsers;
    using Bars.Tests.UI.Services.Interfaces;
    using Bars.Tests.UI.Views.Pages;

    /// <summary>
    /// Страница Авторизация
    /// </summary>
    [AllureParentSuite("Проект AW.AccountClient")]
    [AllureSuite("Аутентификация")]
    [AllureSubSuite("Авторизация")]
    public class AuthPage(
        Browser driver,
        IAllureService allureService,
        AWSettings settings) : Page(driver, allureService, settings)
    {
        [Element("Поле Почта")]
        public const string LoginEmailInput = "//input[@type='email']";

        [Element("Поле Пароль")]
        public const string LoginPasswordInput = "//input[@type='password']";

        [Element("Кнопка Войти")]
        public const string LoginEntryButton = "//button[@type='submit']";

        [Element("Валидация поля Почта", "Валидация поля Пароль")]
        public const string LoginValidations = "//div[contains(@class, 'error-div')]";

        [Element("Кнопка Забыли пароль")]
        public const string ResetPasswordButton = "//div[@class='container-reset-pass']/button";

        public override string Url => base.Url + "auth";
    }
}
