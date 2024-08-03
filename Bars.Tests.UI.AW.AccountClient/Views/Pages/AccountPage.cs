namespace Bars.Tests.UI.AW.AccountClient.Views.Pages
{
    using Bars.Tests.UI.AW.AccountClient.Configurations;
    using Bars.Tests.UI.Browsers;
    using Bars.Tests.UI.Views.Pages;

    /// <summary>
    /// Страница Личный кабинет
    /// </summary>
    public class AccountPage : Page
    {
        public const string LinkSocialButtons = "//div[@class='accountLinks']/*/*[{0}]/button";
        public const string SecurityTab = "//div[contains(@class, 'security')]";
        public const string SecurityPasswordInputs = "//div[@class='rows']//input";
        public const string SecurityValidations = "//div[contains(@class, 'plex-typography-body-xs')]";
        public const string SecuritySaveButton = "//div[@class='default-tabs']//button[contains(@class, 'button-save')]";

        public const string BuyLicenseButton = "//div[@class='type']/..//button";
        public const string DeveloperPlusButton = BuyLicenseModal + "//div[@class='plex-field-trigger']";
        public const string TotalDiv = BuyLicenseModal + "//div[contains(@class, 'total-sum')]";
        public const string ModalNextButton = BuyLicenseModal + "//button[contains(@class, 'save')]";

        public const string BuyLicenseInputs = BuyLicenseModal + "//input";
        public const string BuyLicenseValidations = BuyLicenseModal + "//div[contains(@class, 'plex-typography-body')]";

        private const string BuyLicenseModal = "(//div[@id='buyRenewLicense'])[3]";

        public static HashSet<string> SocialLinks = new HashSet<string>()
        {
            "https://t.me/awcommunity",
            "https://www.youtube.com/@analytic.workspace",
            "https://analyticworkspace.ru/firstcase"
        };

        public override string Url => base.Url + "account";

        public AccountPage(Browser browser, AWSettings settings) : base(browser, settings)
        {
        }
    }
}
