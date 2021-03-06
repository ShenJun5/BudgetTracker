using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracker.Core.Exceptions
{
    public class ConflictException : Exception
    {
        public ConflictException(string message):base(message)
        {
        }
    }
}
