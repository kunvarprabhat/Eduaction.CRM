using System;
using System.Collections.Generic;

namespace Eduaction.DataModel.DataModels
{
    public partial class CastCategory
    {
        public int Id { get; set; }

        public string CastName { get; set; } = null!;

        public string? CastCode { get; set; }

        public string? Remark { get; set; }

        public int AddedBy { get; set; }

        public DateTime AddedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string? Ipaddress { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<StudentEntryModule> StudentEntryModules { get; set; } = new List<StudentEntryModule>();
    }
}
