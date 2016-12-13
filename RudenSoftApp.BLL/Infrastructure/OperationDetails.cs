using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudenSoftApp.BLL.Infrastructure
{
    public class OperationDetails
    {
        public bool Succeeded { get; }
        public string Message { get; }
        public string Property { get; }

        public OperationDetails(bool succeeded, string message, string prop)
        {
            Succeeded = succeeded;
            Message = message;
            Property = prop;
        }
    }
}
