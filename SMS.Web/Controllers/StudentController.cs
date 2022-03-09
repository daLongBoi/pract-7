
using Microsoft.AspNetCore.Mvc;

using SMS.Data.Models;
using SMS.Data.Services;

namespace SMS.Web.Controllers
{
    public class StudentController : BaseController
    {
        private IStudentService svc;

        public StudentController()
        {
            svc = new StudentServiceDb();
        }

        // GET /student
        public IActionResult Index()
        {
            // complete this method
            var students = svc.GetStudents();
            
            return View(students);
        }

        // GET /student/details/{id}
        public IActionResult Details(int id)
        {
            // retrieve the student with specifed id from the service
            var s = svc.GetStudent(id);

            // TBC check if s is null and return NotFound()
            if (s == null)
            {
                return NotFound();
            }

            // pass student as parameter to the view
            return View(s);
        }

        // GET: /student/create
        public IActionResult Create()
        {
            // display blank form to create a student
            return View();
        }

        // POST /student/create
        [HttpPost]
        public IActionResult Create(Student s)
        {
            // TBC - complete POST action to add student (remove NotFound)
            
            return NotFound();
        }

        // GET /student/edit/{id}
        public IActionResult Edit(int id)
        {
            // load the student using the service
            var s = svc.GetStudent(id);

            // TBC check if s is null and return NotFound()
            if (s == null)
            {
                return NotFound();
            }   

            // pass student to view for editing
            return View(s);
        }

        // POST /student/edit/{id}
        [HttpPost]
        public IActionResult Edit(int id, Student s)
        {
            // complete POST action to save student changes
            if (ModelState.IsValid)
            {
                // pass data to service to update
                svc.UpdateStudent(s);
                
                // UX: display feedback and redirect to view the student details
                Alert("Student updated successfully", AlertType.info);
                return RedirectToAction(nameof(Details), new { Id = s.Id});
            }

            // redisplay the form for editing as validation errors
            return View(s);
        }

        // GET / student/delete/{id}
        public IActionResult Delete(int id)
        {
            // load the student using the service
            var s = svc.GetStudent(id);
            // check the returned student is not null and if so return NotFound()
            if (s == null)
            {
                return NotFound();
            }     
            
            // pass student to view for deletion confirmation
            return View(s);
        }

        // POST /student/delete/{id}
        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            // TBC delete student via service
            svc.DeleteStudent(id);
            
            // redirect to the index view
            return RedirectToAction(nameof(Index));
        }


        // ============== Student ticket management ==============

          // GET /student/createticket/{id}
        public IActionResult TicketCreate(int id)
        {
            var s = svc.GetStudent(id);
            if (s == null)
            {
                return NotFound();
            }

            // create a ticket view model and set foreign key
            var ticket = new Ticket { StudentId = id }; 
            // render blank form
            return View( ticket );
        }

        // POST /student/create
        [HttpPost]
        public IActionResult TicketCreate(Ticket t)
        {
            if (ModelState.IsValid)
            {                
                var ticket = svc.CreateTicket(t.StudentId, t.Issue);
                return RedirectToAction(nameof(Details), new { Id = ticket.StudentId });
            }
            // redisplay the form for editing
            return View(t);
        }

         // GET /student/ticketdelete/{id}
        public IActionResult TicketDelete(int id)
        {
            // load the ticket using the service
            var ticket = svc.GetTicket(id);
            // check the returned Ticket is not null and if so return NotFound()
            if (ticket == null)
            {
                return NotFound();
            }     
            
            // pass ticket to view for deletion confirmation
            return View(ticket);
        }

        // POST /student/ticketdeleteconfirm/{id}
        [HttpPost]
        public IActionResult TicketDeleteConfirm(int id, int studentId)
        {
            // TBC delete student via service
            
            // redirect to view the List of Students
            return NotFound();
        }


    }
}
