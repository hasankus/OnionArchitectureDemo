using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Domain.Wrappers
{
    public class BaseResponse
    {
        public Guid Id { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
