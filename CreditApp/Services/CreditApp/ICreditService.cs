using CreditApp.Models;

namespace CreditApp.Services
{
    public interface ICreditService
    {
        CreditResponse GetInterestWithDecision(CreditRequest creditRequest);
    }
}