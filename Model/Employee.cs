using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Employee
    {
        public Name Name { get;  set; }
        public DateTime DateHired { get;  set; }
        public DateTime DateOfBirth { get;  set; }
        public string Password { get;  set; }
        public Store Store { get;  set; }
        public bool IsManager { get; }
        public Employee Supervisor { get;  set; }
        public int Id { get;  set; }
    }
}
