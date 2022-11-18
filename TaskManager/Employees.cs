using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public class Employees
    {
        public StatusEmployees status { get; set; }
        public string name { get; set; }
        


        public Employees(string name, StatusEmployees status)
        {
            this.name = name;
            this.status = status;
        }
    }
    public enum StatusEmployees
    {
        TeamLeader,
        Developer
    }


}
