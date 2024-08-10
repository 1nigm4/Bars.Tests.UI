namespace Bars.Tests.UI.Services.Interfaces
{
    using OpenQA.Selenium;

    public interface IBrowserBuilder<TDriverOptions> where TDriverOptions : DriverOptions
    {
        IBrowser Build(TDriverOptions driverOptions);
    }
}
