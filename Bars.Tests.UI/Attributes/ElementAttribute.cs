namespace Bars.Tests.UI.Attributes
{
    /// <summary>
    /// Атрибут искомого элемента
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class ElementAttribute : Attribute
    {
        /// <summary>
        /// Наименования элементов одного селектора по индексу
        /// </summary>
        public string[] Names { get; }

        public ElementAttribute(params string[] names)
        {
            this.Names = names;
        }
    }
}
