using BudgetTracker.Core;
using BudgetTracker.Core.Entities;
using BudgetTracker.Core.RepositoryInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BudgetTracker.Infrastructure.Repositories
{
    public class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(BudgetTrackerDbContext dbContext) : base(dbContext)
        {
        }

        public virtual async Task<User> GetUserByEmail(string email)
        {
            return await _dbContext.Users.Include(u => u.Incomes).Include(u =>u.Expenditures).FirstOrDefaultAsync(u => u.Email == email);
        }

    }
}
