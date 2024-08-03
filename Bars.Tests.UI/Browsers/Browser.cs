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
        protected Settings settings;

        protected Browser(Settings settings)
        {
            this.settings = settings;
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
