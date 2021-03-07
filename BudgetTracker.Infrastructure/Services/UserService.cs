using AutoMapper;
using BudgetTracker.Core;
using BudgetTracker.Core.Entities;
using BudgetTracker.Core.Exceptions;
using BudgetTracker.Core.Models.Request;
using BudgetTracker.Core.Models.Response;
using BudgetTracker.Core.RepositoryInterface;
using BudgetTracker.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Net;

namespace BudgetTracker.Infrastructure.Services
{
    public class UserService: IUserService
    {
        private readonly IAsyncRepository<Income> _incomeRepository;
        private readonly IAsyncRepository<Expenditure> _expenditureRepository;
        private readonly IUserRepository _userRepository;

        public UserService(IAsyncRepository<Income> incomeRepository, IAsyncRepository<Expenditure> expenditureRepository, IUserRepository userRepository)
        {
            _incomeRepository = incomeRepository;
            _expenditureRepository = expenditureRepository;
            _userRepository = userRepository;
        }

        public async Task<UserRegisterResponseModel> CreateUser(UserRegisterRequestModel userRegisterRequestModel)
        {
            var dbUser = await _userRepository.GetUserByEmail(userRegisterRequestModel.Email);
            if (dbUser != null)
                throw new ConflictException("Email Already Exits");
         
            var user= new User
            {
                Email = userRegisterRequestModel.Email,              
                Password = userRegisterRequestModel.Password,
                Fullname = userRegisterRequestModel.Fullname,
                JoinedOn = userRegisterRequestModel.JoinedOn
            };
            var createdUser = await _userRepository.AddAsync(user);

            var response = new UserRegisterResponseModel
            {
                Email = user.Email,
                Password = user.Password,
                Fullname = user.Fullname,
            };
            return response;
        }

        public async Task<LoginResponseModel> ValidateUser(string email, string password)
        {
            var user = await _userRepository.GetUserByEmail(email);
            if (user == null) return null;
            var isSuccess = user.Password == password;
            var response = new LoginResponseModel {
                Id = user.Id,
                Email = user.Email,
                Fullname = user.Fullname,
                JoinedOn = user.JoinedOn,
                Password = user.Password
            };
            return isSuccess ? response : null;
        }

        public async Task<User> GetUser(string email)
        {
            return await _userRepository.GetUserByEmail(email);
        }

        public async Task<UserRegisterResponseModel> GetUserDetails(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) throw new 
                    NotFoundException("User", id);
            
