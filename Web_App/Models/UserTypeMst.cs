using System;
using System.Collections.Generic;

namespace Web_App.Models;

public partial class UserTypeMst
{
    public int PkUserTypeId { get; set; }

    public string UserType { get; set; } = null!;

    public string Alias { get; set; } = null!;

    public virtual ICollection<UserLoginDetail> UserLoginDetails { get; set; } = new List<UserLoginDetail>();
}
