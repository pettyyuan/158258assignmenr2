using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace assignment2.Models
{
    public class local_dishes
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string local {  get; set; }
        public int? Cuisinesid { get; set; }
        public virtual Cuisines Cuisines { get; set; }
    }
}