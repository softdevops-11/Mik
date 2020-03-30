using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaFunctions
{
    internal class LambdaFunctionsProgram
    {
        private static void Main()
        {
            List<Person> persons = new List<Person>
            {
                new Person("Валерий", 22),
                new Person("Иван", 28),
                new Person("Андрей", 20),
                new Person("Михаил", 40),
                new Person("Александр", 30),
                new Person("Константин", 29),
                new Person("Владимир", 22),
                new Person("Павел", 33),
                new Person("Александр", 25),
                new Person("Алексей", 15),
                new Person("Иван", 13),
                new Person("Дмитрий", 17)
            };

            foreach (Person p in persons)
            {
                Console.WriteLine("Имя: " + p.Name + ". Возраст: " + p.Age);
            }

            Console.WriteLine();

            List<string> uniquePersonsNames = persons
                .Select(p => p.Name)
                .Distinct()
                .ToList();
            string allNamesString = string.Join(", ", uniquePersonsNames);
            Console.WriteLine("Имена: " + allNamesString + ".");
            Console.WriteLine();

            List<Person> youngPersons = persons
                .Where(p => p.Age < 18)
                .ToList();
            string youngNamesString = string.Join(", ", youngPersons.Select(p => p.Name));
            double averageAge = youngPersons.Average(p => p.Age);
            Console.WriteLine("Имена молодых людей: " + youngNamesString + ". Их средний возраст: " + averageAge + " лет. ");
            Console.WriteLine();

            Dictionary<string, double> personsByName = persons
                .GroupBy(p => p.Name)
                .ToDictionary(p => p.Key, p => p.Average(k => k.Age));

            foreach (KeyValuePair<string, double> p in personsByName)
            {
                Console.WriteLine("Имя: " + p.Key + ". Средний возраст: " + p.Value);
            }

            Console.WriteLine();

            string sortedNames = string.Join(", ", persons
                .Where(p => p.Age >= 20 && p.Age <= 45)
                .OrderByDescending(p => p.Age)
                .Select(p => p.Name));
            Console.WriteLine("Имена в порядке убывания возраста: " + sortedNames + ".");

            Console.ReadLine();
        }
    }
}
