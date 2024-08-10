namespace Bars.Tests.UI.Services.Implementations
{
    using Bars.Tests.UI.Services.Interfaces;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public class BrowserWait : DefaultWait<IWebDriver>, IBrowserWait
    {
        public BrowserWait(IWebDriver input) : base(input)
        {
        }

        public void SetTimeout(int seconds)
        {
            this.Timeout = TimeSpan.FromSeconds(seconds);
        }
    }
}
