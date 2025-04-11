﻿using System;
using System.Collections.Generic;

namespace Eduaction.DataModel.DataModels;

public partial class RefreshToken
{
    public int TokenId { get; set; }

    public int EmployeeId { get; set; }

    public string Token { get; set; } = null!;

    public DateTime ExpiryDate { get; set; }

    public virtual EmployeeMaster Employee { get; set; } = null!;
}
