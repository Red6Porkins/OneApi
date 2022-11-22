using SDK.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Contracts
{
    public class QueryParameter
    {
        public string? Field { get; set; }

        public string? Value { get; set; }

        public FilterEnum Filter { get; set; }
    }
}
