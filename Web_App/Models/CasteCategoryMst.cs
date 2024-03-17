using System;
using System.Collections.Generic;

namespace Web_App.Models;

public partial class CasteCategoryMst
{
    public int PkCastCategoryId { get; set; }

    public string CastName { get; set; } = null!;

    public string Alias { get; set; } = null!;

    public virtual ICollection<StudentDetailsMst> StudentDetailsMsts { get; set; } = new List<StudentDetailsMst>();
}
