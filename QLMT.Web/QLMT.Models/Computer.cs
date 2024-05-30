using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLMT.Models
{
    public class Computer
    {

        [Key]
        public int ComputerId { get; set; }
        public string ComputerName { get; set; }
        public DateTime EntryDate { get; set; }
        public string Configuration { get; set; }
        public Boolean Status { get; set; }
    }
}
