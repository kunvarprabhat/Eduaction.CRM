using Eduaction.BusinessLogic.Abstract;
using Eduaction.DataModel.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduaction.BusinessLogic.Concrete
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Task<int> CreateEmployee(EmployeeMaster model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteEmployee(int modelId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EmployeeMaster>> GetAllEmployee()
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeMaster> GetEmployeeById(int modelId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEmployee(int modelId, EmployeeMaster model)
        {
            throw new NotImplementedException();
        }
    }
}
