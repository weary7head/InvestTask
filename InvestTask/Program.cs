using System;

namespace InvestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime agreementDate = DateTime.Now;
            
            Decimal x = 1200;
            int r = 12;
            int n = 1;

            Console.WriteLine($"Agreement date: {agreementDate}");
           
            Console.WriteLine($"X: {x}");
            Console.WriteLine($"R: {r}");
            Console.WriteLine($"N: {n}");

            Investment investment = new Investment(agreementDate, x, r, n);

            string[] strings = investment.GetPayments(agreementDate.AddYears(1));

            for (int i = 0; i < strings.Length; i++)
            {
                Console.WriteLine(strings[i]);
            }

            Console.ReadLine();
        }
    }
}
