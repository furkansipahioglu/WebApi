using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAPI.Models
{
    public class AdminUser
    {
        [Key]
        public string adminname { get; set; }
        public string adminpass { get; set; }
        public string adminmail { get; set; }
        
        


    }
}
