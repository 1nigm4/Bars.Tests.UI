namespace Bars.Tests.UI.Browsers
{
    using Bars.Tests.UI.Configuration;
    using OpenQA.Selenium.Chrome;

    /// <summary>
    /// Браузер Chrome
    /// </summary>
    public class Chrome : Browser
    {
        public Chrome(Settings settings) : base(settings)
        {
        }

        protected override void Initialize()
        {
            var options = new ChromeOptions();
            options.AddArguments(this.settings.Arguments);

            this.Driver = new ChromeDriver(options);
        }
    }
}
