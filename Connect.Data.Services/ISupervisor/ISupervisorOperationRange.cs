﻿using Connect.Model;
using Framework.Core.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Connect.Data
{
    public interface ISupervisorOperationRange
    {
        Task<IEnumerable<OperationRange>> GetOperationRanges();
        Task<OperationRange> GetOperationRange(string id);
        Task<IEnumerable<OperationRange>> GetOperationRanges(string programId);
        Task<ResultCode> AddOperationrange(OperationRange operationRange);
        Task<ResultCode> DeleteOperationRange(OperationRange operationRange);
        Task<ResultCode> OperationRangeExists(string id);
        Task<ResultCode> DeleteOperationRanges(IEnumerable<OperationRange> operationRanges);
    }
}
