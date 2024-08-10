namespace Bars.Tests.UI.NUnit.Suits
{
    using Bars.Tests.UI.Extensions;
    using Bars.Tests.UI.Views.Pages;
    using Microsoft.Extensions.DependencyInjection;

    public class Suit<TPage> : ISuit where TPage : Page
    {
        protected Page Page { get; private set; }

        [OneTimeSetUp]
        public virtual void Initialize()
        {
            var services = new ServiceCollection();
            services.AddUITests();
            services.AddScoped<TPage>();
            var provider = services.BuildServiceProvider();
            this.Page = provider.GetRequiredService<TPage>();
        }

        [SetUp]
        public void AfterTest()
        {
            throw new NotImplementedException();
        }

        [TearDown]
        public void BeforeTest()
        {
            throw new NotImplementedException();
        }

        [OneTimeTearDown]
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
