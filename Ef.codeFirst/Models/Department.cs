using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef.codeFirst.Models
{
    public class Department
    {
        public int DeptId { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }

        public Manager Manager { get; set; }
        [ForeignKey("Manager")]
        public int Fk_ManagerId { get; set; }
    }
}
