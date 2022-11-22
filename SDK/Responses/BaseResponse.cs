using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Responses
{
    public class BaseResponse<T>
    {        
        public T Docs { get; set; }

        public int Total { get; set; }

        public int Limit { get; set; }

        public int Offset { get; set; }

        public int Page { get; set; }

        public int Pages { get; set; }
    }
}
