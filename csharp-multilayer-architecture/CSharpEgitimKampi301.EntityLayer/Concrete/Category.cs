using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.EntityLayer.Concrete
{

        /*
    Field --> classın içinde direkt tanımlanır
    Property --> classın içinde get ve setle tanımlanır
    Variable --> metodun içinde tanımlanır
        */
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public bool CategoryStatus { get; set; }

        public List<Product> Products { get; set; }

    }
}




