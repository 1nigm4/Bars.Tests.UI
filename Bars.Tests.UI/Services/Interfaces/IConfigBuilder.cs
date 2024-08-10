namespace Bars.Tests.UI.Services.Interfaces
{
    using Bars.Tests.UI.Configuration;

    /// <summary>
    /// Билдер конфигурации
    /// </summary>
    public interface IConfigBuilder
    {
        /// <summary>
        /// Производит привязку файла конфигурации с объектом настроек
        /// </summary>
        /// <typeparam name="TSettings">Модель настроек</typeparam>
        /// <param name="settings">Объект настроек</param>
        void Configure<TSettings>(TSettings settings) where TSettings : Settings;
    }
}
