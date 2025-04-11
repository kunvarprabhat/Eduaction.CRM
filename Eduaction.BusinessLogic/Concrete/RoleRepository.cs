using Eduaction.BusinessLogic.Abstract;
using Eduaction.DataModel;
using Eduaction.DataModel.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Eduaction.BusinessLogic.Concrete
{
    public class RoleRepository : IRoleRepository
    {
        public async Task<int> CreateRoles(Role model)
        {
            try
            {

                using (EducationDbContext context = new EducationDbContext())
                {
                    await context.Roles.AddAsync(model);
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

        public async Task<bool> DeleteRoles(int modelId)
        {
            var success = false;
            using (EducationDbContext context = new EducationDbContext())
            {
                var module = await context.Roles.FindAsync(modelId);
                if (module != null)
                {
                    context.Roles.Remove(module);
                    var val = await context.SaveChangesAsync();
                    if (val > 0)
                        success = true;
                    else
                        success = false;
                }
                return success;
            }
        }

        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            using (EducationDbContext context = new EducationDbContext())
            {
                return await context.Roles.Where(x => x.IsActive == true).ToListAsync();
                        
                        
            }
        }

        public async Task<Role> GetRolesById(int modelId)
        {
            using (EducationDbContext context = new EducationDbContext())
            {
                var result = await context.Roles.FirstOrDefaultAsync(x => x.IsActive == true && x.Id == modelId);
                if (result != null)
                    return result;
                else
                    return new Role();
            }
        }

        public async Task<bool> UpdateRoles(int modelId, Role model)
        {
            var success = false;
            using (EducationDbContext context = new EducationDbContext())
            {
                var result = await context.Roles.Where(x => x.IsActive == true && x.Id == modelId).FirstOrDefaultAsync();
                if (result != null)
                {
                    result.RoleName = model.RoleName;
                    result.RoleCode = model.RoleCode;
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
