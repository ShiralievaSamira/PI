using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace cashAccounting.Models
{
    public class Income
    {
        public int Id { get; set; }
        [Display(Name = "Sum")]
        public decimal Sum { get; set; }
        [Display(Name = "Category")]
        public string Category { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Date")]
        public DateTime DateIncome { get; set; }
        [Display(Name = "Comment")]
        public string Comment { get; set; }
        public ApplicationUser User { get; set; }
    }
}