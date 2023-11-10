﻿using Connect.Data.Entities;
using Connect.Data.Mappers;
using Connect.Data.Services.Repositories;
using Connect.Data.Session;
using Connect.Model;
using Framework.Core.Base;
using Framework.Data.Abstractions;
using System;
using System.Threading.Tasks;

namespace Connect.Data.Supervisors
{
    public sealed class SupervisorConfiguration : ISupervisorConfiguration
    {
        private readonly Lazy<IRepository<ConfigurationEntity>> _lazyConfigurationRepository;

        #region Properties
        private IRepository<ConfigurationEntity> ConfigurationRepository => _lazyConfigurationRepository.Value;
        #endregion

        #region Constructor
        public SupervisorConfiguration(IDalSession session, IRepositoryFactory repositoryFactory)
        {
            _lazyConfigurationRepository = repositoryFactory.CreateRepository<ConfigurationEntity>(session);
        }
        #endregion

        #region Methods
        public async Task<ResultCode> ConfigurationExists(string id)
        {
            return (await this.ConfigurationRepository.GetAsync(id) != null) ? ResultCode.Ok : ResultCode.ItemNotFound;
        }

        public async Task<ResultCode> AddConfiguration(Configuration configuration)
        {
            configuration.Id = string.IsNullOrEmpty(configuration.Id) ? Guid.NewGuid().ToString() : configuration.Id;
            int res = await this.ConfigurationRepository.InsertAsync(ConfigurationMapper.Map(configuration));
            ResultCode result = (res > 0) ? ResultCode.Ok : ResultCode.CouldNotCreateItem;
            return result;
        }
        #endregion
    }
}
