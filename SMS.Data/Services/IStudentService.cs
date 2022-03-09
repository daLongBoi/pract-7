using System;
using System.Collections.Generic;
	
using SMS.Data.Models;
	
namespace SMS.Data.Services
{
    // This interface describes the operations that a StudentService class should implement
    public interface IStudentService
    {
        // Initialise the repository (database)  
        void Initialise();
     
        // ---------------- Student Management --------------
        List<Student> GetStudents();       
        Student GetStudent(int id);
        Student GetStudentByEmail(string email);
        Student AddStudent(string name, string course, string email, int age, double grade, string photoUrl);
        Student UpdateStudent(Student updated);  
        bool    DeleteStudent(int id);

        // ---------------- Ticket Management ---------------
        Ticket CreateTicket(int studentId, string issue);
        Ticket GetTicket(int id);
        Ticket CloseTicket(int id);
        bool   DeleteTicket(int id);
        IList<Ticket> GetOpenTickets();  
    
        // -------------- Module Management -----------------
        Module AddModule(string name);
        StudentModule AddStudentToModule(int studentId, int moduleId, int mark);
        bool RemoveStudentFromModule(int studentId, int moduleId);

    }
    
}