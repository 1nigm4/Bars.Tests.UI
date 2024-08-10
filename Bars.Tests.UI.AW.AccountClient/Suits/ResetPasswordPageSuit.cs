namespace Bars.Tests.UI.AW.AccountClient.Suits
{
    using Bars.Tests.UI.AW.AccountClient.Views.Pages.Authentication;
    using Bars.Tests.UI.Suits;
    using SeleniumExtras.WaitHelpers;

    /// <summary>
    /// Тест-кейсы страницы Восстановление пароля
    /// </summary>
    [TestFixture]
    public class ResetPasswordPageSuit : Suit<ResetPasswordPage>
    {
        /// <summary>
        /// Валидация формы Восстановление пароля
        /// </summary>
        [Test]
        public void Validation()
        {
            #region Валидация корректности почты
            this.Page.Write(ResetPasswordPage.EmailInput, "aasdasdasd");
            this.Page.WaitElement(ResetPasswordPage.Validation);
            var isEmailInvalid = this.Page.Contains(ResetPasswordPage.Validation, "Не корректный email адрес");
            Assert.IsTrue(isEmailInvalid);
            #endregion

            #region Валидация существования почты в системе
            this.Page.Write(ResetPasswordPage.EmailInput, "aw@aw.aw");
            this.Page.Click(ResetPasswordPage.ContinueButton);
            this.Page.WaitElement(ResetPasswordPage.ValidationToast, condition: ExpectedConditions.ElementIsVisible);
            isEmailInvalid = this.Page.Contains(ResetPasswordPage.ValidationToast, "Почта не найдена");
            Assert.IsTrue(isEmailInvalid);
            #endregion
        }
    }
}