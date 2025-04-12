using Eduaction.DataModel.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduaction.BusinessLogic.Abstract
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeMaster>> GetAllEmployee();
        Task<EmployeeMaster> GetEmployeeById(int modelId);
        Task<int> CreateEmployee(EmployeeMaster model);
        Task<bool> UpdateEmployee(int modelId, EmployeeMaster model);
        Task<bool> DeleteEmployee(int modelId);
    }
}
