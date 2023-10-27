using System;
using VideoStore.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Employee
    {
        public virtual Name Name { get;  set; }
        public virtual DateTime DateHired { get;  set; }
        public virtual DateTime DateOfBirth { get;  set; }
        public virtual string Password { get;  set; }
        public virtual Store Store { get;  set; }
        public virtual bool IsManager { get; }
        public virtual Employee Supervisor { get;  set; }
        public virtual int Id { get;  set; }
        public virtual string Username { get; set; }
        public Employee() 
        { 
            DateHired = DateFactory.CurrentDate;
            DateOfBirth = DateFactory.CurrentDate;
        }
    }
}
