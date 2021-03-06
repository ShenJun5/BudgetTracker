using BudgetTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Core.RepositoryInterface
{
    public interface IExpenditureRepository: IAsyncRepository<Expenditure>
    {
        //Task<IEnumerable<Expenditure>> GetAllExpenditures();
        //Task<IEnumerable<Expenditure>> GetAllExpendituresByUser(int userId);
    }
}
