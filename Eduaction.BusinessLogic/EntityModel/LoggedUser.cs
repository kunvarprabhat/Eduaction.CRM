using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduaction.BusinessLogic.EntityModel
{
    public class LoggedUser
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public string Role { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public bool IsFirstLogin { get; set; }
    }
}
