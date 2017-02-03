using ProjectAuto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace ProjectAuto.DAL
{
    public class AutoDBContext: DbContext,IDBContext
    {
        public AutoDBContext()
            :base("AutoDBConnection")
        {
            Database.SetInitializer<AutoDBContext>(new AutoDBInitializer());
        }
          
        public DbSet<Car> Cars { get; set; }
        public DbSet<Owner> Owners { get; set; }
   }
}