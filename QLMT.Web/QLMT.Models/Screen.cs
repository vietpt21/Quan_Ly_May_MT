using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLMT.Models
{
    public class Screen
    {
        [Key]
        public int ScreenId { get; set; }
        public string ScreenName { get; set; }
        public DateTime EntryDate { get; set; }
        public Boolean Status { get; set; }
    }
}
