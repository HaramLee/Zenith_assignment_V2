using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZenithAssignment.Models
{
    public class RolesModel
    {
        [Display(Name = "Role")]
        public string name { get; set; }
    }
}
