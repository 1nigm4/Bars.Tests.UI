namespace Bars.Tests.UI.AW.AccountClient.Suits
{
    using Bars.Tests.UI.AW.AccountClient.Configurations;
    using Bars.Tests.UI.AW.AccountClient.Services;
    using Bars.Tests.UI.AW.AccountClient.Views.Pages;
    using Bars.Tests.UI.Extensions;
    using Bars.Tests.UI.Services;
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
            this.settings = new AWSettings();
            base.Initialize();
        }

        /// <summary>
        /// Валидация формы Авторизации
        /// </summary>
        [Test, Order(1)]
        public async Task Validation()
        {
            #region Валидация корректных данных
            this.page.Write(AuthPage.LoginEmailInput, "test@bars.group");
            this.page.Write(AuthPage.LoginPasswordInput, "123456");
            this.page.Click(AuthPage.LoginEntryButton);
            this.page.WaitElement(AuthPage.LoginValidations);
            var isInvalidAuth = this.page.Contains(AuthPage.LoginValidations, "Неправильный логин или пароль", index: 1);
            Assert.IsTrue(isInvalidAuth);
            #endregion

            await this.page.RefreshAsync();

            #region Валидация ограничений полей
            this.page.Write(AuthPage.LoginEmailInput, "test");
            this.page.Write(AuthPage.LoginPasswordInput, "123");
            this.page.WaitElement(AuthPage.LoginValidations);
            var isInvalidEmail = this.page.Contains(AuthPage.LoginValidations, "Не корректный email адрес", index: 1);
            var isInvalidPassword = this.page.Contains(AuthPage.LoginValidations, "Минимальное количество символов: 6", index: 2);
            Assert.IsTrue(isInvalidEmail);
            Assert.IsTrue(isInvalidPassword);
            #endregion
        }

        /// <summary>
        /// Переход на страницу Восстановление пароля
        /// </summary>
        [Test, Order(2)]
        public void ResetPass()
        {
            this.page.Click(AuthPage.ResetPasswordButton);
            this.page.WaitNavigate<ResetPasswordPage>();
            Assert.Pass();
        }

        /// <summary>
        /// Авторизация
        /// </summary>
        [Test, Order(3)]
        public void Login()
        {
            var accountPage = this.browser.CreatePage<AccountPage>(this.page.Settings);
            var authorized = this.authorizeService.Authorize(this.browser, accountPage);
            Assert.IsTrue(authorized);
        }
    }
}
