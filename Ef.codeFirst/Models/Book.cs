using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef.codeFirst.Models
{
  public  class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Employee> Employees { get; set; }
        public Cover Cover { get; set; }
        public City City { get; set; }


    }
}
