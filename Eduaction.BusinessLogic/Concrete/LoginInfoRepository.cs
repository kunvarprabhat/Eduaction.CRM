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

        public LoginInfo? GetByLoginIdAsync(string loginId)
        {
            return _context.LoginInfos.Include(x => x.Employee)
                                      .FirstOrDefault(l => l.LoginId == loginId && l.IsActive);
        }

        public void Add(LoginInfo login)
        {
            _context.LoginInfos.Add(login);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public LoggedUser GetLoginInfoByUserIdPassword(string LoginId, string password)
        {
            var user = _context.LoginInfos.Where(x => x.LoginId == LoginId && x.Password == password && x.IsActive == true)
                 .Include(c => c.Employee).ThenInclude(R => R.Roles)
                 .Select(u => new LoggedUser()
                 {
                     CustomerId = u.EmployeeId,
                     Id = u.Id,
                     FullName = u.Employee.FirstName,
                     EmailId = u.Employee.EmailId,
                     CustomerName = u.Employee.EmpCode,
                     MobileNo = u.Employee.MobileNo,
                     Role = u.Employee.Roles.FirstOrDefault().RoleName,
                     IsFirstLogin = u.IsFirstLogin
                 })
                 .AsNoTracking()
                 .IgnoreAutoIncludes()
                 .FirstOrDefault();

            return user;

        }
        //public static string HashPassword(string password)
        //{
        //    var hasher = new PasswordHasher<string>();
        //    return hasher.HashPassword(null, password);
        //}

        //public static bool VerifyPassword(string password, string hashedPassword)
        //{
        //    var hasher = new PasswordHasher<string>();
        //    var result = hasher.VerifyHashedPassword(null, hashedPassword, password);
        //    return result == PasswordVerificationResult.Success;
        //}
        //public bool CheckPassword(LoginInfo login, string password)
        //{
        //    string hashedPassword = Securities.ComputeHash(password, string.Empty, null);
        //    return hashedPassword.Equals(login.Password);
        //}
    }

}
