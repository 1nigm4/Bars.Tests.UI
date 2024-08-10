namespace Bars.Tests.UI.AW.AccountClient.Views.Pages.PersonalArea
{
    using Allure.NUnit.Attributes;
    using Bars.Tests.UI.Attributes;
    using Bars.Tests.UI.AW.AccountClient.Configurations;
    using Bars.Tests.UI.Browsers;
    using Bars.Tests.UI.Services.Interfaces;
    using Bars.Tests.UI.Views.Pages;

    /// <summary>
    /// Страница Личный кабинет
    /// </summary>
    [AllureParentSuite("Проект AW.AccountClient")]
    [AllureSuite("Личный кабинет")]
    public class AccountPage(
        Browser browser,
        IAllureService allureService,
        AWSettings settings) : Page(browser, allureService, settings)
    {
        [Element("Кнопка Присоединиться", "Кнопка Смотреть уроки", "Кнопка Реализовать кейс")]
        public const string LinkSocialButtons = "//div[@class='accountLinks']/*//button";

        [Element("Вкладка Безопасность")]
        public const string SecurityTab = "//div[contains(@class, 'security')]";

        [Element("Поле Текущий пароль", "Поле Новый пароль", "Поле Подтвердите пароль")]
        public const string SecurityPasswordInputs = "//div[@class='rows']//input";

        [Element("Валидация поля Текущий пароль", "Валидация поля Новый пароль", "Валидация поля Подтвердите пароль")]
        public const string SecurityValidations = "//div[contains(@class, 'plex-typography-body-xs')]";

        [Element("Кнопка Сохранить изменения")]
        public const string SecuritySaveButton = "//div[@class='default-tabs']//button[contains(@class, 'button-save')]";

        [Element("Кнопка Купить лицензию")]
        public const string BuyLicenseButton = "//div[@class='type']/..//button";

        [Element("Кнопка Добавить разработчика")]
        public const string DeveloperPlusButton = BuyLicenseModal + "//div[@class='plex-field-trigger']";

        [Element("Поле Итого")]
        public const string TotalDiv = BuyLicenseModal + "//div[contains(@class, 'total-sum')]";

        [Element("Кнопка Далее")]
        public const string ModalNextButton = BuyLicenseModal + "//button[contains(@class, 'save')]";

        [Element("Поле Полное наименование организации", "Поле ИНН", "Поле КПП", "Поле ОГРН")]
        public const string BuyLicenseInputs = BuyLicenseModal + "//input";

        [Element("Валидация поля Полное наименование организации", "Валидация поля ИНН", "Валидация поля КПП", "Валидация поля ОГРН")]
        public const string BuyLicenseValidations = BuyLicenseModal + "//div[contains(@class, 'plex-typography-body')]";

        private const string BuyLicenseModal = "(//div[@id='buyRenewLicense'])[3]";

        public static HashSet<string> SocialLinks = new HashSet<string>()
        {
            "https://t.me/awcommunity",
            "https://www.youtube.com/@analytic.workspace",
            "https://analyticworkspace.ru/firstcase"
        };

        public override string Url => base.Url + "account";
    }
}
