using System;
using System.Collections.Generic;

namespace Shop
{
    class Program
    {


        static void Main(string[] args)
        {
            string command;
            bool end = false;
            bool end1=false;
            bool endProgr = false;
            int number;
            string userName;
            decimal userMoney;


            // Create a list of products.
            List<Product> p = new List<Product>();

           

            Console.WriteLine("Vartotojo vardas: ");
            userName = Console.ReadLine();

            Console.WriteLine("Vartotojo pinigai: ");

            do
            {
                string v = Console.ReadLine();

                if (decimal.TryParse(v, out userMoney))
                {
                    end = true;
                }
                else
                {
                    Console.WriteLine("Neteisingas skaicius!");
                }
            } while (end == false);

            User u = new User(userName, userMoney);




            do { 

            end = false;

            do
                {
                Console.WriteLine("-----------------------KOMANDOS--------------------- ");
                Console.WriteLine("");
                Console.WriteLine("Papildykite parduotuve naujais produktais (AddNew): ");
                Console.WriteLine("Papildykite produktu (Add): ");
                Console.WriteLine("Pirkti produktu (Buy): ");
                Console.WriteLine("Spausdinti produktu sarasa (List): ");

                Console.WriteLine("Papildyti vartotojo saskaita (Topop): ");
                Console.WriteLine("Parodyti vartotojo balansa (ShowB): ");

                Console.WriteLine("Pabaiga (End): ");
                Console.WriteLine("------------------------------------------------------");



               
                command = Console.ReadLine();


                    if (command == "Topop")
                    {
                        Console.WriteLine("Vartotojo pinigai: ");

                        do
                        {
                            string v = Console.ReadLine();

                            if (decimal.TryParse(v, out userMoney))
                            {
                                end1 = true;
                            }
                            else
                            {
                                Console.WriteLine("Neteisingas skaicius!");
                            }
                        } while (end1 == false);

                    u.ToPop(userMoney);
                    u.showBalance();
                    end = true;

                    }

                    else if (command == "ShowB")
                    {
                        u.showBalance();
                        end = true;
                    }


                    else if (command == "AddNew")
                    {
                        p = AddNewProduct(p);
                        end = true;
                    }




                    else if (command == "Add")
                    {
                        if (p.Count > 0)
                        {
                            Console.WriteLine("Pasirinkite produkta (produkto pavadinimas)");
                            string name = Console.ReadLine();
                            Console.WriteLine("Kiekis: ");
                             end1 = false;
                            do
                            {
                                string n = Console.ReadLine();

                                if (int.TryParse(n, out number))
                                {
                                    end1 = true;
                                }
                                else
                                {
                                    Console.WriteLine("Neteisingas kiekis!");
                                }
                            } while (end1 == false);

                            p = Add(p, name, number);
                            PrintList(p);

                            end = true;
                        }
                        else
                        {
                            Console.WriteLine("Nera produktu");
                            end = true;
                        }
                    }



                    else if (command == "Buy")
                    {
                        if (p.Count > 0)
                        {
                            Console.WriteLine("Pasirinkite produkta (produkto pavadinimas)");
                            string name = Console.ReadLine();
                            Console.WriteLine("Kiekis: ");
                            end1 = false;
                            do
                            {
                                string n = Console.ReadLine();

                                if (int.TryParse(n, out number))
                                {
                                    end1 = true;
                                }
                                else
                                {
                                    Console.WriteLine("Neteisingas kiekis!");
                                }
                            } while (end1 == false);

                            p = Buy(p, name, number, u);
                            PrintList(p);
                            u.showBalance();
                            end = true;
                        }
                        else
                        {
                            Console.WriteLine("Nera produktu");
                            end = true;
                        }
                    }



                    else if (command == "List")
                    {
                        PrintList(p);
                        end = true;
                    }


                    else if (command == "End")
                    {
                        endProgr = true;
                        end = true;
                    }

                    else
                    {
                        Console.WriteLine("Neteisinga komanda");
                        Console.WriteLine("");
                    }

                } while (end == false);

            } while (endProgr == false);

            Console.WriteLine("---------------PABAIGA------------------");

        }








        static List<Product> AddNewProduct(List<Product> product)
            {

                string prodCategory;
                string prodName;
                decimal prodPrice;
                int prodNumber;
                bool end = false;


                Console.WriteLine("Iveskite produkto kategorija (Candy, Cup, Book): ");

                do
                {
                    prodCategory = Console.ReadLine();
                    end = true;
                    if (prodCategory != "Candy")
                    {
                        if (prodCategory != "Cup")
                        {
                            if (prodCategory != "Book")
                            {
                                end = false;
                            }
                        }
                    }


                } while (end == false);

                Console.WriteLine("Iveskite produkto pavadinima : ");

                prodName = Console.ReadLine();

                Console.WriteLine("Iveskite produkto kaina : ");

                end = false;
                do
                {
                    string price = Console.ReadLine();

                    if (decimal.TryParse(price, out prodPrice))
                    {
                        end = true;
                    }
                    else
                    {
                        Console.WriteLine("Neteisinga kaina!");
                    }
                } while (end == false);

                Console.WriteLine("Iveskite produkto kieki : ");

                end = false;
                do
                {
                    string number = Console.ReadLine();

                    if (int.TryParse(number, out prodNumber))
                    {
                        end = true;
                    }
                    else
                    {
                        Console.WriteLine("Neteisingas kiekis!");
                    }
                } while (end == false);



                // Add product to the list.
                product.Add(new Product(prodCategory, prodName, prodPrice, prodNumber));


                PrintList(product);

                return product;
            }








            static void PrintList(List<Product> product)
            {
            Console.WriteLine("---------------------------PRODUKTU SARASAS--------------------------------------------------------------------------");
            Console.WriteLine("");

            foreach (Product prod in product)
                {
                if (prod.number > 0)
                {
                    prod.List();
                }
                }
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
        }






        static List<Product> Add(List<Product> product, string name, int number)
        {
            foreach (Product prod in product)
            {
                if (prod.name == name)
                {
                    prod.Add(number);
                    return product;
                   
                }
            }
            Console.WriteLine("-------------------");
            Console.WriteLine("Nera tokio produkto!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            return product;
        }







        static List<Product> Buy(List<Product> product, string name, int number, User u)
        {
            foreach (Product prod in product)
            {
                if (prod.name == name)
                {
                    if (number > prod.number)
                    {
                        number = prod.number;
                    }
                          
                    decimal m = prod.price * number;
                    if (u.money > m)
                    {
                        u.UserBuy(m);
                        prod.Buy(number);
                        return product;
                    }
                    else
                    {
                        Console.WriteLine("-----------------------------------------------------");
                        Console.WriteLine("Neuztenka pinigu!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                        return product;
                    }
                }
            }
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Nera tokio produkto!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            return product;
        }







    }
}
