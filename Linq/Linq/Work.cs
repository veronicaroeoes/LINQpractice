using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Work
    {
        public string CompanyName { get; set; }
        public int WorkPlaceID { get; set; }

        public override string ToString()
        {
            return $"Company: {CompanyName}";
        }
    }
    
}
