using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLMT.Models
{
    public class Management
    {
        [Key]
        public Int64 Id { get; set; }
        public int UnitId { get; set; }
        public string UnitName { get; set; }

        public int LineId { get; set; }
        public string LineName { get; set; }

        public int ComputerId { get; set; }
        public string ComputerName { get; set; }

        public int RangeId { get; set; }
        public string RangeName { get; set; }
        public string IpAddress { get; set; }

        public int ScreenId { get; set; }
        public string ScreenName { get; set; }
    }
}
