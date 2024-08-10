namespace Bars.Tests.UI.Views
{
    using Bars.Tests.UI.Services.Interfaces;
    using OpenQA.Selenium;
    using SeleniumExtras.WaitHelpers;

    public abstract class View : IView
    {
        protected readonly IBrowserService browserService;

        protected View(IBrowserService browserService)
        {
            this.browserService = browserService;
        }

        public void Click(string selector, Func<string, By>? by = null)
        {
            var element = this.Find(selector, by);
            this.browserService.Click(element);
        }

        public IWebElement Find(string selector, Func<string, By>? by = null)
        {
            var result = this.CreateSelector(selector, by);
            return this.browserService.Find(result);
        }

        public string Read(string selector, Func<string, By>? by = null)
        {
            var element = this.Find(selector, by);
            return this.browserService.Read(element);
        }

        public virtual IWebElement WaitElement(string selector, Func<string, By>? by = null, Func<By, Func<IWebDriver, IWebElement>>? condition = null)
        {
            var select = this.CreateSelector(selector, by);
            condition ??= ExpectedConditions.ElementExists;
            var result = condition.Invoke(select);
            return this.browserService.Wait(result);
        }

        public virtual void Write(string selector, string text, Func<string, By>? by = null)
        {
            var element = this.Find(selector, by);
            this.browserService.Write(element, text);
        }

        protected virtual By CreateSelector(string selector, Func<string, By>? by = null)
        {
            by ??= By.XPath;
            return by.Invoke(selector);
        }
    }
}
