using Microsoft.EntityFrameworkCore;
using MyEFCore.DbContextEF;
using MyEFCore.Model;

namespace MyEFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Call_2 call = new Call_2();
            //call.InsParentChild();
            call.SelParentChild_3();

            //Call call = new Call();
            //call.CarUpd(1, new Car()
            //{
            //    year = 2022
            //});

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

            //foreach (var item in call.CarSelect())
            //{
            //    Console.WriteLine($"{item.company} {item.model} ");
            //}

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

    public class Call_2
    {
        MyContext context;
        public Call_2()
        {
            context = new MyContext();
        }

        public void InsParentChild()
        {
            List<Child> lst = new List<Child>()
            {
                new Child{ name="ch1_p2"},
                new Child{ name="ch2_p2"},
                new Child{ name="ch3_p2"},
                new Child{ name="ch4_p2"}
            };

            Parent p = new Parent()
            {
                name = "p2",
                Child = lst
            };

            context.Parent.Add(p);
            context.SaveChanges();

        }

        public void SelParentChild_1()
        {
            //var arr = context.Parent.ToList();
            //foreach (var item in arr)
            //{
            //    Console.WriteLine($"{item.name}");
            //}

            //var arr2 = context.Child.ToList();

            //var parent = context.Parent
            //            .Include(z => z.Child);

            //foreach (var item in parent)
            //{
            //    Console.WriteLine($"{item.name} ");
            //    foreach (var item2 in item.Child)
            //    {
            //        Console.WriteLine($"   {item2.name} ");
            //    }
            //}
        }

        public void SelParentChild_2()
        {
            var parent = context.Parent.Where(z => z.id == 1).FirstOrDefault();
            context.Child.Where(p => p.ParentId == parent.id).Load();
            foreach (var item in parent.Child)
            {
                Console.WriteLine($"{parent.name} - {item.name}");
            }
        }

        public void SelParentChild_3()
        {
            var parent = context.Parent.Where(z => z.id == 1).FirstOrDefault();
            foreach (var item in parent.Child)
            {
                Console.WriteLine($"{parent.name} - {item.name}");
            }
        }
    }
}