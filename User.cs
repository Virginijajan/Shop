using System;
using System.Collections.Generic;
using System.Text;

namespace Shop
{
    class User

    {
        public decimal money;
        public string name;


        public  User(string n, decimal mon)
        {
            money = mon;
            name = n;
        }

        public void ToPop(decimal mon)
        {
            money=money + mon;
        }

        public void UserBuy(decimal mon)
        {
            if (mon > money)
            {
                Console.WriteLine("Neuztenka pinigu!");

            }
            else
            {
                money = money - mon;
            }
        }


         public void showBalance()
            {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("VARTOTOJO PINIGU LIKUTIS");
            Console.WriteLine($"VARTOTOJAS: {name}\t {money} EUR");
            Console.WriteLine("------------------------------------------------");

        }


    }
}
