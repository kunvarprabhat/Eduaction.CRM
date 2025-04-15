using Eduaction.BusinessLogic.Abstract;
using Eduaction.BusinessLogic.EntityModel;
using Eduaction.DataModel;
using Eduaction.DataModel.Comman;
using Eduaction.DataModel.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduaction.BusinessLogic.Concrete
{
    public class LoginInfoRepository : ILoginInfoRepository
    {
        private readonly EducationDbContext _context;

        public LoginInfoRepository(EducationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LoginInfo>> GetAllLoginInfo()
        {
            return await _context.LoginInfos.Include(x=>x.Employee).ThenInclude(x=>x.Roles).Where(x => x.IsActive == true).ToListAsync();

        }

        public LoggedUser GetLoginInfoByUserIdPassword(string LoginId, string password)
        {
            var user = _context.LoginInfos.Where(x => x.LoginId == LoginId && x.Password == password && x.IsActive == true)
                 .Include(c => c.Employee).ThenInclude(R => R.Roles)
                 .Select(u => new LoggedUser()
                 {
                     CustomerId = u.EmployeeId,
                     Id = u.Id,
                     FullName = u.Employee.FullName,
                     EmailId = u.Employee.EmailId,
                     CustomerCode = u.Employee.EmpCode,
                     MobileNo = u.Employee.MobileNo,
                     Role = u.Employee.Roles.FirstOrDefault().RoleName,
                     IsFirstLogin = u.IsFirstLogin
                 })
                 .AsNoTracking()
                 .IgnoreAutoIncludes()
                 .FirstOrDefault();

            return user;

        }
    }

}
