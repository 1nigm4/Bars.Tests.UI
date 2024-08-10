namespace Bars.Tests.UI.AW.AccountClient.Suits
{
    using Bars.Tests.UI.AW.AccountClient.Configurations;
    using Bars.Tests.UI.AW.AccountClient.Services;
    using Bars.Tests.UI.AW.AccountClient.Views.Pages.Authentication;
    using Bars.Tests.UI.AW.AccountClient.Views.Pages.PersonalArea;
    using Bars.Tests.UI.Extensions;
    using Bars.Tests.UI.Services.Interfaces;
    using Bars.Tests.UI.Suits;

    /// <summary>
    /// Тест-кейсы страницы Авторизация
    /// </summary>
    [Order(0)]
    public class AuthPageSuit : Suit<AuthPage>
    {
        private IAuthorizeService authorizeService;

        public override void Initialize()
        {
            this.authorizeService = new AuthorizeService();
            this.Settings = new AWSettings();
            base.Initialize();
        }

        /// <summary>
        /// Валидация формы Авторизации
        /// </summary>
        [Test, Order(1)]
        public async Task Validation()
        {
            #region Валидация корректных данных
            this.Page.Write(AuthPage.LoginEmailInput, "test@bars.group");
            this.Page.Write(AuthPage.LoginPasswordInput, "123456");
            this.Page.Click(AuthPage.LoginEntryButton);
            this.Page.WaitElement(AuthPage.LoginValidations);
            var isInvalidAuth = this.Page.Contains(AuthPage.LoginValidations, "Неправильный логин или пароль", index: 1);
            Assert.That(isInvalidAuth);
            #endregion

            await this.Page.RefreshAsync();

            #region Валидация ограничений полей
            this.Page.Write(AuthPage.LoginEmailInput, "test");
            this.Page.Write(AuthPage.LoginPasswordInput, "123");
            this.Page.WaitElement(AuthPage.LoginValidations);
            var isInvalidEmail = this.Page.Contains(AuthPage.LoginValidations, "Не корректный email адрес", index: 1);
            var isInvalidPassword = this.Page.Contains(AuthPage.LoginValidations, "Минимальное количество символов: 6", index: 2);
            Assert.Multiple(() =>
            {
                Assert.That(isInvalidEmail);
                Assert.That(isInvalidPassword);
            });
            #endregion
        }

        /// <summary>
        /// Переход на страницу Восстановление пароля
        /// </summary>
        [Test, Order(2)]
        public void ResetPass()
        {
            this.Page.Click(AuthPage.ResetPasswordButton);
            this.Page.WaitNavigate<ResetPasswordPage>();
            Assert.Pass();
        }

        /// <summary>
        /// Авторизация
        /// </summary>
        [Test, Order(3)]
        public void Login()
        {
            var accountPage = this.Browser.CreatePage<AccountPage>(this.Page.AllureService, this.Page.Settings);
            var isAuthorized = this.authorizeService.Authorize(this.Browser, accountPage);
            Assert.That(isAuthorized);
        }
    }
}
