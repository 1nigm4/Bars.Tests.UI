namespace Bars.Tests.UI.Services.Implementations
{
    using Bars.Tests.UI.Services.Interfaces;
    using OpenQA.Selenium;

    public abstract class Browser : IBrowser
    {
        public IWebDriver Driver { get; private set; }

        protected Browser(IWebDriver driver)
        {
            Driver = driver;
        }

        public virtual void Dispose()
        {
            Driver.Dispose();
        }
    }
}
