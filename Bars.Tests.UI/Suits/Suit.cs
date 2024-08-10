namespace Bars.Tests.UI.Suits
{
    using Allure.Net.Commons;
    using Allure.NUnit;
    using Bars.Tests.UI.Browsers;
    using Bars.Tests.UI.Configuration;
    using Bars.Tests.UI.Extensions;
    using Bars.Tests.UI.Services;
    using Bars.Tests.UI.Views.Pages;
    using NUnit.Framework;

    /// <summary>
    /// Абстрактный класс тест-кейсов
    /// </summary>
    /// <typeparam name="TPage"></typeparam>
    [TestFixture]
    [Parallelizable]
    [AllureNUnit]
    public abstract class Suit<TPage> where TPage : Page
    {
        protected Browser browser;
        protected Settings settings;
        protected TPage page;

        /// <summary>
        /// Однократная инициализация тест-кейса.
        /// Создает конфигурацию, браузер и страницу.
        /// </summary>
        [OneTimeSetUp]
        public virtual void Initialize()
        {
            this.settings ??= new Settings();
            var configBuilder = new ConfigBuilder();
            configBuilder.Configure(this.settings);

            var lifecycle = AllureLifecycle.Instance;

            var browserBuilder = new BrowserBuilder();
            this.browser = browserBuilder.Build(this.settings);
            this.page = this.browser.CreatePage<TPage>(lifecycle, this.settings);
        }

        /// <summary>
        /// Перед каждым тестом.
        /// Если не на странице - переходит на нее
        /// </summary>
        /// <returns></returns>
        [SetUp]
        public virtual async Task SetupAsync()
        {
            var isInPage = this.browser.Driver.Url.Contains(page.Url);
            if (!isInPage)
            {
                await this.page.OpenAsync();
            }
        }

        /// <summary>
        /// Однократная утилизация тест-кейса
        /// </summary>
        [OneTimeTearDown]
        public virtual void Dispose()
        {
            this.browser.Dispose();
        }
    }
}
