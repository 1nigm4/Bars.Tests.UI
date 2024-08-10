namespace Bars.Tests.UI.Services.Interfaces
{
    public interface IConfigBuilder
    {
        void Configure<TSettings>(TSettings settings) where TSettings : Settings;
    }
}
