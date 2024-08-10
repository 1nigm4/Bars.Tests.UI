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
        protected Browser Browser { get; private set; }
        protected Settings Settings { get; set; }
        protected TPage Page { get; private set; }
        protected string MainWindow { get; private set; }

        /// <summary>
        /// Однократная инициализация тест-кейса.
        /// Создает конфигурацию, браузер и страницу.
        /// Привязывает контекст Allure к странице.
        /// </summary>
        [OneTimeSetUp]
        public virtual void Initialize()
        {
            this.Settings ??= new Settings();
            var configBuilder = new ConfigBuilder();
            configBuilder.Configure(this.Settings);

            var lifecycle = AllureLifecycle.Instance;

            var browserBuilder = new BrowserBuilder();
            this.Browser = browserBuilder.Build(this.Settings);
            this.Page = this.Browser.CreatePage<TPage>(lifecycle, this.Settings);
        }

        /// <summary>
        /// Перед каждым тестом.
        /// Если текущая страница браузера не совпадает
        /// с адресом страницы, то переходит на нее.
        /// </summary>
        [SetUp]
        public virtual async Task SetupAsync()
        {
            var driver = this.Browser.Driver;
            this.MainWindow = driver.CurrentWindowHandle;
            var isInPage = driver.Url.Contains(Page.Url);
            if (!isInPage)
            {
                await this.Page.OpenAsync();
            }
        }

        /// <summary>
        /// После каждого теста.
        /// Переключает на главную вкладку.
        /// </summary>
        [TearDown]
        public virtual async Task TeadDownAsync()
        {
            try
            {
                this.Browser.Driver.SwitchTo()
                .Window(this.MainWindow);
            }
            catch
            {
                await this.Page.OpenAsync();
            }
        }

        /// <summary>
        /// Однократная утилизация тест-кейса
        /// </summary>
        [OneTimeTearDown]
        public virtual void Dispose()
        {
            this.Browser.Dispose();
        }
    }
}
