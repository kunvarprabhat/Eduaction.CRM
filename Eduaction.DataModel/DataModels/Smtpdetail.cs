using System;
using System.Collections.Generic;

namespace Eduaction.DataModel.DataModels;

public partial class Smtpdetail
{
    public int Id { get; set; }

    public string Smtphost { get; set; } = null!;

    public int Smtpport { get; set; }

    public string Smtpusername { get; set; } = null!;

    public string Smtppassword { get; set; } = null!;

    public string Smtptoken { get; set; } = null!;

    public string FromAddress { get; set; } = null!;

    public string FromName { get; set; } = null!;

    public string EncryptionType { get; set; } = null!;

    public int? AddedBy { get; set; }

    public DateTime? AddedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsActive { get; set; }
}
