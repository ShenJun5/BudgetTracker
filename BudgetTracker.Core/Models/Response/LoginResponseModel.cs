using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracker.Core.Models.Response
{
    public class LoginResponseModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string? Fullname { get; set; }
        public DateTime? JoinedOn { get; set; }
        public string Password { get; set; }
    }

    public class IncomeResponseModel
    {
        public int? UserId { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public DateTime? IncomeDate { get; set; }
        public string? Remarks { get; set; }

    }

    public class ExpenditureResponseModel
    {
        public int? UserId { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public DateTime? ExpDate { get; set; }
        public string? Remarks { get; set; }
    }
}
