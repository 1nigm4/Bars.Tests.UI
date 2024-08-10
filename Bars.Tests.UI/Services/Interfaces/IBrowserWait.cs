namespace Bars.Tests.UI.Services.Interfaces
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public interface IBrowserWait : IWait<IWebDriver>
    {
        void SetTimeout(int seconds);
    }
}
