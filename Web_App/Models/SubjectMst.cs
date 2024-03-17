using System;
using System.Collections.Generic;

namespace Web_App.Models;

public partial class SubjectMst
{
    public int PkSubjectId { get; set; }

    public string SubjectName { get; set; } = null!;

    public int SubjectCode { get; set; }

    public int FkFacultyId { get; set; }

    public int? FkSubjectPaperGroupId { get; set; }

    public virtual FacultyMst FkFaculty { get; set; } = null!;

    public virtual ICollection<SubjectAppliedMst> SubjectAppliedMsts { get; set; } = new List<SubjectAppliedMst>();
}
