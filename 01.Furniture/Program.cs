using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            //string pattern = @">{2}(?<name>\w+)<{2}(?<price>[0-9.]+|\[0-9]+)!(?<quantity>\d+)";
            string pattern = @">{2}(?<name>\w+)<{2}(?<price>\d+\.\d+|\d+)!(?<quantity>\d+)";
            double sum = 0;

            List<string> orders = new List<string>();

            while (input != "Purchase")
            {
                orders.Add(input);
                input = Console.ReadLine();
            }

            MatchCollection validPurchases = Regex.Matches(string.Join(" ", orders), pattern);

            Console.WriteLine($"Bought furniture:");

            foreach (Match furniturePcs in validPurchases)
            {
                string furniture = furniturePcs.Groups["name"].Value;
                int quantity = int.Parse(furniturePcs.Groups["quantity"].Value);
                double price = double.Parse(furniturePcs.Groups["price"].Value);

                sum += price * quantity;

                Console.WriteLine(furniture);
            }

            Console.WriteLine($"Total money spend: {sum:f2}");

        }
    }
}
