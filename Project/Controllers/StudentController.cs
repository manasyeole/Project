using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Controllers
{
    public class StudentController : Controller
    {
        private readonly DemoDbContext dbContext;

        public StudentController(DemoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetStudentList()
        {
            var student = await dbContext.StudentMasters.ToListAsync();
            return View(student);

        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel addStu)
        {

    

            //if (state == null || city == null)
            //{
            //    Handle invalid state or city values
            //     You can display an error message or take appropriate action based on your requirements
            //    return RedirectToAction("Error");
            //}

            var Student = new StudentMaster()
            {
                
                Id = BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0),
                StudentFName = addStu.StudentFName,
                StudentMName = addStu.StudentMName,
                StudentLName = addStu.StudentLName,
                StudentState = 1,     
                StudentCity = 1,
                Gender = addStu.Gender

            };

            await dbContext.StudentMasters.AddAsync(Student);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("GetStudentList");
        }
    }
}
