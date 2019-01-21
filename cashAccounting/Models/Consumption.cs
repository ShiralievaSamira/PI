using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cashAccounting.Models
{
    public class Consumption
    {
        public int Id { get; set; }
        [Display(Name = "Sum")]
        public decimal Sum { get; set; }
        [Display(Name = "Category")]
        public string Category { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Date")]
        public DateTime DateConsumption { get; set; }
        [Display(Name = "Comment")]
        public string Comment { get; set; }
        public ApplicationUser User { get; set; }
    }
}