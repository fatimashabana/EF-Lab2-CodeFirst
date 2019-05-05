using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ef.codeFirst.Models
{
   public class Manager
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Department Department { get; set; }
        [ForeignKey("Department")]
        public int Fk_DepartmentId { get; set; }


    }
}
