namespace Bars.Tests.UI.Services
{
    using Allure.Net.Commons;
    using Bars.Tests.UI.Services.Interfaces;

    /// <inheritdoc cref="IAllureService"/>
    public class AllureService : IAllureService
    {
        private readonly AllureLifecycle lifecycle;

        public AllureService(AllureLifecycle lifecycle)
        {
            this.lifecycle = lifecycle;
        }

        public void Invoke(string stepName, Delegate action)
        {
            this.InvokeAction(stepName, action);
        }

        public T Invoke<T>(string stepName, Delegate action)
        {
            var result = this.InvokeAction(stepName, action);
            return (T)result;
        }

        /// <inheritdoc/>
        protected virtual object? InvokeAction(string stepName, Delegate action)
        {
            object? result = default;
            try
            {
                this.Start(stepName);
                result = action.DynamicInvoke();
                this.Update(step => step.status = Status.passed);
            }
            catch (Exception ex)
            {
                this.Update(step =>
                {
                    step.status = Status.failed;
                    step.stage = Stage.interrupted;
                    step.statusDetails = new StatusDetails
                    {
                        message = ex.Message,
                        trace = ex.StackTrace,
                    };
                });
            }
            finally
            {
                this.Stop();
            }

            return result;
        }

        /// <summary>
        /// Начинает шаг
        /// </summary>
        /// <remarks>Устанавливает этап шага <see cref="Stage.running"/></remarks>
        /// <param name="stepName"></param>
        protected virtual void Start(string stepName)
        {
            var step = new StepResult
            {
                name = stepName,
                stage = Stage.pending
            };

            this.lifecycle.StartStep(step);
        }

        /// <summary>
        /// Завершает шаг
        /// </summary>
        protected virtual void Stop()
        {
            this.lifecycle.StopStep();
        }

        /// <summary>
        /// Обновление информации о шаге
        /// </summary>
        /// <param name="update">Действие обновления шага</param>
        protected virtual void Update(Action<StepResult> update)
        {
            this.lifecycle.UpdateStep(update);
        }
    }
}
