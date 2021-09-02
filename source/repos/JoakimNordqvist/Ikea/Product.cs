using System;
using System.Collections.Generic;
using System.Text;

namespace Ikea
{
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string ArticleNumber { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }

        public int Amount { get; set; }

        public Product()
        {

        }

        public override string ToString()
        {
            return $"{Name} {Price:C} {ArticleNumber} {Amount}st";
        }
    }
}
