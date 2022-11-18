using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    internal class Tasks
    {
        public string description { get; set; }
        public DateTime deadline { get; set; }
        public Employees employer { get; set; }
        public Employees employees { get; set; }
        public Status status { get; set; }
        public Report report { get; set; }

    }
    public enum Status
    {
        assigned,
        work,
        check,
        done
    }

}
