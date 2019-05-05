using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef.codeFirst.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public Department Department { get; set; }
        public int Fk_DepartmentId { get; set; }
        public List<Book> Books { get; set; }
               
    }
}
