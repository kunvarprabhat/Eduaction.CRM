using Eduaction.BusinessLogic.EntityModel;
using Eduaction.DataModel.DataModels;

namespace Eduaction.BusinessLogic.Abstract
{
    public interface ILoginInfoRepository
    {
        LoggedUser GetLoginInfoByUserIdPassword(string LoginId, string password);

        Task<IEnumerable<LoginInfo>> GetAllLoginInfo();

    }

}
