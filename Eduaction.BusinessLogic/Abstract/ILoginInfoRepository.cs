using Eduaction.BusinessLogic.EntityModel;
using Eduaction.DataModel.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduaction.BusinessLogic.Abstract
{
    public interface ILoginInfoRepository
    {
        LoggedUser GetLoginInfoByUserIdPassword(string LoginId, string password);
        LoginInfo? GetByLoginIdAsync(string loginId);
        void Add(LoginInfo login);
        void Save();
    }

}
