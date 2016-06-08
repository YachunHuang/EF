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

                //var item = new Course()
                //{
                //    CourseID = 9,
                //    Title = "KiwiGo",
                //    Credits = 2,
                //    DepartmentID = 1
                //};
                //db.Course.Add(item);

                //var findOne = db.Course.Find(8);
                //findOne.Credits += 1;
                //findOne.ModifyDate = DateTime.Now;
                //db.SaveChanges();

                //DBSet

                var c = db.Course.Find(2);
                //Console.WriteLine(db.Entry(c).State);
                //c.Credits += 1;
                //Console.WriteLine(db.Entry(c).State);
                //db.Entry(c).State = System.Data.Entity.EntityState.Deleted;
                //Console.WriteLine(db.Entry(c).State);
                //複製並寫入一筆一樣的
                db.Entry(c).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
            }
        }
    }
}