using CreditApp.Models;

namespace CreditApp.Services
{
    public class CreditService : ICreditService
    {
        public CreditResponse GetInterestWithDecision(CreditRequest creditRequest)
        {
            return new CreditResponse
            {
                Decision = GetDecision(creditRequest),
                InterestRate = GetInterestRate(creditRequest),
            };
        }

        /// <summary>
        ///  Returns the decision
        /// </summary>
        /// <param name="creditRequest"></param>
        /// <returns></returns>
        private string GetDecision(CreditRequest creditRequest)
        {
            if (creditRequest.CreditAmount < 2000)
            {
                return "No";
            }
            else if (creditRequest.CreditAmount >= 2000 && creditRequest.CreditAmount <= 69000)
            {
                return "Yes";
            }

            return "No";
        }

        /// <summary>
        /// Returns the interestRate
        /// </summary>
        /// <param name="creditRequest"></param>
        /// <returns></returns>
        private int GetInterestRate(CreditRequest creditRequest)
        {
            var totalDebt = creditRequest.CreditAmount + creditRequest.PreExistingCreditAmount;

            if (totalDebt < 20000)
            {
                return 3;
            }
            else if (totalDebt >= 20000 && totalDebt < 40000)
            {
                return 4;
            }
            else if (totalDebt >= 40000 && totalDebt <= 60000)
            {
                return 5;
            }

            return 6;
        }
    }
}