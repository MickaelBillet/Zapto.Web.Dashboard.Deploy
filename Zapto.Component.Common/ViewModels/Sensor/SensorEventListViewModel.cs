﻿using Connect.Model;
using Zapto.Component.Common.Models;

namespace Zapto.Component.Common.ViewModels
{
    public interface ISensorEventListViewModel : IBaseViewModel
    {
        IEnumerable<SensorEventModel>? GetSensorEventModels(RoomModel? roomModel);
    }

    public class SensorEventListViewModel : BaseViewModel, ISensorEventListViewModel    
	{
        #region Properties
        #endregion

        #region Constructor
        public SensorEventListViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
        #endregion

        #region Methods
        public IEnumerable<SensorEventModel>? GetSensorEventModels(RoomModel? roomModel)
        {
            return roomModel?.Sensors?.Where((obj) => ((obj.Type & DeviceType.Sensor_Water_Leak) == DeviceType.Sensor_Water_Leak)).Select((obj) => new SensorEventModel()
            {
                Name = obj.Name,
                LocationId = roomModel.LocationId,
                Id = obj.Id,
                HasLeak = obj.LeakDetected,
            });
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        #endregion
    }
}
