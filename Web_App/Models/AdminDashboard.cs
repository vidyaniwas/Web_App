namespace Web_App.Models
{
    public class AdminDashboard
    {
        public string FacultyName { get; set; }
        public string PaymentStatus { get; set; } = string.Empty;
        public List<studentList>studentLists { get; set; }

    }
    public class studentList
    {
        public int Pk_studentId { get; set; }
        public string FacultyName { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string Fathername { get; set; }
        public string Mothername { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    }
