using System.Reflection;
using System.Text.RegularExpressions;

namespace ValidationHelper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var typeOfClass = typeof(Validations)
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(fi => fi.IsLiteral && !fi.IsInitOnly)
                .ToList();


            var menu = new EasyConsole.Menu();
            foreach (var item in typeOfClass)
            {
                menu.Add(item.Name, () =>
                {
                    var res = item.GetValue(null);
                    if (res == null)
                        return;

                    Console.WriteLine("Enter " + item.Name + " To Validate:");

                    var userData = Console.ReadLine();
                    if (string.IsNullOrEmpty(userData))
                    {
                        Console.WriteLine("Invalid input");
                        return;
                    }

                    Console.WriteLine("------------------");
                    Console.WriteLine("Validate Result:" + Regex.IsMatch(userData, (string)res));
                    Console.WriteLine("------------------");

                });
            }

            menu.Add("Nationalcode", () =>
            {
                Console.WriteLine("Enter national code To validate:");
                var userData = Console.ReadLine();
                if (string.IsNullOrEmpty(userData))
                {
                    Console.WriteLine("Invalid input");
                    return;
                }

                Console.WriteLine("------------------");
                Console.WriteLine("Validate Result:" + Validations.IsNationalCode(userData));
                Console.WriteLine("------------------");
            });

            menu.Display();
        }
    }
}