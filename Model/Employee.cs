using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Employee
    {
        public Name Name { get; protected internal set; }
        public DateTime DateHired { get; protected internal set; }
        public DateTime DateOfBirth { get; protected internal set; }
        public string Password { get; protected internal set; }
        public Store Store { get; protected internal set; }
        public bool IsManager { get; }
        public Employee Supervisor { get; protected internal set; }
        public int Id { get; protected internal set; }
    }
}
