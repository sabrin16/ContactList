using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactListApp.Utilities
{
    class GuidGenerator
    {
        public static string newID() { 
            return Guid.NewGuid().ToString();
        }
    }
}
