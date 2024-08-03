namespace Bars.Tests.UI.Services
{
    using System.Reflection;
    using Bars.Tests.UI.Browsers;
    using Bars.Tests.UI.Configuration;

    /// <summary>
    /// <inheritdoc cref="IBrowserBuilder"/>
    /// </summary>
    public class BrowserBuilder : IBrowserBuilder
    {
        public Browser Build(Settings settings)
        {
            var browserName = settings.Browser;
            var optionsName = browserName + "Options";
            var browserType = Assembly.GetCallingAssembly()
                .GetTypes()
                .First(t => t.Name == browserName);
                
            return (Browser)Activator.CreateInstance(browserType, settings)!;
        }
    }
}
