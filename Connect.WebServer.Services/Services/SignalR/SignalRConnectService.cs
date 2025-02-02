﻿using Connect.Application.Infrastructure;
using Connect.Model;
using Microsoft.AspNetCore.SignalR;


namespace Connect.WebServer.Services
{
    public class SignalRConnectService : ISignalRConnectService
    {
        #region Property
        private IHubContext<ConnectHub> HubContext { get; set; }
        #endregion

        #region Constructor
        public SignalRConnectService(IHubContext<ConnectHub> context)
        {
            this.HubContext = context;
        }
        #endregion

        #region Method
        public async Task SendPlugStatusAsync(string locationId, Plug plug)
        {
            IClientProxy proxy = this.HubContext.Clients.Group(locationId);
            if (proxy != null)
            {
                await proxy.SendAsync(PlugStatus.Name, new PlugStatus
                {
                    PlugId = plug.Id,
                    Status = plug.Status,
                    WorkingDuration = plug.WorkingDuration,
                    Order = plug.Order,
                    OnOff = plug.OnOff,
                    Mode = plug.Mode,
                });
            }
        }

        public async Task SendRoomStatusAsync(string locationId, Room room)
        {
            IClientProxy proxy = this.HubContext.Clients.Group(locationId);
            if (proxy != null)
            {
                await proxy.SendAsync(RoomStatus.Name, new RoomStatus
                {
                    RoomId = room.Id,
                    Temperature = room.Temperature,
                    Pressure = room.Pressure,
                    Humidity = room.Humidity,
                });
            }
        }

        public async Task SendSensorStatusAsync(string locationId, Sensor sensor)
        {
            IClientProxy proxy = this.HubContext.Clients.Group(locationId);
            if (proxy != null)
            {
                await proxy.SendAsync(SensorStatus.Name, new SensorStatus
                {
                    SensorId = sensor.Id,
                    Temperature = sensor.Temperature,
                    Pressure = sensor.Pressure,
                    Humidity = sensor.Humidity,
                    IsRunning = (byte)sensor.IsRunning,
                    LeakDetected = (byte)sensor.LeakDetected,
                    RoomId = sensor.RoomId,
                });
            }
        }

        public async Task SendAlertAsync(string locationId, string title, string body)
        {
            IClientProxy proxy = this.HubContext.Clients.Group(locationId);
            if (proxy != null)
            {
                await proxy.SendAsync(NotificationStatus.Name, new NotificationStatus
                {
                    Title = title,
                    Body = body
                });
            }
        }
        #endregion
    }

}
