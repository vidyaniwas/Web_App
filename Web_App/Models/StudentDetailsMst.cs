using System;
using System.Collections.Generic;

namespace Web_App.Models;

public partial class StudentDetailsMst
{
    public int PkStudentId { get; set; }

    public string FullName { get; set; } = null!;

    public string FatherName { get; set; } = null!;

    public string MotherName { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string? EmailId { get; set; }

    public string? ContactNo { get; set; }

    public string? GuardianContactNo { get; set; }

    public string? AadharNo { get; set; }

    public int FkGenderId { get; set; }

    public int FkCastCategoryId { get; set; }

    public string? PermanentAddress { get; set; }

    public string? PostalAddress { get; set; }

    public int FkFacultyId { get; set; }

    public bool? IsPaymentDone { get; set; }

    public bool? Isactive { get; set; }

    public virtual CasteCategoryMst FkCastCategory { get; set; } = null!;

    public virtual FacultyMst FkFaculty { get; set; } = null!;

    public virtual GenderMst FkGender { get; set; } = null!;

    public virtual ICollection<SubjectAppliedMst> SubjectAppliedMsts { get; set; } = new List<SubjectAppliedMst>();
}
