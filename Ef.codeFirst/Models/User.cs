using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef.codeFirst.Models
{
  public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserVisits> UserVisits { get; set; }
    }
}
