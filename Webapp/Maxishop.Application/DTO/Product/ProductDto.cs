using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxishop.Application.DTO.Product
{
    public class ProductDto
    {

        public int Id { get; set; }

        public int CatagoryId { get; set; }


        public string Catagory {  get; set; }


        public int BrandId { get; set; }


        public string Brand { get; set; }


        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }
    }
}
