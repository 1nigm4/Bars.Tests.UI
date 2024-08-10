namespace Bars.Tests.UI.Services.Implementations
{
    using Bars.Tests.UI.Services.Interfaces;
    using OpenQA.Selenium.Chrome;

    public class ChromeBuilder : IBrowserBuilder<ChromeOptions>
    {
        public IBrowser Build(ChromeOptions driverOptions)
        {
            var driver = new ChromeDriver(driverOptions);
            var browser = new ChromeBrowser(driver);
            return browser;
        }
    }
}
