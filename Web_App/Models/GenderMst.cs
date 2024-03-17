using System;
using System.Collections.Generic;

namespace Web_App.Models;

public partial class GenderMst
{
    public int PkGenderId { get; set; }

    public string GenderName { get; set; } = null!;

    public string Alias { get; set; } = null!;

    public virtual ICollection<StudentDetailsMst> StudentDetailsMsts { get; set; } = new List<StudentDetailsMst>();
}
