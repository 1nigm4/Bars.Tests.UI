namespace Bars.Tests.UI.Browsers
{
    using Bars.Tests.UI.Configuration;
    using OpenQA.Selenium;

    /// <summary>
    /// Абстрактный класс браузера
    /// </summary>
    public abstract class Browser : IDisposable
    {
        public WebDriver Driver { get; protected set; }
        protected Settings Settings { get; init; }

        protected Browser(Settings settings)
        {
            this.Settings = settings;
            this.Initialize();
        }

        /// <summary>
        /// Высвобождение занятых ресурсов
        /// </summary>
        public virtual void Dispose()
        {
            this.Driver?.Dispose();
        }

        /// <summary>
        /// Инициализация драйвера
        /// </summary>
        protected abstract void Initialize();
    }
}
