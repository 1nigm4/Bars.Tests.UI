namespace Bars.Tests.UI.AW.AccountClient.Suits.Base
{
    using System.Threading.Tasks;
    using Bars.Tests.UI.AW.AccountClient.Configurations;
    using Bars.Tests.UI.AW.AccountClient.Services;
    using Bars.Tests.UI.Services.Interfaces;
    using Bars.Tests.UI.Suits;
    using Bars.Tests.UI.Views.Pages;

    /// <summary>
    /// Абстрактный класс тест-кейса требующего аутентификацию
    /// </summary>
    /// <typeparam name="TPage">Страница</typeparam>
    public abstract class AuthorizedSuit<TPage> : Suit<TPage> where TPage : Page
    {
        private IAuthorizeService authorizeService;

        /// <inheritdoc/>
        public override void Initialize()
        {
            // Костыль - явная инициализация настроек (нет DI)
            this.Settings = new AWSettings();
            this.authorizeService = new AuthorizeService();
            base.Initialize();
        }

        /// <summary>
        /// <inheritdoc/>
        /// Проверяет, авторизирован ли пользователь, если нет - авторизирует
        /// </summary>
        public override async Task SetupAsync()
        {
            await base.SetupAsync();
            var authorized = this.authorizeService.Authorize(this.Browser, this.Page);
            if (authorized)
            {
                await base.SetupAsync();
            }
        }
    }
}
