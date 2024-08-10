namespace Bars.Tests.UI.Services.Interfaces
{
    /// <summary>
    /// Allure сервис 
    /// </summary>
    public interface IAllureService
    {
        /// <inheritdoc cref="Invoke(string, Delegate)"/>
        /// <returns>Результат действия типа <typeparamref name="T"/></returns>
        T Invoke<T>(string stepName, Delegate action);

        /// <summary>
        /// Создать отчет о выполняемом действии
        /// </summary>
        /// <param name="stepName">Наименование шага</param>
        /// <param name="action">Действие</param>
        void Invoke(string stepName, Delegate action);
    }
}
