using System.ComponentModel;

namespace Web_App.Models
{
    public class StudentDetails
    {
        [DisplayName("Student Name")]
        public string StudentName { get; set; }
        [DisplayName("Father Name")]
        public string FatherName { get; set; }
        [DisplayName("Mother Name")]
        public string MotherName { get; set; }
        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        [DisplayName("Email Id")]
        public string EmailId { get; set; }
        [DisplayName("Contact No.")]
        public string ContactNo { get; set; }
        [DisplayName("Guardian Mobile No.")]
        public string GuardianMobileNo { get; set; }
        [DisplayName("Gender")]
        public string GenderId { get; set; }
        [DisplayName("Caste Category")]
        public string CasteCategoryId { get; set; }
        [DisplayName("Aadhar Number")]
        public string AadharNo { get; set; }
        [DisplayName("Permanent Address")]
        public string PermanentAddress { get; set; }
        [DisplayName("Postal Address")]
        public string PostalAddress { get; set; }
        [DisplayName("Faculty")]
        public string Faculty { get; set; }


    }

}
