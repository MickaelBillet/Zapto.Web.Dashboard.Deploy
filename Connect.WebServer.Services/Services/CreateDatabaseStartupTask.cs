﻿using Framework.Data.Abstractions;
using Framework.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Connect.WebServer.Services
{
    public class CreateDatabaseStartupTask : IStartupTask
    {
        #region Services
        private IDatabaseService DatabaseService { get; }
        #endregion

        #region Constructor
        public CreateDatabaseStartupTask(IServiceProvider serviceProvider)
        {
            this.DatabaseService = serviceProvider.GetRequiredService<IDatabaseService>();  
        }
        #endregion

        #region
        public async Task Execute()
        {
            await this.DatabaseService.ConfigureDatabase();
        }
        #endregion
    }
}
