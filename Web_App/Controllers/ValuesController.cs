using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web_App.Models;

namespace Web_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly CollegeMgmtSysContext collegeMgmtSysContext;
        public ValuesController(CollegeMgmtSysContext collegeMgmtSysContext)
        {
            this.collegeMgmtSysContext = collegeMgmtSysContext;
        }
        [HttpPost]
        public async Task<IActionResult> AddStudentSubjects()
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
                    subjectsToSave.Add(new SubjectAppliedMst
                    {
                        FkStudentId = Convert.ToInt32(subjects.Pk_studentId[0]),
                        SubjectPaperCode = Convert.ToInt32(parts[0]),
                        FkSubjectPaperId = Convert.ToInt32(parts[1]),
                        FkSubjectgroupId = 1,
                        UpdatedDate = DateTime.Now
                    });
                }
                foreach (var subject in electiveSubjects)
                {
                    string[] parts = subject.Split('+');
                    subjectsToSave.Add(new SubjectAppliedMst
                    {
                        FkStudentId = Convert.ToInt32(subjects.Pk_studentId[0]),
                        SubjectPaperCode = Convert.ToInt32(parts[0]),
                        FkSubjectPaperId = Convert.ToInt32(parts[1]),
                        FkSubjectgroupId = 2,
                        UpdatedDate = DateTime.Now
                    });
                }
                foreach (var subject in additionalSubjects)
                {
                    string[] parts = subject.Split('+');
                    subjectsToSave.Add(new SubjectAppliedMst
                    {
                        FkStudentId = Convert.ToInt32(subjects.Pk_studentId[0]),
                        SubjectPaperCode = Convert.ToInt32(parts[0]),
                        FkSubjectPaperId = Convert.ToInt32(parts[1]),
                        FkSubjectgroupId = 3,
                        UpdatedDate = DateTime.Now
                    });
                }
                collegeMgmtSysContext.SubjectAppliedMsts.AddRange(subjectsToSave);

                int savedRecords = await collegeMgmtSysContext.SaveChangesAsync();

                if (savedRecords > 0)
                {
                    return Ok(Id);
                    //return RedirectToAction("Preview", "User", new { Id });
                    //return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Preview", "User", new { Id });
                    //return View();
                    // Console.WriteLine("No records were saved.");
                }


            }
        }
    }
}
