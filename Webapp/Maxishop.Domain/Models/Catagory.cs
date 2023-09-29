using Maxishop.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxishop.Domain.Models
{
    public class Catagory : BaseModel
    {
        [Required]
        public  String Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
