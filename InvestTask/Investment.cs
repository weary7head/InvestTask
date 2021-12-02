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
            decimal principalAmountSum = 0;
            decimal paymentAmount = CalculatePaymentAmount();
            decimal interestAmount;
            decimal balanceOwed;
            int monthCount = CalculateMonthCount(calculationDate);
            string[] payments = new string[monthCount];
            for (int i = 0, j = _numberOfPayments; i < monthCount; i++, j--)
            {
                decimal principalAmount;
                if (i == monthCount - 1 && j == 1)
                {
                    principalAmount = Math.Round((_dollars - principalAmountSum), 2);
                    paymentAmount = principalAmount * (decimal)Math.Pow((1 + ((double)_ratePerMonth)), j);
                    paymentAmount = Math.Round(paymentAmount, 2);
                }
                else
                {
                    principalAmount = paymentAmount / ((decimal)Math.Pow((1 + ((double)_ratePerMonth)), j));
                }
   
                principalAmount = Math.Round(principalAmount, 2);
                principalAmountSum += principalAmount;
                interestAmount = paymentAmount - principalAmount;
                balanceOwed = _dollars - principalAmountSum;

                payments[i] = $"{i + 1}. Payment amount: {paymentAmount} Principal amount: {principalAmount} Interest amount: {interestAmount} Balance owed {balanceOwed}";
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

            if (calculationDate > _agreementDate.AddYears(_investmentDuration))
            {
                return _numberOfPayments;
            }
            if (calculationDate < _agreementDate)
            {
                return months;
            }

            while (temporaryDate < calculationDate)
            {
                temporaryDate = temporaryDate.AddMonths(1);
                if (temporaryDate <= calculationDate)
                {
                    months++;
                }
            }

            return months;
        }
    }
}
