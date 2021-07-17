using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.Modual
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dept Department { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
    }
}
