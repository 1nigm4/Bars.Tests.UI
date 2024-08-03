namespace Bars.Tests.UI.AW.AccountClient.Suits.Base
{
    using System.Threading.Tasks;
    using Bars.Tests.UI.AW.AccountClient.Configurations;
    using Bars.Tests.UI.AW.AccountClient.Services;
    using Bars.Tests.UI.Services;
    using Bars.Tests.UI.Suits;
    using Bars.Tests.UI.Views.Pages;

    /// <summary>
    /// Абстрактный класс тест-кейса требующего аутентификацию
    /// </summary>
    /// <typeparam name="TPage"></typeparam>
    public abstract class AuthorizedSuit<TPage> : Suit<TPage> where TPage : Page
    {
        private readonly IAuthorizeService authorizeService;

        public AuthorizedSuit()
        {
            this.authorizeService = new AuthorizeService();
        }

        public override void Initialize()
        {
            // Костыль - явная инициализация настроек (нет DI)
            this.settings = new AWSettings();
            base.Initialize();
        }

        /// <summary>
        /// <inheritdoc/>
        /// Проверяет, авторизирован ли пользователь, если нет - авторизирует
        /// </summary>
        /// <returns></returns>
        public override async Task SetupAsync()
        {
            await base.SetupAsync();
            var authorized = this.authorizeService.Authorize(browser, page);
            if (authorized)
            {
                await base.SetupAsync();
            }
        }
    }
}
