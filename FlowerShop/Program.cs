using System;
using System.Collections.Generic;
using System.Linq;
using FlowerShop.Model;

namespace FlowerShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var orders = Input();
            var resultList = new List<string>();
            foreach (var order in orders)
            {
                var orderDetails = order.Split(' ');
                var orderQuantity = Convert.ToInt32(orderDetails[0]);
                var orderCategory = orderDetails[1];
                var result = Calculate(orderQuantity, orderCategory, order);
                resultList.Add(result);
            }
            Output(resultList);
        }

        public static string Calculate(int orderQuantity, string orderCategory, string order)
        {
            if (orderCategory == "R12")
            {
                var orderBundleOfTenCount = orderQuantity / Roses.BundleOfTenCount;
                var orderBundleOfFiveCount = (orderQuantity - Roses.BundleOfTenCount * orderBundleOfTenCount) /
                                             Roses.BundleOfFiveCount;
                var orderBundleOfTenPrice = orderBundleOfTenCount * Roses.BundleOfTenPrice;
                var orderBundleOfFivePrice = orderBundleOfFiveCount * Roses.BundleOfFivePrice;
                var totalPrice = orderBundleOfTenPrice + orderBundleOfFivePrice;
                var resultR12 = $@"
                                {order} ${totalPrice}
                                ";
                if (orderBundleOfTenCount != 0)
                {
                    resultR12 = resultR12 +
                                $@"{orderBundleOfTenCount}x{Roses.BundleOfTenCount} ${orderBundleOfTenPrice}";
                }
                if (orderBundleOfFiveCount != 0)
                {
                    resultR12 = resultR12 +
                                $@"{orderBundleOfFiveCount}x{Roses.BundleOfFiveCount} ${orderBundleOfFivePrice}";
                }
                return resultR12;
            }

            return null;
        }

        public static List<string> Input()
        {
            var inputLines = new List<string>();
            Console.WriteLine("Please input your order:");
            while (true)
            {
                var input = Console.ReadLine();
                if (input != null && input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                inputLines.Add(input);
            }

            return inputLines;
        }

        public static void Output(List<string> resultList)
        {
            foreach (var result in resultList)
            {
                Console.WriteLine(result);
                Console.ReadLine();
            }
        }
    }
}
