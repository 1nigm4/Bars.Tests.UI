namespace Bars.Tests.UI.Services.Interfaces
{
    using OpenQA.Selenium;

    public interface IBrowserService
    {
        IWebElement Find(By by);

        string Read(IWebElement element);

        void Write(IWebElement element, string text);

        void Click(IWebElement element);

        TResult Wait<TResult>(Func<IWebDriver, TResult> condition);

        Task OpenPageAsync(string url);

        Task RefreshPageAsync();
    }
}
