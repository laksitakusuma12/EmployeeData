using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OFFICE_WebApp.Models
{
    public class Position
    {
        [Key]
        public int Id { get; set; }
        public string PositionEmployee { get; set; }
        public Major Major { get; set; }
        [ForeignKey("Major")]
        public int MajorId { get; set; }
    }
}
