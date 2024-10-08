﻿namespace Bars.Tests.UI.Views.Pages
{
    using Bars.Tests.UI.Browsers;
    using Bars.Tests.UI.Configuration;
    using Bars.Tests.UI.Extensions;
    using Bars.Tests.UI.Services.Interfaces;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using SeleniumExtras.WaitHelpers;

    /// <summary>
    /// Абстрактный класс страницы
    /// </summary>
    public abstract class Page : View
    {
        /// <summary>
        /// Адрес
        /// </summary>
        public virtual string Url => Settings.Url;

        /// <summary>
        /// Настройки
        /// </summary>
        public Settings Settings { get; }

        public Page(
            Browser browser,
            IAllureService allureService,
            Settings settings) : base(browser, allureService)
        {
            this.Settings = settings;
        }

        /// <summary>
        /// Открытие страницы
        /// </summary>
        public virtual async Task OpenAsync()
        {
            await this.AllureService.Invoke<Task>(
                $"Открытие страницы '{this.Url}'",
                async () => await this.browser.Driver.Navigate().GoToUrlAsync(this.Url));
        }

        /// <summary>
        /// Обновление страницы
        /// </summary>
        public virtual async Task RefreshAsync()
        {
            await this.AllureService.Invoke<Task>(
                $"Обновление страницы",
                async () => await this.browser.Driver.Navigate().RefreshAsync());
        }

        /// <summary>
        /// <inheritdoc cref="WaitNavigate"/>
        /// </summary>
        /// <param name="page">Страница</param>
        /// <param name="condition">Тип ожидания</param>
        /// <param name="timeoutInSec">Таймаут в секундах</param>
        public virtual void WaitNavigate<TPage>(
            TPage page = null,
            Func<string, Func<IWebDriver, bool>> condition = null,
            int timeoutInSec = 10) where TPage : Page
        {
            page ??= this.browser.CreatePage<TPage>(this.AllureService, this.Settings);
            this.WaitNavigate(page.Url, condition, timeoutInSec);
        }

        /// <summary>
        /// Ожидание перехода на другую страницу.
        /// По умолчанию тип ожидания - UrlContains.
        /// </summary>
        /// <param name="url">Адрес</param>
        /// <param name="condition">Тип ожидания</param>
        /// <param name="timeoutInSec">Таймаут в секундах</param>
        public virtual void WaitNavigate(
            string url,
            Func<string, Func<IWebDriver, bool>> condition = null,
            int timeoutInSec = 10)
        {
            var timeout = TimeSpan.FromSeconds(timeoutInSec);
            var wait = new WebDriverWait(this.browser.Driver, timeout);

            condition ??= ExpectedConditions.UrlContains;
            var expectedCondition = condition(url);

            this.AllureService.Invoke($"Ожидание перехода на страницу '{url}'", () => wait.Until(expectedCondition));
        }
    }
}
