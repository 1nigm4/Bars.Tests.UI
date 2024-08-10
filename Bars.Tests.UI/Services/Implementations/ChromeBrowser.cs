namespace Bars.Tests.UI.Services.Implementations
{
    using OpenQA.Selenium;

    internal class ChromeBrowser : Browser
    {
        public ChromeBrowser(IWebDriver driver) : base(driver)
        {
        }
    }
}
