using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxishop.Application.DTO.Product
{
    public class CreateProductDto
    {

        public int CatagoryId { get; set; }


        public int BrandId { get; set; }


        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }
    }
}
