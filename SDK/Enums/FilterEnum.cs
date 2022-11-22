using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Enums
{
    public enum FilterEnum
    {
        Equals, 
        NotEquals, 
        Include, 
        Exclude, 
        //Exists, 
        ///NotExists, 
        RegEx, 
        NotRegEx, 
        Less, 
        LessOrEqual,
        Greater, 
        GreaterOrEqual
    }
}
