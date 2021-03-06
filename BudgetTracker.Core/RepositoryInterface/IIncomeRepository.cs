using BudgetTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Core.RepositoryInterface
{
    public interface IIncomeRepository:IAsyncRepository<Income>
    {
        //Task<IEnumerable<Income>> GetAllIncomes();
        //Task<IEnumerable<Income>> GetAllIncomesByUser(int userId);
    }
}
