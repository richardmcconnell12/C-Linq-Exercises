using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_Exercises
{
    public class Bank
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
    }

    // Define a customer
    public class Customer
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Bank { get; set; }
    }
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
            descend.ToList().ForEach(name => Console.WriteLine($"{name} "));
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

            List<double> purchases = new List<double>()
                {
                    2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
                };

            double totalAmount = purchases.Sum();
            Console.WriteLine(totalAmount);
            Console.WriteLine("-------------");

            List<double> prices = new List<double>()
                {
                    879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
                };

            double highestValue = prices.Max();
            Console.WriteLine(highestValue);
            Console.WriteLine("-------------");

            // Partitioning Operations
            List<int> wheresSquaredo = new List<int>()
                {
                    66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
                };

            IEnumerable<int> firstSquareRt = wheresSquaredo.TakeWhile(number =>
            {
                var num = Convert.ToInt32(Math.Sqrt(number));
                return num * num != number;
            });
            firstSquareRt.ToList().ForEach(number => Console.WriteLine(number));
            Console.WriteLine("-------------");

            List<Customer> customers = new List<Customer>() {
                new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
            };

            List<Bank> banks = new List<Bank>() {
            new Bank(){ Name="First Tennessee", Symbol="FTB"},
            new Bank(){ Name="Wells Fargo", Symbol="WF"},
            new Bank(){ Name="Bank of America", Symbol="BOA"},
            new Bank(){ Name="Citibank", Symbol="CITI"},
            };

            IEnumerable<Customer> millionaires = customers.Where(person => person.Balance > 1000000);

            var millGroup = millionaires.GroupJoin(banks,
                mill => mill.Bank,
                sym => sym.Symbol,
                (mill, sym) => new Result(mill.Name, sym));

            // var millionDollarGroup =
            //     from mill in millionaires
            //     join sym in banks on mill equals sym.Symbol into group
            //         select new { Name = mill, bankName = group };

            foreach (var result in millGroup)
            {
                Console.WriteLine(result.name + ":");
                foreach (var person in result.sym)
                {
                    Console.WriteLine(" " + person.Name);
                }
            }


            var millionairesByBalance = from millionaire in millionaires
                                        group millionaires by millionaire.Bank into mills
                                        orderby mills.Key
                                        select mills;



        }
    }

    public class Result
    {
        public string name;
        public IEnumerable<Bank> sym;

        public Result(string name, IEnumerable<Bank> sym)
        {
            this.name = name;
            this.sym = sym;
        }
    }
}
