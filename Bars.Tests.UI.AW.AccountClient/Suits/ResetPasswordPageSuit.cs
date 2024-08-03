namespace Bars.Tests.UI.AW.AccountClient.Suits
{
    using Bars.Tests.UI.AW.AccountClient.Views.Pages;
    using Bars.Tests.UI.Suits;
    using SeleniumExtras.WaitHelpers;

    /// <summary>
    /// Тест-кейсы страницы Восстановление пароля
    /// </summary>
    public class ResetPasswordPageSuit : Suit<ResetPasswordPage>
    {
        /// <summary>
        /// Валидация формы Восстановление пароля
        /// </summary>
        [Test]
        public void Validation()
        {
            #region Валидация корректности почты
            this.page.Write(ResetPasswordPage.EmailInput, "aasdasdasd");
            this.page.WaitElement(ResetPasswordPage.Validation);
            var isEmailInvalid = this.page.Contains(ResetPasswordPage.Validation, "Не корректный email адрес");
            Assert.IsTrue(isEmailInvalid);
            #endregion

            #region Валидация существования почты в системе
            this.page.Write(ResetPasswordPage.EmailInput, "aw@aw.aw");
            this.page.Click(ResetPasswordPage.ContinueButton);
            this.page.WaitElement(ResetPasswordPage.ValidationToast, condition: ExpectedConditions.ElementIsVisible);
            isEmailInvalid = this.page.Contains(ResetPasswordPage.ValidationToast, "Почта не найдена");
            Assert.IsTrue(isEmailInvalid);
            #endregion
        }
    }
}