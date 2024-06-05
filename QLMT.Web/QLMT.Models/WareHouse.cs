using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLMT.Models
{
    public class WareHouse
    {
        [Key]
        public int WareHouseId { get; set; }
        public string WareHouseName { get; set; }
        public string Address { get; set; }
    }
}
