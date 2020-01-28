using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
   public class Report
    {
        [Key]
        public Int64 Id { get; set; }

        [Required]
        public string Title { get; set; }

        public Int64 ApplicationId { get; set; }
    }
}
