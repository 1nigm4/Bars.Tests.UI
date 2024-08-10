namespace Bars.Tests.UI.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ElementAttribute : Attribute
    {
        public string[] Names { get; }

        public ElementAttribute(params string[] names)
        {
            this.Names = names;
        }
    }
}
