using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Ikea
{
    class ShoppingCart
    {
        public List<Product> Products { get; set; }
        private List<Product> availableProducts;

        public ShoppingCart()
        {
            Products = new List<Product>()
            {
                new Product
                {
                    Name = "Jubla",
                    ArticleNumber="271.500.10",
                    Price=99,
                    Height=10,
                    Length=25,
                    Width=21,
                    Amount=1
                },
                new Product
                {
                    Name = "Henriksdal",
                    ArticleNumber="303.610.38",
                    Price=695,
                    Height=25,
                    Length=98,
                    Width=48,
                    Amount=1
                },
                new Product
                {
                    Name = "Billy",
                    ArticleNumber="002.638.50",
                    Price=495,
                    Height=13,
                    Length=205,
                    Width=29,
                    Amount=1
                }
            };
            availableProducts = new List<Product>()
{
    new Product
    {
        Name = "Jubla",
        ArticleNumber="271.500.10",
        Price=99,
        Height=10,
        Length=25,
        Width=21
    },
    new Product
    {
        Name = "Henriksdal",
        ArticleNumber="303.610.38",
        Price=695,
        Height=25,
        Length=98,
        Width=48
    },
    new Product
    {
        Name = "Billy",
        ArticleNumber="002.638.50",
        Price=495,
        Height=13,
        Length=205,
        Width=29
    },
    new Product
    {
        Name = "Sofie",
        ArticleNumber="404.403.42",
        Price=149,
        Height=8,
        Length=28,
        Width=27
    },
    new Product
    {
        Name = "Ryet",
        ArticleNumber = "104.387.22",
        Price = 29,
        Height = 6,
        Length = 12,
        Width = 10
    },
    new Product
    {
        Name = "Kulinarisk",
        ArticleNumber = "704.210.59",
        Price = 7295,
        Height = 64,
        Length = 67,
        Width = 66
    },
};
        }

        public double GetTotalCost()
        {
            double total = 0.0;
            foreach(Product p in Products)
            {
                total += p.Price*p.Amount;
            }

            return total;
        }

        public int GetMaxWidth()
        {
            int max = 0;
            foreach(Product p in Products)
            {
                if (p.Width > max)
                    max = p.Width;
            }
            return max;
        }
        public int GetMaxLength()
        {
            int max = 0;
            foreach (Product p in Products)
            {
                if (p.Length > max)
                    max = p.Length;
            }
            return max;
        }
        public int GetTotalHeight()
        {
            int total = 0;
            foreach(Product p in Products)
            {
                total += p.Height*p.Amount;
            }
            return total;
        }

        public void AddToCart(string item)
        {
            bool productInCart = false;
            foreach(Product p in Products)
            {
                if(p.ArticleNumber == item)
                {
                    productInCart = true;
                    p.Amount++;
                }
            }
            if (!productInCart)
            {
                Product temp = GetProductFromStock(item);
                temp.Amount++;
                Products.Add(temp);
            }
        }

        private Product GetProductFromStock(string articleNumber)
        {
            return availableProducts
            .Where(x => x.ArticleNumber.Equals(articleNumber))
            .FirstOrDefault();
        }

    }
}
