using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    internal class Report
    {
        public string text { get; set; }
        public DateTime deadline { get; set; }
        public Employees employees { get; set; }

    }
}
