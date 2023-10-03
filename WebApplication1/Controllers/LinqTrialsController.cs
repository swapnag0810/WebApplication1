using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class LinqTrialsController : ControllerBase
    {

        public class Student
        {
            public int StudentID { get; set; }
            public String? StudentName { get; set; }
            public int Age { get; set; }
        }

        private readonly ILogger<LinqTrialsController> _logger;
        private SampleDBContext _sampleContext;

        public LinqTrialsController(ILogger<LinqTrialsController> logger, SampleDBContext sampleContext)
        {
            _logger = logger;
            _sampleContext = sampleContext;
        }

        [HttpGet(Name = "GetStudents")]
        public IEnumerable<Student> GetStudents()
        {
                Student[] studentArray = {
                    new Student() { StudentID = 1, StudentName = "Test1", Age = 18 } ,
                    new Student() { StudentID = 2, StudentName = "Test2",  Age = 21 } ,
                    new Student() { StudentID = 3, StudentName = "Test3",  Age = 25 } ,
                    new Student() { StudentID = 4, StudentName = "Test4" , Age = 20 } ,
                    new Student() { StudentID = 5, StudentName = "Test5" , Age = 31 } ,
                    new Student() { StudentID = 6, StudentName = "Test6",  Age = 17 } ,
                    new Student() { StudentID = 7, StudentName = "Test7",Age = 19  } ,
                };

            // Use LINQ to find teenager students
            Student[] teenAgerStudents = studentArray.Where(s => s.Age > 12 && s.Age < 20).ToArray();

            // Use LINQ to find first student whose name is test1 
            Student bill = studentArray.Where(s => s.StudentName == "Bill").FirstOrDefault();

            // Use LINQ to find student whose StudentID is 5
            Student student5 = studentArray.Where(s => s.StudentID == 5).FirstOrDefault();

            // string collection
            //IList<string> stringList = new List<string>() {
            //    "test1",
            //    "test2",
            //    "test3"
            //};

            //// LINQ Query Syntax
            //var result = from s in stringList
            //             where s.Contains("test3")
            //             select s;


            return teenAgerStudents;
        }
    }
}
