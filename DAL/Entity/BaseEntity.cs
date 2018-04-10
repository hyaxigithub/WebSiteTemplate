using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BaseEntity
    {
        public int IsDelete { get; set; }
        public int IsUpdate { get; set; }
        public int Status { get; set; }
    }
}
