using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactListApp.Utilities
{
    public class GuidGenerator
    {
        public static string newID() { 
            return Guid.NewGuid().ToString();
        }
    }
}
