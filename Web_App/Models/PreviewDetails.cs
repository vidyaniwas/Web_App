namespace Web_App.Models
{
    public class PreviewDetails
    {
        public int Pk_StudentId { get; set; }
        public string StudentFullName { get; set; }
        public string FatherName { get; set;}
        public string MotherName { get; set;}
        public DateTime DateOfBirth { get; set;}
        public string EmailId { get; set;}
        public string ContactNo { get; set;}
        public string GuardianContactNo { get; set;}
        public string AadharNo { get; set;}
        public List<SubjectPreview> subjectPreviews { get; set; }
    }
    public class SubjectPreview
    {
        public string SubjectName { get; set;}
        public string SubjectCode { get; set;}
        public string SubjectGroupId { get; set;}
    }
}
