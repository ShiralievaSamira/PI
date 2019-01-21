using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace cashAccounting.Models
{
    public class Target
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Currency")]
        public string Currency { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Final date")]
        public DateTime FinalDate { get; set; }
        [Display(Name = "Monthly fee")]
        public decimal MonthlyFee { get; set; }
        [Display(Name = "Comment")]
        public string Comment { get; set; }
        public ApplicationUser User { get; set; }
    }
}