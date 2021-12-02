using System;

namespace InvestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime agreementDate, calculationDate;
            Decimal x;
            int r, n;

            Console.Write("Enter agreement date: ");
            agreementDate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Enter Calculation date: ");
            calculationDate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Enter X: ");
            x = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter R: ");
            r = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter N: ");
            n = Convert.ToInt32(Console.ReadLine());

            Investment investment = new Investment(agreementDate, x, r, n);

            string[] strings = investment.GetPayments(calculationDate);

            for (int i = 0; i < strings.Length; i++)
            {
                Console.WriteLine(strings[i]);
            }

            Console.ReadLine();
        }
    }
}
