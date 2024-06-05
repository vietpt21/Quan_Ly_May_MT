using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLMT.Models
{
    public class LocationManagement
    {
        [Key]
        public int ManagementId { get; set; }
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public int RangeId { get; set; }
        public int ComputerId { get; set; }
        public int ScreenId { get; set; }
    }
}
