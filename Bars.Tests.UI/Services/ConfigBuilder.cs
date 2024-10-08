﻿namespace Bars.Tests.UI.Services
{
    using Bars.Tests.UI.Configuration;
    using Bars.Tests.UI.Services.Interfaces;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// <inheritdoc cref="IConfigBuilder"/>
    /// </summary>
    internal class ConfigBuilder : IConfigBuilder
    {
        /// <inheritdoc/>
        public void Configure<TSettings>(TSettings settings) where TSettings : Settings
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile("appsettings.dev.json", true);

            var config = builder.Build();
            config.Bind("AnalyticWorkspace", settings);
        }
    }
}
