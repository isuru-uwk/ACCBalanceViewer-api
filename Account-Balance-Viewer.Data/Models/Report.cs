using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_Balance_Viewer.Data.Models
{
    public class Report
    {
        [Key]
        public int Id { get; set; }
        public decimal RD { get; set; }
        public decimal Canteen { get; set; }
        public decimal CEOCarExpences { get; set; }
        public decimal Marketing { get; set; }
        public decimal Parking { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }

    }
}
