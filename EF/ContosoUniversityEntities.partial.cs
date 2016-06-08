using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EF
{
    public partial class ContosoUniversityEntities1 : DbContext
    {
        public override int SaveChanges()
        {
            var entities = this.ChangeTracker.Entries();
            
            foreach (var entry in entities)
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Entity is Course)
                    {
                        var c = entry.Entity as Course;
                        c.Credits += 1;
                    }
                    if (entry.Entity is Department)
                    {
                        var c = entry.Entity as Department;
                        c.Name += "!";
                    }
                    entry.CurrentValues.SetValues(new { ModifyDate = DateTime.Now });
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.CurrentValues.SetValues(new { ModifyDate = DateTime.Now });
                }
            }

            return base.SaveChanges();
        }
    }
}
