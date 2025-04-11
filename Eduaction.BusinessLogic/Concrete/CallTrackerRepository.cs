using Eduaction.BusinessLogic.Abstract;
using Eduaction.DataModel;
using Eduaction.DataModel.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduaction.BusinessLogic.Concrete
{
    public class CallTrackerRepository : ICallTrackerRepository
    {
        public async Task<int> CreateCallTracker(CallTracker model)
        {
            try
            {

                using (EducationDbContext context = new EducationDbContext())
                {
                    await context.CallTrackers.AddAsync(model);
                    await context.SaveChangesAsync();
                    return model.Id;
                }
            }
            catch (Exception ex)
            {
                var mst = ex.Message;
                throw;
            }
        }

        public async Task<bool> DeleteCallTracker(int modelId)
        {
            var success = false;
            using (EducationDbContext context = new EducationDbContext())
            {
                var module = await context.CallTrackers.FindAsync(modelId);
                if (module != null)
                {
                    context.CallTrackers.Remove(module);
                    var val = await context.SaveChangesAsync();
                    if (val > 0)
                        success = true;
                    else
                        success = false;
                }
                return success;
            }
        }

        public async Task<IEnumerable<CallTracker>> GetAllCallTracker()
        {
            using (EducationDbContext context = new EducationDbContext())
            {
                return await context.CallTrackers.Where(x => x.IsActive == true)
                        .Include(c => c.Student)
                        .IgnoreAutoIncludes()
                        .AsNoTracking()
                        .ToListAsync();
            }
        }

        public async Task<CallTracker> GetCallTrackerById(int modelId)
        {
            using (EducationDbContext context = new EducationDbContext())
            {
                var result = await context.CallTrackers.FirstOrDefaultAsync(x => x.IsActive == true && x.Id == modelId);
                if (result != null)
                    return result;
                else
                    return new CallTracker();
            }
        }

        public async Task<bool> UpdateCallTracker(int modelId, CallTracker model)
        {
            var success = false;
            using (EducationDbContext context = new EducationDbContext())
            {
                var result = await context.CallTrackers.Where(x => x.IsActive == true && x.Id == modelId).FirstOrDefaultAsync();
                if (result != null)
                {
                    result.StudentId = model.StudentId;
                    result.Remark = model.Remark;
                    var val = await context.SaveChangesAsync();
                    if (val > 0)
                        success = true;
                    else
                        success = false;
                }
                return success;
            }
        }
    }
}
