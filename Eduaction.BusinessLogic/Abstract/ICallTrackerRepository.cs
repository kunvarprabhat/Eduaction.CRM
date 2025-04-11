using Eduaction.DataModel.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduaction.BusinessLogic.Abstract
{
    public interface ICallTrackerRepository
    {
        Task<IEnumerable<CallTracker>> GetAllCallTracker();
        Task<CallTracker> GetCallTrackerById(int modelId);
        Task<int> CreateCallTracker(CallTracker model);
        Task<bool> UpdateCallTracker(int modelId, CallTracker model);
        Task<bool> DeleteCallTracker(int modelId);
    }
}