            var response = new UserRegisterResponseModel
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                Fullname = user.Fullname,

            };
            return response;
        }

        public async Task AddExpenditure(ExpenditureRequestModel expenditureRequest)
        {
            var expenditure = new Expenditure
            {
                UserId = expenditureRequest.UserId,
                Amount = (decimal)expenditureRequest.Amount,
                Description = expenditureRequest.Description,
                ExpDate = expenditureRequest.ExpDate,
                Remarks = expenditureRequest.Remarks,
            };
            await _expenditureRepository.AddAsync(expenditure);
        }

        public async Task AddIncome(IncomeRequestModel incomeRequest)
        {
            var income = new Income
            {
                UserId = incomeRequest.UserId,
                Amount = (decimal)incomeRequest.Amount,
                Description = incomeRequest.Description,
                IncomeDate = incomeRequest.IncomeDate,
                Remarks = incomeRequest.Remarks,
            };
            await _incomeRepository.AddAsync(income);
        }

        public async Task<IEnumerable<ExpenditureResponseModel>> GetAllExpenditures()
        {
            var expenditures = await _expenditureRepository.ListAllAsync();
            var response = new List<ExpenditureResponseModel>();
            foreach (var expenditure in expenditures)
            {
                response.Add(new ExpenditureResponseModel
                {
                    UserId = expenditure.UserId,
                    Amount = (decimal)expenditure.Amount,
                    Description = expenditure.Description,
                    ExpDate = expenditure.ExpDate,
                    Remarks = expenditure.Remarks,
                });
            }
            return response;
        }

        public async Task<IEnumerable<IncomeResponseModel>> GetAllIncomes()
        {
            var incomes = await _incomeRepository.ListAllAsync();
            var response = new List<IncomeResponseModel>();
            foreach (var income in incomes)
            {
                response.Add(new IncomeResponseModel
                {
                    UserId = income.UserId,
                    Amount = (decimal)income.Amount,
                    Description = income.Description,
                    IncomeDate = income.IncomeDate,
                    Remarks = income.Remarks,
                });
            }
            return response;
        }



        public async Task<IEnumerable<ExpenditureResponseModel>> GetAllExpendituresForUser(int id)
        {
            var expenditures = await _expenditureRepository.ListAsync(e => e.UserId == id);
            var response = new List<ExpenditureResponseModel>();
            foreach(var expenditure in expenditures)
            {
                response.Add(new ExpenditureResponseModel
                {
                    UserId = expenditure.UserId,
                    Amount = (decimal)expenditure.Amount,
                    Description = expenditure.Description,
                    ExpDate = expenditure.ExpDate,
                    Remarks = expenditure.Remarks,
                });
            }
            return response;
        }

        public async Task<IEnumerable<IncomeResponseModel>> GetAllIncomesForUser(int id)
        {
            var incomes = await _incomeRepository.ListAsync(e => e.UserId == id);
            var response = new List<IncomeResponseModel>();
            foreach (var income in incomes)
            {
                response.Add(new IncomeResponseModel
                {
                    UserId = income.UserId,
                    Amount = (decimal)income.Amount,
                    Description = income.Description,
                    IncomeDate = income.IncomeDate,
                    Remarks = income.Remarks,
                });
            }
            return response;
        }




        public async Task RemoveExpenditure(ExpenditureRequestModel expenditureRequest)
        {
            var expenditure = await _expenditureRepository.ListAsync(e => e.UserId == expenditureRequest.UserId);
            await _expenditureRepository.DeleteAsync(expenditure.First());
        }

        public async Task RemoveIncome(IncomeRequestModel incomeRequest)
        {
            var income = await _incomeRepository.ListAsync(e => e.UserId == incomeRequest.UserId);
            await _incomeRepository.DeleteAsync(income.First());
        }





        public async Task<IncomeResponseModel> UpdateIncome(IncomeRequestModel incomeRequest)
        {
            var income = new Income
            {
                UserId = incomeRequest.UserId,
                Amount = (decimal)incomeRequest.Amount,
                Description = incomeRequest.Description,
                IncomeDate = incomeRequest.IncomeDate,
                Remarks = incomeRequest.Remarks,
            };
            var updateIncome = await _incomeRepository.UpdateAsync(income);
            var response = new IncomeResponseModel
            {
                UserId = income.UserId,
                Amount = (decimal)income.Amount,
                Description = income.Description,
                IncomeDate = income.IncomeDate,
                Remarks = income.Remarks,
            };
            return response;
        }

        public async Task<ExpenditureResponseModel> UpdateExpenditure(ExpenditureRequestModel expenditureRequest)
        {
            var expenditure = new Expenditure
            {
                UserId = expenditureRequest.UserId,
                Amount = (decimal)expenditureRequest.Amount,
                Description = expenditureRequest.Description,
                ExpDate = expenditureRequest.ExpDate,
                Remarks = expenditureRequest.Remarks,
            };
            var updateExpenditure = await _expenditureRepository.UpdateAsync(expenditure);
            var response = new ExpenditureResponseModel
            {
                UserId = expenditure.UserId,
                Amount = (decimal)expenditure.Amount,
                Description = expenditure.Description,
                ExpDate = expenditure.ExpDate,
                Remarks = expenditure.Remarks,
            };
            return response;
        }
    }
}
