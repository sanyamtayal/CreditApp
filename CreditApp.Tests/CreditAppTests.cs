using CreditApp.Models;
using CreditApp.Services;
using Xunit;

namespace CreditApp.Tests
{
    public class CreditAppTests
    {
        [Theory]
        [InlineData(1500, 3, 1002)]
        [InlineData(2500, 3, 1002)]
        [InlineData(70000, 3, 1002)]
        [InlineData(25000, 3, 10000)]
        [InlineData(25000, 3, 20000)]
        [InlineData(25000, 3, 45000)]
        public void InterestWithDecisionTest(int creditAmount, int termRepayment, int preExistingCreditAmount)
        {
            var request = new CreditRequest
            {
                CreditAmount = creditAmount,
                TermRepayment = termRepayment,
                PreExistingCreditAmount = preExistingCreditAmount,
            };

            var creditService = new CreditService();
            var response = creditService.GetInterestWithDecision(request);
            var expectedResponse = ExpectedTestResponse(request);
            Assert.Equal(expectedResponse.Decision, response.Decision);
            Assert.Equal(expectedResponse.InterestRate, response.InterestRate);
        }

        private CreditResponse ExpectedTestResponse(CreditRequest creditRequest)
        {
            var response = new CreditResponse();

            if (creditRequest.CreditAmount == 1500 && creditRequest.PreExistingCreditAmount == 1002)
            {
                response.Decision = "No";
                response.InterestRate = 3;
            }
            else if (creditRequest.CreditAmount == 2500 && creditRequest.PreExistingCreditAmount == 1002)
            {
                response.Decision = "Yes";
                response.InterestRate = 3;
            }
            else if (creditRequest.CreditAmount == 70000 && creditRequest.PreExistingCreditAmount == 1002)
            {
                response.Decision = "No";
                response.InterestRate = 6;
            }
            else if (creditRequest.CreditAmount == 25000 && creditRequest.PreExistingCreditAmount == 10000)
            {
                response.Decision = "Yes";
                response.InterestRate = 4;
            }
            else if (creditRequest.CreditAmount == 25000 && creditRequest.PreExistingCreditAmount == 20000)
            {
                response.Decision = "Yes";
                response.InterestRate = 5;
            }
            else if (creditRequest.CreditAmount == 25000 && creditRequest.PreExistingCreditAmount == 45000)
            {
                response.Decision = "Yes";
                response.InterestRate = 6;
            }

            return response;
        }
    }
}
