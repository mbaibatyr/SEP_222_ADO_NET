using MyEFCore.DbContextEF;
using MyEFCore.Model;

namespace MyEFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Call call = new Call();
            call.CarIns(new Car()
            {
                company = "toyota",
                color = "red",
                distance = "100000",
                model = "camry",
                year = 2020
            });

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
            context.Car.Add(model);
            context.SaveChanges();
            return "ok";
        }

        public IEnumerable<Car> CarSelect()
        {
            return context.Car.ToList();
        }
    }
}