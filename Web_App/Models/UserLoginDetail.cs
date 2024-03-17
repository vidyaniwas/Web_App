using System;
using System.Collections.Generic;

namespace Web_App.Models;

public partial class UserLoginDetail
{
    public int PkUserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? EncryptedPassword { get; set; }

    public string? SaltKey { get; set; }

    public int FkUserTypeId { get; set; }

    public virtual UserTypeMst FkUserType { get; set; } = null!;
}
