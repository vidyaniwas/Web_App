using System;
using System.Collections.Generic;

namespace Web_App.Models;

public partial class SubjectAppliedMst
{
    public int PkSubjectAppliedId { get; set; }

    public int FkStudentId { get; set; }

    public int FkSubjectgroupId { get; set; }

    public int? FkSubjectPaperId { get; set; }

    public int SubjectPaperCode { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual StudentDetailsMst FkStudent { get; set; } = null!;

    public virtual SubjectMst? FkSubjectPaper { get; set; }
}
