using BudgetTracker.Core.Entities;
using BudgetTracker.Core.Models.Request;
using BudgetTracker.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Core.ServiceInterface
{
    public interface IUserService
    {
        Task<UserRegisterResponseModel> CreateUser(UserRegisterRequestModel requestModel);
        Task<LoginResponseModel> ValidateUser(string email, string password);
        Task<UserRegisterResponseModel> GetUserDetails(int id);
        Task<User> GetUser(string email);



        Task AddIncome(IncomeRequestModel incomeRequest);
        Task RemoveIncome(IncomeRequestModel incomeRequest);
        Task<IEnumerable<IncomeResponseModel>> GetAllIncomesForUser(int id);
        Task<IncomeResponseModel> UpdateIncome(IncomeRequestModel incomeRequest);



        Task AddExpenditure(ExpenditureRequestModel expenditureRequest);
        Task RemoveExpenditure(ExpenditureRequestModel expenditureRequest);
        Task<IEnumerable<ExpenditureResponseModel>> GetAllExpendituresForUser(int id);
        Task<ExpenditureResponseModel> UpdateExpenditure(ExpenditureRequestModel expendituRequest);


    }
}
