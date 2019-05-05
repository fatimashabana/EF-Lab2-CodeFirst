using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef.codeFirst.Models
{
    public class UserVisits
    {
        public DateTime When { get; set; }
        public User User { get; set; }
        public City City { get; set; }

        [Key]
        [Column (Order=1)]
        [ForeignKey("City")]
        public int Fk_CityId { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("User")]
         public int Fk_UserId { get; set; }

    }
}
