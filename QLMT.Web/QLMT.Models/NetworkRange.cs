using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLMT.Models
{
    public class NetworkRange
    {
        [Key]
        public int RangeId { get; set; }
        public string RangeName { get; set; }
        public string IpAddress { get; set; }
        public string Status { get; set; }
    }
}
