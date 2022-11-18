using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    internal class Project
    {
        public StatusProject status { get; set; }
        public string description { get; set; }
        public DateTime deadline { get; set; }
        public string employer { get; set; }
        public Employees ProjectManager { get; set; }
        public string[] tasks { get; set; }

    }
    public enum StatusProject
    {
        Project,
        Execution,
        Close
    }

}
