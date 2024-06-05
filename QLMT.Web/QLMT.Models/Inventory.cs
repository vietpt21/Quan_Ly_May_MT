using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLMT.Models
{
    public class Inventory
    {
        [Key]
        public int InventotyId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public DateTime Entry_Date { get; set; }
        public DateTime Exit_Date { get; set; }
        public string Satatus { get; set; }
        public int WareHouseId { get; set; }
    }
}
