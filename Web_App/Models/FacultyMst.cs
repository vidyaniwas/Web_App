using System;
using System.Collections.Generic;

namespace Web_App.Models;

public partial class FacultyMst
{
    public int PkFacultyId { get; set; }

    public string FacultyName { get; set; } = null!;

    public string Alias { get; set; } = null!;

    public virtual ICollection<StudentDetailsMst> StudentDetailsMsts { get; set; } = new List<StudentDetailsMst>();

    public virtual ICollection<SubjectMst> SubjectMsts { get; set; } = new List<SubjectMst>();
}
