using System;

namespace InvestTask
{
    class Investment
    {
        private DateTime _agreementDate;
        private Decimal _dollars;
        private int _interestRate;
        private int _investmentDuration;
        private int _numberOfPayments => CalculateNumberOfPayments();
        decimal _ratePerMonth => CalculateRatePerMonth();

        public Investment(DateTime agreementDate, Decimal x, int r, int n)
        {
            _agreementDate = agreementDate;
            _dollars = x;
            _interestRate = r;
            _investmentDuration = n;
        }

        public string[] GetPayments(DateTime calculationDate)
        {
            decimal paymentsSum = 0;
            decimal paymentAmount = CalculatePaymentAmount();
            int monthCount = CalculateMonthCount(calculationDate);
            string[] payments = new string[monthCount];
            for (int i = 0; i < monthCount; i++)
            {
                if (i == monthCount - 1)
                {
                    payments[i] = $"{i + 1}. Payment Amount: {_dollars - paymentsSum}";
                }
                else
                {
                    payments[i] = $"{i + 1}. Payment Amount: {paymentAmount}";
                    paymentsSum += paymentAmount;
                }
            }

            return payments;
        }

        private decimal CalculatePaymentAmount()
        {
            decimal paymentAmount = 0;

            decimal numerator = _dollars * _ratePerMonth * Convert.ToDecimal(Math.Pow((1 + ((double)_ratePerMonth)), _numberOfPayments));
            decimal denominator = Convert.ToDecimal(Math.Pow((1 + ((double)_ratePerMonth)), _numberOfPayments) - 1);

            paymentAmount = (numerator / denominator);

            return Math.Round(paymentAmount, 2);
        }

        private void CalculatePrincipalAmount()
        {

        }

        private void CalculateInterestAmount()
        {

        }

        private int CalculateNumberOfPayments()
        {
            return (_investmentDuration * 12);
        }

        private decimal CalculateRatePerMonth()
        {
            return ((_interestRate / 100m) / 12m);
        }

        private int CalculateMonthCount(DateTime calculationDate)
        {
            int months = 0;
            DateTime temporaryDate = _agreementDate;

            while (true)
            {
                temporaryDate = temporaryDate.AddMonths(1);
                months++;
                if (temporaryDate.Month == calculationDate.Month && temporaryDate.Year == calculationDate.Year)
                {
                    break;
                }
            }

            return months;
        }
    }
}
