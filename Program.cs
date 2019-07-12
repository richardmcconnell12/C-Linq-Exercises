using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            // Restriction/Filtering Operations
            List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

            IEnumerable<string> LFruits = from fruit in fruits
                                          where fruit[0] == 'L'
                                          select fruit;
            LFruits.ToList().ForEach(fruit => Console.WriteLine(fruit));
            Console.WriteLine("-------------");

            List<int> numbers = new List<int>()
                {
                    15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
                };

            IEnumerable<int> fourSixMultiples = numbers.Where(number => number % 4 == 0 || number % 6 == 0);

            fourSixMultiples.ToList().ForEach(number => Console.WriteLine(number));
            Console.WriteLine("-------------");

            // Ordering Operations
            // Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string>()
                {
                    "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
                    "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
                    "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
                    "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
                    "Francisco", "Tre"
                };

            IEnumerable<string> descend = from name in names
                                          orderby name descending
                                          select name;
            descend.ToList().ForEach(name => Console.Write($"{name} "));
            Console.WriteLine("");
            Console.WriteLine("-------------");

            List<int> ascendingNumbers = new List<int>()
                {
                    15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
                };

            IEnumerable<int> ascend = from number in numbers
                                      orderby number ascending
                                      select number;
            ascend.ToList().ForEach(number => Console.WriteLine(number));
            Console.WriteLine("-------------");

            // Aggregate Operations
            List<int> numberCount = new List<int>()
                {
                    15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
                };

            int count = numberCount.Count();
            Console.WriteLine(count);
            Console.WriteLine("-------------");
        }
    }
}
