using BudgetTracker.Core.Models.Request;
using BudgetTracker.Core.ServiceInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
    

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("income")]
        public async Task<ActionResult> CreateIncome([FromBody] IncomeRequestModel incomeRequest)
        {
            await _userService.AddIncome(incomeRequest);
            return Ok();
        }

        [HttpPost("expenditure")]
        public async Task<ActionResult> CreateExpenditure([FromBody] ExpenditureRequestModel expenditureRequest)
        {
            await _userService.AddExpenditure(expenditureRequest);
            return Ok();
        }

        [HttpPost("delincome")]
        public async Task<ActionResult> DeleteIncome([FromBody] IncomeRequestModel incomeRequest)
        {
            await _userService.RemoveIncome(incomeRequest);
            return Ok();
        }

        [HttpPost("delexpenditure")]
        public async Task<ActionResult> DeleteExpenditure([FromBody] ExpenditureRequestModel expenditureRequest)
        {
            await _userService.RemoveExpenditure(expenditureRequest);
            return Ok();
        }

        [HttpGet("{id:int}/expenditures")]
        public async Task<ActionResult> GetUserExpendituresAsync(int id)
        {
            var userExpenditures = await _userService.GetAllExpendituresForUser(id);
            return Ok(userExpenditures);
        }

        [HttpGet("{id:int}/incomes")]
        public async Task<ActionResult> GetUserIncomesAsync(int id)
        {
            var userIncomes = await _userService.GetAllIncomesForUser(id);
            return Ok(userIncomes);
        }

        [HttpPut("updateexpenditure")]
        public async Task<ActionResult> UpdateExpenditure([FromBody] ExpenditureRequestModel expenditureRequest)
        {
            await _userService.UpdateExpenditure(expenditureRequest);
            return Ok();
        }

        [HttpPut("updateincome")]
        public async Task<ActionResult> UpdateIncome([FromBody] IncomeRequestModel incomeRequest)
        {
            await _userService.UpdateIncome(incomeRequest);
            return Ok();
        }
    }
}

