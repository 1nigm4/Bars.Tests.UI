namespace Bars.Tests.UI.Views.Pages
{
    using Bars.Tests.UI.Services.Interfaces;

    public abstract class Page(IBrowserService browserService) : View(browserService)
    {
        public string Url { get; protected set; }

        public virtual async Task OpenAsync()
        {
            await this.browserService.OpenPageAsync(this.Url);
        }

        public virtual async void RefreshAsync()
        {
            await this.browserService.RefreshPageAsync();
        }
    }
}
