using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EF
{
    public partial class ContosoUniversityEntities : DbContext
    {
        public override int SaveChanges()
        {
            var entities = this.ChangeTracker.Entries();
            
            foreach (var entry in entities)
            {
                Console.WriteLine("Entity Name:{0}", entry.Entity.GetType().FullName);
                Console.WriteLine("Status:{0}", entry.State);
 
                if (entry.State == EntityState.Added)
                {
                    if (entry.Entity is Course)
                    {
                        var c = entry.Entity as Course;
                        c.Credits += 1;
                    }
                    entry.CurrentValues.SetValues(new { ModifyDate = DateTime.Now });
                }
            }

            return base.SaveChanges();
        }
    }
}
