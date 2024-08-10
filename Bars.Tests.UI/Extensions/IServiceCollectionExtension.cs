namespace Bars.Tests.UI.Extensions
{
    using Bars.Tests.UI.Services.Implementations;
    using Bars.Tests.UI.Services.Interfaces;
    using Microsoft.Extensions.DependencyInjection;
    using OpenQA.Selenium.Chrome;

    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddUITests(this IServiceCollection services)
        {
            services.AddScoped<IBrowserBuilder<ChromeOptions>, ChromeBuilder>();
            services.AddScoped<IBrowserWait, BrowserWait>();
            services.AddScoped<IBrowserService, BrowserService>();
            services.AddScoped<IBrowser, ChromeBrowser>();
            return services;
        }
    }
}
