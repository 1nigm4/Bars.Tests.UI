namespace Bars.Tests.UI.Services
{
    using Bars.Tests.UI.Configuration;

    /// <summary>
    /// Билдер конфигурации
    /// </summary>
    public interface IConfigBuilder
    {
        /// <summary>
        /// Производит привязку файла конфигурацией с моделью настроек
        /// </summary>
        /// <typeparam name="TSettings">Модель настроек</typeparam>
        /// <param name="settings"></param>
        void Configure<TSettings>(TSettings settings) where TSettings : Settings;
    }
}
