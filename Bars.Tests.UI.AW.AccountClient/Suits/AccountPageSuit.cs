namespace Bars.Tests.UI.AW.AccountClient.Suits
{
    using Bars.Tests.UI.AW.AccountClient.Suits.Base;
    using Bars.Tests.UI.AW.AccountClient.Views.Pages;

    /// <summary>
    /// Тест-кейсы страницы Личный кабинет
    /// </summary>
    public class AccountPageSuit : AuthorizedSuit<AccountPage>
    {
        /// <summary>
        /// Проверка ссылок на социальные сети.
        /// Может быть длительной, т.к. с YouTube проблемы на территории РФ
        /// https://kod.ru/8447 - Google прокомментировала проблемы в работе YouTube в России
        /// </summary>
        [Test]
        public void Links()
        {
            var driver = this.browser.Driver;
            var telegramButton = string.Format(AccountPage.LinkSocialButtons, 1);
            var youTubeButton = string.Format(AccountPage.LinkSocialButtons, 2);
            var firstCaseButton = string.Format(AccountPage.LinkSocialButtons, 3);

            this.page.Click(telegramButton);
            this.page.Click(youTubeButton);
            this.page.Click(firstCaseButton);

            bool isValidLinks = true;
            var mainWindow = driver.CurrentWindowHandle;
            var otherWindows = driver.WindowHandles.Where(window => window != mainWindow);
            var links = new List<string>(AccountPage.SocialLinks);
            foreach (var window in otherWindows)
            {
                driver.SwitchTo().Window(window);
                isValidLinks &= links.Contains(driver.Url);
                links.Remove(driver.Url);
                driver.Close();
            }

            isValidLinks &= !links.Any();

            driver.SwitchTo().Window(mainWindow);
            Assert.IsTrue(isValidLinks);
        }

        /// <summary>
        /// Валидация вкладки Безопаность.
        /// Форма Смена пароля
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task SecurityValidation()
        {
            #region Валидация минимального кол-во символов и заполненности
            this.page.Click(AccountPage.SecurityTab);
            this.page.WaitElement(AccountPage.SecurityPasswordInputs);
            this.page.Write(AccountPage.SecurityPasswordInputs, "12345", index: 1);
            this.page.Write(AccountPage.SecurityPasswordInputs, "12345", index: 2);
            this.page.Click(AccountPage.SecuritySaveButton);
            this.page.WaitElement(AccountPage.SecurityValidations);
            var isCurrentPasswordInvalid = this.page.Contains(AccountPage.SecurityValidations, "Не может быть меньше 6", index: 1);
            var isNewPasswordInvalid = this.page.Contains(AccountPage.SecurityValidations, "Не может быть меньше 6", index: 2);
            var isConfirmNewPasswordInvalid = this.page.Contains(AccountPage.SecurityValidations, "Поле не заполнено", index: 3);
            Assert.IsTrue(isCurrentPasswordInvalid);
            Assert.IsTrue(isNewPasswordInvalid);
            Assert.IsTrue(isConfirmNewPasswordInvalid);
            #endregion

            await this.page.RefreshAsync();

            #region Валидация совпадения Новый пароль и Подтвердите пароль
            this.page.Click(AccountPage.SecurityTab);
            this.page.Write(AccountPage.SecurityPasswordInputs, "12345", index: 2);
            this.page.Write(AccountPage.SecurityPasswordInputs, "123456", index: 3);
            this.page.Click(AccountPage.SecuritySaveButton);
            this.page.WaitElement(AccountPage.SecurityValidations, index: 3);
            isConfirmNewPasswordInvalid = this.page.Contains(AccountPage.SecurityValidations, "Пароли не совпадают", index: 3);
            Assert.IsTrue(isConfirmNewPasswordInvalid);
            #endregion

            await this.page.RefreshAsync();

            #region Валидация Текущий пароль при сохранении
            this.page.Click(AccountPage.SecurityTab);
            this.page.Write(AccountPage.SecurityPasswordInputs, "1234567", index: 1);
            this.page.Write(AccountPage.SecurityPasswordInputs, "1234567", index: 2);
            this.page.Write(AccountPage.SecurityPasswordInputs, "1234567", index: 3);
            this.page.Click(AccountPage.SecuritySaveButton);
            this.page.WaitElement(AccountPage.SecurityValidations, index: 1);
            isCurrentPasswordInvalid = this.page.Contains(AccountPage.SecurityValidations, "Пароль введен не верно", index: 1);
            Assert.IsTrue(isCurrentPasswordInvalid);
            #endregion
        }

        /// <summary>
        /// Валидация окна Купить лицензию
        /// </summary>
        [Test]
        public void ValidationBuyLicense()
        {
            this.page.Click(AccountPage.BuyLicenseButton);

            #region Валидация пустой формы
            var total = this.page.Read(AccountPage.TotalDiv);
            var nextButton = this.page.Find(AccountPage.ModalNextButton);
            Assert.AreEqual(total, "0 ₽");
            Assert.IsFalse(nextButton.Enabled);
            #endregion

            #region Валидация успешной формы
            this.AddDevelopers(4);
            total = this.page.Read(AccountPage.TotalDiv);
            nextButton = this.page.Find(AccountPage.ModalNextButton);
            Assert.AreEqual(total, "700 000 ₽");
            Assert.IsTrue(nextButton.Enabled);
            #endregion

            #region Валидация формы Организация
            this.page.Click(AccountPage.ModalNextButton);
            this.page.Write(AccountPage.BuyLicenseInputs, " ", index: 1);
            this.page.Write(AccountPage.BuyLicenseInputs, "123", index: 2);
            this.page.Write(AccountPage.BuyLicenseInputs, "123", index: 3);
            this.page.Write(AccountPage.BuyLicenseInputs, "123", index: 4);
            this.page.WaitElement(AccountPage.BuyLicenseValidations);
            var isOrgNameInvalid = this.page.Contains(AccountPage.BuyLicenseValidations, "Поле не заполнено", index: 1);
            var isInnInvalid = this.page.Contains(AccountPage.BuyLicenseValidations, "Не может быть меньше 10", index: 2);
            var isKppInvalid = this.page.Contains(AccountPage.BuyLicenseValidations, "Не может быть меньше 9", index: 3);
            var isOgrnInvalid = this.page.Contains(AccountPage.BuyLicenseValidations, "Не может быть меньше 13", index: 4);
            Assert.IsTrue(isOrgNameInvalid);
            Assert.IsTrue(isInnInvalid);
            Assert.IsTrue(isKppInvalid);
            Assert.IsTrue(isOgrnInvalid);
            #endregion
        }

        /// <summary>
        /// Устанавливает количество разработчиков
        /// </summary>
        private void AddDevelopers(int count)
        {
            for (var i = 0; i < count; i++)
            {
                this.page.Click(AccountPage.DeveloperPlusButton);
            }
        }
    }
}
