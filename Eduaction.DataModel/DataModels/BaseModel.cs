using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignageDataModel.DataModels
{
    public class BaseModel
    {
        public int Id { get; set; }
        public int AddedBy { get; set; } = 1;
        public DateTime AddedDate { get; set; } = DateTime.Now;
        public int? ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public string Ipaddress { get; set; } = "-None-";
        public bool IsActive { get; set; } = true;       
    }
}
