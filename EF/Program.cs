using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ContosoUniversityEntities())
            {
                //print b.title
                //db.Course.AsEnumerable().Select(i => i.Title).ToList().ForEach(b => Console.Write(b));

                //SqlCommand
                //db.Database.ExecuteSqlCommand("INSERT INTO Course (Title,Credits,DepartmentID)VALUES('KiwiCourse',1,1)");

                var item = new Course()
                {
                    CourseID = 9,
                    Title = "KiwiGo",
                    Credits = 2,
                    DepartmentID = 1
                };
                db.Course.Add(item);

                var findOne = db.Course.Find(8);
                findOne.Credits += 1;
                findOne.ModifyDate = DateTime.Now;
                db.SaveChanges();
            }
        }
    }
}