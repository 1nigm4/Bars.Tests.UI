namespace Bars.Tests.UI.Views.Shared
{
    using Bars.Tests.UI.Browsers;
    using Bars.Tests.UI.Services.Interfaces;

    /// <summary>
    /// Абстрактный класс общего представления
    /// TODO: использовать для shared компонентов (типо реестры)
    /// </summary>
    public abstract class SharedView : View
    {
        public SharedView(Browser browser, IAllureService allureService) : base(browser, allureService)
        {
        }
    }
}
