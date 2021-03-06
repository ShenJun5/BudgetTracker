using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracker.Core.Models.Response
{
    public class UserRegisterResponseModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string Password { get; set; }
 
    }
}
