using ProjectAuto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectAuto.DAL
{
    public class AutoDBInitializer : CreateDatabaseIfNotExists<AutoDBContext>
    {
        protected override void Seed(AutoDBContext context)
        {
            List<Car> Cars = new List<Car> 
            {
                new Car{CarModel="Kalina",CarMark="Lada",CarType=CarType.Passenger,Price=20000,Year=2010},
                new Car{CarModel="Sedan",CarMark="Lada",CarType=CarType.Passenger,Price=25000,Year=2011},
                new Car{CarModel="Diablo",CarMark="Lamborghini",CarType=CarType.Passenger,Price=500000,Year=1995},
                new Car{CarModel="Lancer",CarMark="Mitsubishi",CarType=CarType.Passenger,Price=60000,Year=2001},
                new Car{CarModel="Lanos",CarMark="Deo",CarType=CarType.Passenger,Price=30000,Year=2008},
            };
            Cars.ForEach(car => context.Cars.Add(car));
            context.SaveChanges();
            List<Owner> Owners = new List<Owner> 
            {
                new Owner{FirstName="Vasya",SecondName="Vasechkin",YearOfBirth=1990,DriverExpirience=2},
                new Owner{FirstName="Petya",SecondName="Petechkin",YearOfBirth=1995,DriverExpirience=1},
                new Owner{FirstName="Kolya",SecondName="Kolechkin",YearOfBirth=1987,DriverExpirience=5},
                new Owner{FirstName="Ivan",SecondName="Ivanov",YearOfBirth=1970,DriverExpirience=18},
                new Owner{FirstName="Danya",SecondName="Dasechkin",YearOfBirth=1989,DriverExpirience=4}
            };
            Owners.ForEach(owner => context.Owners.Add(owner));
            context.SaveChanges();
            base.Seed(context);
        }
    }
}