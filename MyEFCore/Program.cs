using MyEFCore.DbContextEF;
using MyEFCore.Model;

namespace MyEFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Call call = new Call();
            call.CarUpd();
            //call.CarIns(new Car()
            //{
            //    company = "toyota",
            //    color = "red",
            //    distance = "100000",
            //    model = "carina",
            //    year = 2020,
            //    engine = "2000"
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
            context.Car.Add(model);
            context.SaveChanges();
            return "ok";
        }

        public IEnumerable<Car> CarSelect()
        {
            return context.Car.ToList();
        }

        public string CarUpd()
        {
            var car = context.Car.Where(z=>z.model == "camry").FirstOrDefault();
            if (car != null)
            {
                car.model = "prado";
                context.Car.Update(car);
                context.SaveChanges();
            }
            return "ok";
        }
    }
}