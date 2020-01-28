using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class Application
    {
        [Key]
        public Int64 Id { get; set; }

        [Required]
        public string Title { get; set; }

        [ForeignKey("ApplicationId")]
        public ICollection<Report> Reports { get; set; }
    }
}
