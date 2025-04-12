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
    }

}
