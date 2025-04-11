using Eduaction.DataModel.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduaction.BusinessLogic.Abstract
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllRoles();
        Task<Role> GetRolesById(int modelId);
        Task<int> CreateRoles(Role model);
        Task<bool> UpdateRoles(int modelId, Role model);
        Task<bool> DeleteRoles(int modelId);
    }
}
