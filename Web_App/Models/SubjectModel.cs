namespace Web_App.Models
{
    public class SubjectModel
    {
        public int Pk_studentId { get; set; }
        public List<Comsubjects> ComSubjectList { get; set; }
        public List<Elesubjects> EleSubjectList { get; set; }
        public List<Addsubjects> AddSubjectList { get; set; }

       
    }

    public class Comsubjects
    {
        public string Pk_subjectId { get; set; }
        public string subjectCode { get; set; }
        public string subjectName { get; set; }
        public int subjectGroupid { get; set; }

    }

    public class Elesubjects
    {
        public string Pk_subjectId { get; set; }
        public string subjectCode { get; set; }
        public string subjectName { get; set; }
        public int subjectGroupid { get; set; }

    }
    public class Addsubjects
    {
        public string Pk_subjectId { get; set; }
        public string subjectCode { get; set; }
        public string subjectName { get; set; }
        public int subjectGroupid { get; set; }

    }

}
