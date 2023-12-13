using Microsoft.EntityFrameworkCore;
using MyEFCore.DbContextEF;
using MyEFCore.Model;

namespace MyEFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Call call = new Call();
            call.CarUpd(1, new Car()
            {
                year = 2022
            });

            //call.CarUpd2(new Car()
            //{
            //    //id = 1,
            //    year = 2023,
            //    color = "black",
            //    company = "toyota",
            //    model = "camry",
            //    distance = "200000"
            //});

            //call.CarIns(new Car()
            //{
            //    company = "toyota",
            //    color = "red",
            //    distance = "100000",
            //    model = "carina",
            //    year = 2020
            //});

            foreach (var item in call.CarSelect())
            {
                Console.WriteLine($"{item.company} {item.model} ");
            }

        }
    }

    public class Call
    {
        MyContext context;
        public Call()
        {
            context = new MyContext();
        }

        public string CarIns(Car model)
        {
            context.Car.AddRange(model);
            context.SaveChanges();
            return "ok";
        }

        public IEnumerable<Car> CarSelect()
        {
            return context.Car.ToList();
        }

        public string CarUpd(int id, Car model)
        {
            var car = context.Car.Where(z => z.id == id).FirstOrDefault();
            if (car == null)
                return "Car not found";

            car.year = model.year;
            context.Car.Update(car);
            context.SaveChanges();
            return "ok";
        }

       
    }
}