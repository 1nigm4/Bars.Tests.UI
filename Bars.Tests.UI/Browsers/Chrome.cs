namespace Bars.Tests.UI.Browsers
{
    using Bars.Tests.UI.Configuration;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Remote;

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
            WebDriver webDriver;
            var options = new ChromeOptions();
            options.AddArguments(this.Settings.Arguments);

            if (this.Settings.InRemoteMode)
            {
                var uri = new Uri(Path.Combine(this.Settings.RemoteUrl, "wd", "hub"));
                var remoteSettings = JObject.FromObject(this.Settings.RemoteSettings)
                    .ToObject<Dictionary<string, object>>();

                remoteSettings.Add("browser", this.Settings.Browser.ToLower());
                options.AddAdditionalOption("selenoid:options", remoteSettings);

                var capabilities = options.ToCapabilities();
                webDriver = new RemoteWebDriver(uri, capabilities);
            }
            else
            {
                webDriver = new ChromeDriver(options);
            }

            this.Driver = webDriver;
        }
    }
}
