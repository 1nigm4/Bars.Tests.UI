namespace Bars.Tests.UI.Views
{
    using OpenQA.Selenium;

    public interface IView
    {
        IWebElement Find(string selector, Func<string, By>? by = null);

        string Read(string selector, Func<string, By>? by = null);

        void Write(string selector, string text, Func<string, By>? by = null);

        void Click(string selector, Func<string, By>? by = null);
    }
}
