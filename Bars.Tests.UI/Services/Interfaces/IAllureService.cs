namespace Bars.Tests.UI.Services.Interfaces
{
    /// <summary>
    /// Allure сервис 
    /// </summary>
    public interface IAllureService
    {
        /// <summary>
        /// Создать отчет о выполняемом действии
        /// </summary>
        /// <param name="stepName">Наименование шага</param>
        /// <param name="action">Действие</param>
        /// <returns>Результат выполнения действия</returns>
        T Invoke<T>(string stepName, Delegate action);

        void Invoke(string stepName, Delegate action);
    }
}
