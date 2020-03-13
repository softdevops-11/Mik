using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaFunctions
{
    internal class LambdaFunctionsProgram
    {
        private static void Main()
        {
            List<GetPersons> persons = new List<GetPersons>
            {
                new GetPersons("Валерий", 22),
                new GetPersons("Иван", 28),
                new GetPersons("Андрей", 20),
                new GetPersons("Михаил", 40),
                new GetPersons("Александр", 30),
                new GetPersons("Константин", 29),
                new GetPersons("Владимир", 22),
                new GetPersons("Павел", 33),
                new GetPersons("Александр", 25),
                new GetPersons("Алексей", 15),
                new GetPersons("Иван", 13),
                new GetPersons("Дмитрий", 17)
            };

            foreach (GetPersons p in persons)
            {
                Console.WriteLine("Имя: " + p.Name + ". Возраст: " + p.Age);
            }

            Console.WriteLine();

            List<string> uniquePersonsNames = persons.Select(p => p.Name).Distinct().ToList();
            string allNamesString = string.Join(", ", uniquePersonsNames.Select(p => p));
            Console.WriteLine("Имена: " + allNamesString + ".");
            Console.WriteLine();

            List<GetPersons> youngPersons = persons.Where(p => p.Age < 18).Select(p => new GetPersons(p.Name, p.Age)).ToList();
            string youngNamesString = string.Join(", ", youngPersons.Select(p => p.Name));
            double averageAge = youngPersons.Select(p => p.Age).Average();
            Console.WriteLine("Имена молодых людей: " + youngNamesString + ". Их средний возраст: " + averageAge + " лет. ");
            Console.WriteLine();

            Dictionary<string, double> personsByName = persons.GroupBy(p => p.Name).ToDictionary(p => p.Key, p =>
            p.Select(k => k.Age).Average());

            foreach (KeyValuePair<string, double> p in personsByName)
            {
                Console.WriteLine("Имя: " + p.Key + ". Средний возраст: " + p.Value);
            }

            Console.WriteLine();

            List<GetPersons> selectedPersons = persons.Where(p => p.Age >= 20 && p.Age <= 45).Select(p =>
            new GetPersons(p.Name, p.Age)).ToList();
            string sortedNames = string.Join(", ", selectedPersons.OrderByDescending(p => p.Age).Select(p => p.Name));
            Console.WriteLine("Имена в порядке убывания возраста: " + sortedNames + ".");

            Console.ReadLine();
        }
    }
}
