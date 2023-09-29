using Maxishop.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxishop.Domain.Models
{
    public class Product : BaseModel
    {
        public int CatagoryId { get; set; }

        [ForeignKey("CatagoryId")]
        public Catagory Catagory { get; set;}

        public int BrandId { get; set; }

        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }


        public string Name {  get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

    }
}
