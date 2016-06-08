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
                db.Database.Log = Console.WriteLine;
                var c = db.Department.Find(2);
                db.Entry(c).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

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

                //var c = db.Course.Find(2);
                //Console.WriteLine(db.Entry(c).State);
                //c.Credits += 1;
                //Console.WriteLine(db.Entry(c).State);
                //db.Entry(c).State = System.Data.Entity.EntityState.Deleted;
                //Console.WriteLine(db.Entry(c).State);
                //複製並寫入一筆一樣的
                //db.Entry(c).State = System.Data.Entity.EntityState.Added;
                //db.SaveChanges();
            }
            Console.ReadLine();
            return;
            #region === 離線應用 ===
            //var item = new Course()
            //{
            //    CourseID = 9,
            //    Title = "Have a nice day!!",
            //    Credits = 2,
            //    DepartmentID = 1
            //};

            //using (var db1 = new ContosoUniversityEntities())
            //{
            //    //Attach暫存:unchange，如果改了item的資料的話就會有狀態了，不用在特別給狀態。所以可以直接SaveChanges
            //    //db1.Course.Attach(item);//會有cache
            //    item = db1.Course.Find(2);
            //    item.Title = "Have a nice day!!";
            //}

            //using (var db2 = new ContosoUniversityEntities())
            //{
            //    db2.Entry(item).State = System.Data.Entity.EntityState.Modified;
            //    db2.SaveChanges();
            //}
            #endregion
        }
    }
}