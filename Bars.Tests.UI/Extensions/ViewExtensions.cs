namespace Bars.Tests.UI.Extensions
{
    using System.Reflection;
    using Bars.Tests.UI.Attributes;
    using Bars.Tests.UI.Views;

    public static class ViewExtensions
    {
        public static string GetElementName(this View view, string selector, int index)
        {
            var viewType = view.GetType();
            var fields = viewType.GetFields(BindingFlags.Public | BindingFlags.Static);
            var elements = fields.Where(f => f.GetCustomAttributes().Any(a => a is ElementAttribute));
            var element = elements.Single(e => e.GetRawConstantValue()?.ToString() == selector);
            var attribute = element.GetCustomAttribute<ElementAttribute>()!;
            return attribute.Names[index - 1];
        }
    }
}
