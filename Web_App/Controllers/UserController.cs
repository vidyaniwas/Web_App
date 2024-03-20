using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Web_App.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Web_App.Controllers
{
    public class UserController : Controller
    {
        private readonly CollegeMgmtSysContext collegeMgmtSysContext;

        public UserController(CollegeMgmtSysContext collegeMgmtSysContext)
        {
            this.collegeMgmtSysContext = collegeMgmtSysContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult RegisterUser()
        {

            return View();
        }
        [HttpPost]
        public IActionResult RegisterUser(RegisterUser register)
        {
            if (ModelState.IsValid)
            {
                if (register.Password != register.ConfirmPassword)
                {
                    ModelState.AddModelError("ConfirmPassword", "The password and confirmation password do not match.");
                    return View(register);
                }


                // Save user data to database or perform other actions
                // For demonstration purposes, let's assume registration is successful and redirect to home page
                return RedirectToAction("Index", "Home");
            }
            return View(register);

        }

        [HttpGet]
        public IActionResult AddUser()
        {
            

            List<GenderMst> genderList = collegeMgmtSysContext.GenderMsts.ToList();
            ViewBag.GenderList = genderList != null && genderList.Any()
                ? new SelectList(genderList, "PkGenderId", "GenderName")
                : new SelectList(new List<GenderMst>(), "PkGenderId", "GenderName");
            List<CasteCategoryMst> CasteList = collegeMgmtSysContext.CasteCategoryMsts.ToList();

            ViewBag.CasteList = CasteList != null && CasteList.Any()
                ? new SelectList(CasteList, "PkCastCategoryId", "CastName")
                : new SelectList(new List<CasteCategoryMst>(), "PkCastCategoryId", "CastName");

            List<FacultyMst> FacultyList = collegeMgmtSysContext.FacultyMsts.ToList();
            ViewBag.FacultyList = FacultyList != null && FacultyList.Any()
                ? new SelectList(FacultyList, "PkFacultyId", "FacultyName")
                : new SelectList(new List<FacultyMst>(), "PkFacultyId", "FacultyName");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(StudentDetails studentDetails)
        {
            StudentDetailsMst studentDetailsMst=new StudentDetailsMst();
            studentDetailsMst.FullName=studentDetails.StudentName;
            studentDetailsMst.FatherName=studentDetails.FatherName;
            studentDetailsMst.MotherName=studentDetails.MotherName;
            studentDetailsMst.DateOfBirth=studentDetails.DateOfBirth;
            studentDetailsMst.EmailId=studentDetails.EmailId;
            studentDetailsMst.ContactNo=studentDetails.ContactNo;
            studentDetailsMst.GuardianContactNo=studentDetails.GuardianMobileNo;
            studentDetailsMst.AadharNo = studentDetails.AadharNo;
            studentDetailsMst.FkGenderId = Convert.ToInt32(studentDetails.GenderId);
            studentDetailsMst.FkFacultyId = Convert.ToInt32(studentDetails.Faculty);
            studentDetailsMst.FkCastCategoryId = Convert.ToInt32(studentDetails.CasteCategoryId);
            studentDetailsMst.PermanentAddress = studentDetails.PermanentAddress;
            studentDetailsMst.PostalAddress = studentDetails.PostalAddress;

            collegeMgmtSysContext.StudentDetailsMsts.Add(studentDetailsMst);

            // Save changes to the database
            await collegeMgmtSysContext.SaveChangesAsync();

            // Fetch the latest inserted primary key
            int Pk_StudentId = studentDetailsMst.PkStudentId;


            return RedirectToAction("AddSubjects", new { Pk_StudentId });


        }
        [HttpGet]
        public IActionResult AddSubjects(int Pk_StudentId)
        {

             var student = collegeMgmtSysContext.StudentDetailsMsts.FirstOrDefault(s => s.PkStudentId == Convert.ToInt32(Pk_StudentId));

            var ComSubjects = collegeMgmtSysContext.SubjectMsts.
                Where(subject => subject.FkFacultyId == student.FkFacultyId && subject.FkSubjectPaperGroupId==1).ToList();
            var EleSubjects = collegeMgmtSysContext.SubjectMsts.
                 Where(subject => subject.FkFacultyId == student.FkFacultyId && subject.FkSubjectPaperGroupId == 2).ToList();
            var AddSubjects = collegeMgmtSysContext.SubjectMsts.
                 Where(subject => subject.FkFacultyId == student.FkFacultyId && subject.FkSubjectPaperGroupId == 2).ToList();

            SubjectModel subjectModel = new SubjectModel();
            subjectModel.Pk_studentId = Convert.ToInt32(Pk_StudentId);
            subjectModel.ComSubjectList = new List<Comsubjects>();
            subjectModel.EleSubjectList = new List<Elesubjects>();
            subjectModel.AddSubjectList = new List<Addsubjects>();
            //int comsubcount=subjects.Count()
            for(int i=0;i< ComSubjects.Count(); i ++)
            {
                Comsubjects comsubjects = new Comsubjects();
                comsubjects.subjectCode = ComSubjects[i].SubjectCode.ToString();
                comsubjects.subjectName= ComSubjects[i].SubjectName.ToString();
                comsubjects.Pk_subjectId= ComSubjects[i].PkSubjectId.ToString();
                comsubjects.subjectGroupid = Convert.ToInt32(ComSubjects[i].FkSubjectPaperGroupId);
                subjectModel.ComSubjectList.Add(comsubjects);

            }

            for (int i = 0; i < EleSubjects.Count(); i++)
            {
                Elesubjects elesubjects = new Elesubjects();
                elesubjects.subjectCode = EleSubjects[i].SubjectCode.ToString();
                elesubjects.subjectName = EleSubjects[i].SubjectName.ToString();
                elesubjects.Pk_subjectId= EleSubjects[i].PkSubjectId.ToString() ;
                elesubjects.subjectGroupid = Convert.ToInt32(EleSubjects[i].FkSubjectPaperGroupId);
                subjectModel.EleSubjectList.Add(elesubjects);

            }
            for (int i = 0; i < AddSubjects.Count(); i++)
            {
                Addsubjects addsubjects = new Addsubjects();
                addsubjects.subjectCode = AddSubjects[i].SubjectCode.ToString();
                addsubjects.subjectName = AddSubjects[i].SubjectName.ToString();
                addsubjects.Pk_subjectId = AddSubjects[i].PkSubjectId.ToString();
                addsubjects.subjectGroupid = Convert.ToInt32(AddSubjects[i].FkSubjectPaperGroupId);
                subjectModel.AddSubjectList.Add(addsubjects);

            }

           

            return View(subjectModel);
        }


        [HttpPost]
        public async Task< IActionResult> AddStudentSubjects()
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var requestBody = await reader.ReadToEndAsync();
                Subjects subjects = JsonConvert.DeserializeObject<Subjects>(requestBody);
                
                List<string> commonSubjects = subjects.Common;
                List<string> additionalSubjects = subjects.Additional;
                List<string> electiveSubjects = subjects.Elective;
                int Id = Convert.ToInt32(subjects.Pk_studentId[0]);

                List<SubjectAppliedMst> subjectsToSave = new List<SubjectAppliedMst>();
                foreach (var subject in commonSubjects)
                {
                    string[] parts = subject.Split('+');
                    subjectsToSave.Add(new SubjectAppliedMst { FkStudentId = Convert.ToInt32(subjects.Pk_studentId[0]),
                        SubjectPaperCode = Convert.ToInt32(parts[0]),
                        FkSubjectPaperId= Convert.ToInt32(parts[1]),
                        FkSubjectgroupId=1, UpdatedDate = DateTime.Now });
                }
                foreach (var subject in electiveSubjects)
                {
                    string[] parts = subject.Split('+');
                    subjectsToSave.Add(new SubjectAppliedMst { FkStudentId = Convert.ToInt32(subjects.Pk_studentId[0]), 
                        SubjectPaperCode = Convert.ToInt32(parts[0]),
                        FkSubjectPaperId = Convert.ToInt32(parts[1]),
                        FkSubjectgroupId =2, UpdatedDate = DateTime.Now });
                }
                foreach (var subject in additionalSubjects)
                {
                    string[] parts = subject.Split('+');
                    subjectsToSave.Add(new SubjectAppliedMst { FkStudentId = Convert.ToInt32(subjects.Pk_studentId[0]), 
                        SubjectPaperCode = Convert.ToInt32(parts[0]),
                        FkSubjectPaperId = Convert.ToInt32(parts[1]),
                        FkSubjectgroupId = 3, UpdatedDate = DateTime.Now });
                }
                  collegeMgmtSysContext.SubjectAppliedMsts.AddRange(subjectsToSave);

                int savedRecords = await collegeMgmtSysContext.SaveChangesAsync();

                if (savedRecords > 0)
                {
                     return RedirectToAction("Preview", new { Id });
                    //return RedirectToAction("Index");
                }
                else
                {
                    return View();
                    // Console.WriteLine("No records were saved.");
                }


            }

           
        }

        [HttpGet]
        public async Task<IActionResult> Preview(int Id)
        {


            StudentDetailsMst student = await collegeMgmtSysContext.StudentDetailsMsts
                              .Include(s => s.FkGender)
                              .Include(s => s.FkFaculty)
                              .Include(s => s.FkCastCategory)
                              .Include(s => s.SubjectAppliedMsts)
                              .ThenInclude(ss => ss.FkSubjectPaper)
                              .FirstOrDefaultAsync(s => s.PkStudentId == Id);

            PreviewDetails preview = new PreviewDetails();
            preview.Pk_StudentId = student.PkStudentId;
            preview.StudentFullName = student.FullName;
            preview.FatherName = student.FatherName;
            preview.MotherName = student.MotherName;
            preview.DateOfBirth = student.DateOfBirth;
            preview.EmailId = student.EmailId;
            preview.ContactNo = student.ContactNo;
            preview.GuardianContactNo = student.GuardianContactNo;
            preview.AadharNo = student.AadharNo;
            preview.subjectPreviews = new List<SubjectPreview>();
            foreach (var subject in student.SubjectAppliedMsts)
            {
                //subject.FkSubjectPaper.FkSubjectPaperGroupId;
                SubjectPreview subjectPreview = new SubjectPreview();
                switch (subject.FkSubjectPaper.FkSubjectPaperGroupId)
                {
                    case 1:
                        subjectPreview.SubjectGroupId = "1";
                        subjectPreview.SubjectName = subject.FkSubjectPaper.SubjectName;
                        subjectPreview.SubjectCode = subject.FkSubjectPaper.SubjectCode.ToString();
                        preview.subjectPreviews.Add(subjectPreview);
                        break;
                    case 2:
                        subjectPreview.SubjectGroupId = "2";
                        subjectPreview.SubjectName = subject.FkSubjectPaper.SubjectName;
                        subjectPreview.SubjectCode = subject.FkSubjectPaper.SubjectCode.ToString();
                        preview.subjectPreviews.Add(subjectPreview);
                        break;
                    case 3:
                        subjectPreview.SubjectGroupId = "3";
                        subjectPreview.SubjectName = subject.FkSubjectPaper.SubjectName;
                        subjectPreview.SubjectCode = subject.FkSubjectPaper.SubjectCode.ToString();
                        preview.subjectPreviews.Add(subjectPreview);
                        break;

                }

            }

            return View(preview);
           // return View();
        }

        [HttpPost]
        public async Task<IActionResult> ViewStudentById(int Pk_studentId)
        {
            if(Pk_studentId!=null && Pk_studentId < 0)
            {
                StudentDetailsMst student = await collegeMgmtSysContext.StudentDetailsMsts
                                             .Include(s => s.FkGender)
                                             .Include(s => s.FkFaculty)
                                             .Include(s => s.FkCastCategory)
                                             .Include(s => s.SubjectAppliedMsts)
                                             .ThenInclude(ss => ss.FkSubjectPaper)
                                             .FirstOrDefaultAsync(s => s.PkStudentId == Pk_studentId);

                PreviewDetails preview = new PreviewDetails();
                preview.Pk_StudentId = student.PkStudentId;
                preview.StudentFullName = student.FullName;
                preview.FatherName = student.FatherName;
                preview.MotherName = student.MotherName;
                preview.DateOfBirth = student.DateOfBirth;
                preview.EmailId = student.EmailId;
                preview.ContactNo = student.ContactNo;
                preview.GuardianContactNo = student.GuardianContactNo;
                preview.AadharNo = student.AadharNo;
                preview.subjectPreviews = new List<SubjectPreview>();
                foreach (var subject in student.SubjectAppliedMsts)
                {
                    //subject.FkSubjectPaper.FkSubjectPaperGroupId;
                    SubjectPreview subjectPreview = new SubjectPreview();
                    switch (subject.FkSubjectPaper.FkSubjectPaperGroupId)
                    {
                        case 1:
                            subjectPreview.SubjectGroupId = "1";
                            subjectPreview.SubjectName = subject.FkSubjectPaper.SubjectName;
                            subjectPreview.SubjectCode = subject.FkSubjectPaper.SubjectCode.ToString();
                            preview.subjectPreviews.Add(subjectPreview);
                            break;
                        case 2:
                            subjectPreview.SubjectGroupId = "2";
                            subjectPreview.SubjectName = subject.FkSubjectPaper.SubjectName;
                            subjectPreview.SubjectCode = subject.FkSubjectPaper.SubjectCode.ToString();
                            preview.subjectPreviews.Add(subjectPreview);
                            break;
                        case 3:
                            subjectPreview.SubjectGroupId = "3";
                            subjectPreview.SubjectName = subject.FkSubjectPaper.SubjectName;
                            subjectPreview.SubjectCode = subject.FkSubjectPaper.SubjectCode.ToString();
                            preview.subjectPreviews.Add(subjectPreview);
                            break;

                    }

                }

                return View(preview);
            }


            return View();
        }



        [HttpGet]
        public IActionResult Admin()
        {


            return View();
        }
        [HttpPost]
        public IActionResult Admin(Login login)
        {
            return View();
        }
        [HttpGet]
        public IActionResult AdminDashboard()
        {
            List<FacultyMst> FacultyList = collegeMgmtSysContext.FacultyMsts.ToList();
            ViewBag.FacultyList = FacultyList != null && FacultyList.Any()
                ? new SelectList(FacultyList, "PkFacultyId", "FacultyName")
                : new SelectList(new List<FacultyMst>(), "PkFacultyId", "FacultyName");
            AdminDashboard  adminDashboard = new AdminDashboard();
            adminDashboard.studentLists = new List<studentList>();


            return View(adminDashboard);
        }

        [HttpPost]
        public IActionResult AdminDashboard(AdminDashboard adminDashboard)
        {
            List<FacultyMst> FacultyList = collegeMgmtSysContext.FacultyMsts.ToList();
            ViewBag.FacultyList = FacultyList != null && FacultyList.Any()
                ? new SelectList(FacultyList, "PkFacultyId", "FacultyName")
                : new SelectList(new List<FacultyMst>(), "PkFacultyId", "FacultyName");
            var studentDetailsMst = collegeMgmtSysContext.StudentDetailsMsts
                .Include(s => s.FkFaculty)
                .Where(s => s.IsPaymentDone == true && s.FkFacultyId == Convert.ToInt32(adminDashboard.FacultyName))
                .ToList();

            AdminDashboard adminDash = new AdminDashboard();
            if (studentDetailsMst.Count() > 0)
            {
                adminDash.FacultyName = studentDetailsMst[0].FkFaculty.FacultyName.ToString();
            }

            if (adminDashboard.PaymentStatus == "1")
            {
                adminDash.PaymentStatus = "Done";
            }
            else
                adminDash.PaymentStatus = "Pending";
            adminDash.studentLists = new List<studentList>();
            foreach (var student in studentDetailsMst)
            {
                studentList studentList = new studentList();
                studentList.Pk_studentId = student.PkStudentId;
                studentList.FacultyName= student.FkFaculty.FacultyName;
                studentList.StudentName = student.FullName.ToString();
                studentList.Fathername = student.FatherName.ToString();
                studentList.Mothername = student.MotherName.ToString();
                studentList.DateOfBirth = student.DateOfBirth;
                adminDash.studentLists.Add(studentList);
            }



            return View(adminDash);


            
        }

       
        [HttpGet]
        public IActionResult Student()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Student(Login login)
        {
            return View();
        }
        [HttpGet]
        public IActionResult Faculty()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Faculty(Login login)
        {
            return View();
        }





    }
}
