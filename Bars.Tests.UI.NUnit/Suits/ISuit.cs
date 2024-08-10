namespace Bars.Tests.UI.NUnit.Suits
{
    public interface ISuit : IDisposable
    {
        void Initialize();
        void AfterTest();
        void BeforeTest();
    }
}
