using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef.codeFirst.Models
{
    [Table("Country")]

    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<City> cities { get; set; }


    }
}
