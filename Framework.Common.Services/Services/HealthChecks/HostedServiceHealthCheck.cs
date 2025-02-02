﻿using Framework.Core.Base;
using Framework.Core.Model;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Threading;
using System.Threading.Tasks;
#nullable disable

namespace Framework.Infrastructure.Services
{
    public class HostedServiceHealthCheck : IHealthCheck
    {
		private const int timeout = 10; //10 minutes

        #region Properties
        private SystemStatus Status { get; set; } = null;
		#endregion

		#region Constructor
		public HostedServiceHealthCheck()
		{

		}
		#endregion

		#region Methods
		public void SetStatus(SystemStatus status )
		{
			this.Status = status;
		}

		public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
														CancellationToken cancellationToken = default)
        {
            if (this.Status != null)
            {
				if (this.Status.Date + new TimeSpan(0, timeout, 0) > Clock.Now)
				{
					return Task.FromResult(HealthCheckResult.Healthy("The service Arduino is started"));
				}
            }

            return Task.FromResult(HealthCheckResult.Unhealthy("The service is down"));
        }
		#endregion
	}
}
