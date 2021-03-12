using System;
using System.Collections.Generic;
using System.Text;

namespace Shop
{
    class Product
    {
       public string categoty;
       public string name;
       public decimal price;
       public int number;


        public Product(string prodCategory, string prodName, decimal prodPrice, int prodNumber)
        {
            categoty = prodCategory;
            name = prodName;
            price = prodPrice;
            number = prodNumber;

        }

        public void Add(int numbAdd)
        {
            number = number + numbAdd;
        }

        public void Buy(int numbBuy)
        {
            number = number - numbBuy;

            if (number < 0)
            {
                number = 0;
            }
        }

        public void List()      {
            Console.WriteLine($"\tKategorija {categoty} \t\t {name} \t\t\t kaina {price} EUR \t\t kiekis {number} vnt.");
        }
    }
}
