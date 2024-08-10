namespace Bars.Tests.UI.Views
{
    using Bars.Tests.UI.Browsers;
    using Bars.Tests.UI.Extensions;
    using Bars.Tests.UI.Services.Interfaces;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using SeleniumExtras.WaitHelpers;

    /// <summary>
    /// Представление
    /// </summary>
    public class View
    {
        protected readonly Browser browser;
        public IAllureService AllureService { get; init; }

        public View(Browser browser, IAllureService allureService)
        {
            this.browser = browser;
            this.AllureService = allureService;
        }

        /// <summary>
        /// Возвращает текст элемента
        /// </summary>
        /// <param name="selector">Селектор</param>
        /// <param name="by">Тип поиска</param>
        /// <param name="index">Индекс</param>
        /// <returns>Текст элемента</returns>
        public virtual string Read(string selector, Func<string, By>? by = null, int index = 1)
        {
            var element = this.Find(selector, by, index);
            var elementName = this.GetElementName(selector, index);
            return this.AllureService.Invoke<string>($"Чтение '{elementName}'", () => element.Text);
        }

        /// <summary>
        /// Передает текст в элемент
        /// </summary>
        /// <param name="selector">Селектор</param>
        /// <param name="text">Текст</param>
        /// <param name="by">Тип поиска</param>
        /// <param name="index">Индекс</param>
        /// <param name="clear">Очищать перед заполнением</param>
        public virtual void Write(string selector, string text, Func<string, By>? by = null, int index = 1, bool clear = true)
        {
            var element = this.Find(selector, by, index);
            if (clear)
            {
                element.Clear();
            }

            var elementName = this.GetElementName(selector, index);
            this.AllureService.Invoke($"Заполнение '{elementName}'", () => element.SendKeys(text));
        }

        /// <summary>
        /// Проверяет, содержится ли текст в элементе.
        /// </summary>
        /// <param name="selector">Селектор</param>
        /// <param name="text">Ожидаемый текст в элементе</param>
        /// <param name="by">Тип поиска</param>
        /// <param name="index">Индекс</param>
        public virtual bool Contains(string selector, string text, Func<string, By>? by = null, int index = 1)
        {
            var webElementText = this.Read(selector, by, index)
                .ToLower()
                .Trim();
            text = text.ToLower()
                .Trim();
            return webElementText.Contains(text);
        }

        /// <summary>
        /// Производит клик по элементу
        /// </summary>
        /// <param name="selector">Селектор</param>
        /// <param name="by">Тип поиска</param>
        /// <param name="index">Индекс</param>
        public virtual void Click(string selector, Func<string, By>? by = null, int index = 1)
        {
            this.WaitElement(selector, ExpectedConditions.ElementToBeClickable, by, index);
            var element = this.Find(selector, by, index);
            var elementName = this.GetElementName(selector, index);
            this.AllureService.Invoke($"Нажатие '{elementName}'", () => element.Click());
        }

        /// <summary>
        /// Ожидание элемента.
        /// По умолчанию тип ожидания - ElementExists.
        /// <inheritdoc cref="CreateSelector"/>
        /// </summary>
        /// <param name="selector">Селектор</param>
        /// <param name="condition">Тип ожидания</param>
        /// <param name="by">Тип поиска</param>
        /// <param name="index">Индекс</param>
        /// <param name="timeoutInSec">Таймаут в секундах</param>
        public virtual void WaitElement(
            string selector,
            Func<By, Func<IWebDriver, IWebElement>> condition = null,
            Func<string, By>? by = null,
            int index = 1,
            int timeoutInSec = 10)
        {
            var timeout = TimeSpan.FromSeconds(timeoutInSec);
            var wait = new WebDriverWait(this.browser.Driver, timeout);
            
            condition ??= ExpectedConditions.ElementExists;
            var elementSelector = this.CreateSelector(selector, by, index);
            var expectedCondition = condition(elementSelector);

            var elementName = this.GetElementName(selector, index);
            this.AllureService.Invoke($"Ожидание '{elementName}'", () => wait.Until(expectedCondition));
        }

        /// <summary>
        /// Поиск элемента.
        /// <inheritdoc cref="CreateSelector"/>
        /// </summary>
        /// <param name="selector">Селектор</param>
        /// <param name="by">Тип поиска</param>
        /// <param name="index">Индекс</param>
        /// <returns>Элемент</returns>
        public virtual IWebElement Find(string selector, Func<string, By>? by = null, int index = 1)
        {
            var elementSelector = this.CreateSelector(selector, by, index);
            var elementName = this.GetElementName(selector, index);
            return this.AllureService.Invoke<IWebElement>($"Поиск '{elementName}'", () => this.browser.Driver.FindElement(elementSelector));
        }

        /// <summary>
        /// По умолчанию, тип поиска - XPath
        /// </summary>
        /// <param name="selector">Селектор</param>
        /// <param name="by">Тип поиска</param>
        /// <param name="index">Индекс</param>
        /// <returns>Тип поиска</returns>
        private By CreateSelector(string selector, Func<string, By>? by = null, int index = 1)
        {
            by ??= By.XPath;
            return by($"({selector})[{index}]");
        }
    }
}
