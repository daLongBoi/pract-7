using System;
using System.Text;
using System.Collections.Generic;

namespace SMS.Data.Services
{
    public static class StudentServiceSeeder
    {
        // use this class to seed the database with dummy test data using an IStudentService 
        public static void Seed(IStudentService svc)
        {
            // wipe and recreate the database
            svc.Initialise();

            // add students
            var s1 = svc.AddStudent("Homer Simpson","Physics", "homer@mail.com", 41, 56, "https://static.wikia.nocookie.net/simpsons/images/b/bd/Homer_Simpson.png" );
            var s2 = svc.AddStudent("Marge Simpson","English", "marge@mail.com", 38, 69 , "https://static.wikia.nocookie.net/simpsons/images/4/4d/MargeSimpson.png");
            var s3 = svc.AddStudent("Bart Simpson","Maths", "bart@mail.com", 14, 61, "https://upload.wikimedia.org/wikipedia/en/a/aa/Bart_Simpson_200px.png" );
            var s4 = svc.AddStudent("Lisa Simpson","Poetry", "lisa@mail.com", 13, 80, "https://upload.wikimedia.org/wikipedia/en/e/ec/Lisa_Simpson.png" );
            var s5 = svc.AddStudent("Mr Burns","Management", "burns@mail.com", 81, 63, "https://static.wikia.nocookie.net/simpsons/images/a/a7/Montgomery_Burns.png" );
           
            // create some modules
            var m1 = svc.AddModule("Programming");
            var m2 = svc.AddModule("Maths");
            var m3 = svc.AddModule("English");

            // add tickets for homer
            var t1 = svc.CreateTicket(s1.Id, "Cannot login");
            var t2 = svc.CreateTicket(s1.Id, "Printing doesnt work");
            var t3 = svc.CreateTicket(s1.Id, "Forgot my password");

            // add ticket for marge
            var t4 = svc.CreateTicket(s2.Id, "Please reset password");

            // add ticket for bart
            var t5 = svc.CreateTicket(s3.Id, "No internet connection");
           
            // close homers first ticket 
            //svc.CloseTicket(t1.Id);

            // Homer is taking programming
            svc.AddStudentToModule(s1.Id, m1.Id, 60);

            // Marge is taking maths
            svc.AddStudentToModule(s2.Id, m2.Id, 72);

            // Bart is taking English 
            svc.AddStudentToModule(s3.Id, m3.Id, 56);

            // Lisa is taking Programming Maths and English
            svc.AddStudentToModule(s4.Id, m1.Id, 71);
            svc.AddStudentToModule(s4.Id, m2.Id, 79);
            svc.AddStudentToModule(s4.Id, m3.Id, 69);
        }
    }
}
