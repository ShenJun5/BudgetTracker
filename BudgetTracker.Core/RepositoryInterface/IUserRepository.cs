using BudgetTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Core.RepositoryInterface
{
    public interface IUserRepository:IAsyncRepository<User>
    {
        Task<User> GetUserByEmail(String email);
    }
}
