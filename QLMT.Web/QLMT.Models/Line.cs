using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLMT.Models
{
    public class Line
    {
        [Key]
        public int LineId { get; set; }
        public string LineName { get; set; }
        public string Note { get; set; }
    }
}
