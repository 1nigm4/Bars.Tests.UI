namespace Bars.Tests.UI.Services.Implementations
{
    using System.Threading.Tasks;
    using Bars.Tests.UI.Services.Interfaces;
    using OpenQA.Selenium;

    public class BrowserService : IBrowserService
    {
        private readonly IWebDriver driver;
        private readonly IBrowserWait wait;

        public BrowserService(IWebDriver driver, IBrowserWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public void Click(IWebElement element)
        {
            element.Click();
        }

        public IWebElement Find(By by)
        {
            return this.driver.FindElement(by);
        }

        public async Task OpenPageAsync(string url)
        {
            await this.driver.Navigate()
                .GoToUrlAsync(url);
        }

        public string Read(IWebElement element)
        {
            return element.Text;
        }

        public async Task RefreshPageAsync()
        {
            await this.driver.Navigate().RefreshAsync();
        }

        public TResult Wait<TResult>(Func<IWebDriver, TResult> condition)
        {
            return this.wait.Until(condition);
        }

        public void Write(IWebElement element, string text)
        {
            element.SendKeys(text);
        }
    }
}
