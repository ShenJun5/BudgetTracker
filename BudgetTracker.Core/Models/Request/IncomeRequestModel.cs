using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BudgetTracker.Core.Models.Request
{
    public class IncomeRequestModel
    {
        public int UserId { get; set; }
        public decimal? Amount { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        [StringLength(500)]
        public string Remarks { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime IncomeDate { get; set; }

    }
}
