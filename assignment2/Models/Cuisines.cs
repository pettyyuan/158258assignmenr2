using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace assignment2.Models
{
    public class Cuisines
    {
        [Key]
        public int Id { get; set; }
        public string type { get; set; }
        public ICollection<local_dishes> local_Dishes { get; set; }
    }
}