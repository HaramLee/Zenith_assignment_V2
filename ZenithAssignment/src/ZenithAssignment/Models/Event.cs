using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenithAssignment.Models.CustomValidation;

namespace ZenithAssignment.Models
{
    [Table("Event")]
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Display(Name = "Date & From time")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy hh:mm tt}")]
        public DateTime FromDate { get; set; }

        [Display(Name = "Date & To time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy hh:mm tt}")]
        [DateDifference]
        [DataType(DataType.DateTime)]
        [FromDateAfterToDate]
        public DateTime ToDate { get; set; }

        [ForeignKey("Activity")]
        [Display(Name = "Activity")]
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }

        [Display(Name = "Creator")]
        public string Id { get; set; }


        [ForeignKey("Id")]
        public ApplicationUser ApplicationUser { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Date Created")]
        [ScaffoldColumn(false)]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; } = true;
    }
}

