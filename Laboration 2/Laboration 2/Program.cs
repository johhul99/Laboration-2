using System.ComponentModel.Design;

Product Pigelin = new Product("Pigelin", 12);
Product Cola = new Product("Coca Cola", 15.99);
Product Marabou = new Product("Marabou", 24.95);

Customer Test1 = new Customer("Test1", "Test1");
Customer Test2 = new Customer("Test2", "Test2");
Customer Test3 = new Customer("Test3", "Test3");

List<Customer> Customers = new List<Customer> { { Test1 }, { Test2 }, { Test3 } };

while (1 == 1)
{
    Console.Clear();
    Console.WriteLine("Välkommen till Johans Kiosk!");
    Console.WriteLine("1. Logga in");
    Console.WriteLine("2. Registrera ny kund");
    Console.WriteLine("Valfri annan tangent för att avsluta.");
    Console.WriteLine("Vänligen svara med 1 eller 2 för att gå vidare.");
    string answer1 = Console.ReadLine();
    if (answer1 == "1")
    {
        Console.Clear();
        Console.WriteLine("Ange användarnamn:");
        string UsernameInput = Console.ReadLine();



        bool UsernameSuccess = LoginUsername(UsernameInput);

        if (UsernameSuccess)
        {
            while (1 == 1)
            {
                Console.WriteLine("Ange lösenord.");
                string PasswordInput = Console.ReadLine();

                bool LoginSuccess = Login(UsernameInput, PasswordInput);
                if (LoginSuccess)
                {


                    foreach (Customer C in Customers)
                    {
                        if (C.Username == UsernameInput)
                        {
                            Customer Active = C;

                            while (1 == 1)
                            {
                                Console.Clear();
                                Console.WriteLine("Välkommen " + UsernameInput + "!");
                                Console.WriteLine("Meny");
                                Console.WriteLine("1. Handla");
                                Console.WriteLine("2. Kundvagn");
                                Console.WriteLine("3. Logga ut");
                                string answer = Console.ReadLine();


                                if (answer == "1")
                                {
                                    while (1 == 1)
                                    {
                                        Console.Clear();
                                        Console.Write("1"); Pigelin.ShowProduct();
                                        Console.Write("2"); Cola.ShowProduct();
                                        Console.Write("3"); Marabou.ShowProduct();
                                        Console.WriteLine();
                                        Console.WriteLine("Skriv in siffran framför den produkt du vill lägga till i varukorgen eller valfri annan tangent för att gå tillbaka till menyn.");
                                        string answer2 = Console.ReadLine();
                                        if (answer2 == "1")
                                        {
                                            Console.Clear();
                                            Active.AddToCart(Pigelin);
                                            Console.ReadLine();

                                        }
                                        else if (answer2 == "2")
                                        {
                                            Console.Clear();
                                            Active.AddToCart(Cola);
                                            Console.ReadLine();
                                        }
                                        else if (answer2 == "3")
                                        {
                                            Console.Clear();
                                            Active.AddToCart(Marabou);
                                            Console.ReadLine();
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }

                                else if (answer == "2")
                                {
                                    Console.Clear();
                                    Active.ShowCart();
                                    Console.WriteLine("Klicka 1 för att avsluta köp eller valfri tangent för att gå tillbaka.");
                                    string answer2 = Console.ReadLine();
                                    if (answer2 == "1")
                                    {
                                        Console.Clear();
                                        Active.ToString();
                                        Active.CheckoutCart();
                                        Console.WriteLine("Du återvänder nu till menyn.");
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Du återvänder nu till menyn.");
                                        Console.ReadLine();
                                    }

                                }
                                else if (answer == "3")
                                {
                                    Console.Clear();
                                    Console.WriteLine("Hejdå.");
                                    Console.ReadLine();
                                    break;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Vänligen svara med 1, 2 eller 3.");
                                    Console.ReadLine();
                                }

                            }
                        }
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Fel lösenord, vill du försöka igen? Skriv JA");
                    string answer = Console.ReadLine();
                    if (answer == "JA")
                    {
                        Console.Clear();
                        Console.WriteLine("Ange användarnamn:");
                        Console.WriteLine(UsernameInput);
                    }
                    else
                    {
                        break;
                    }
                }       
            }             
        }   
        else
        {
                Console.WriteLine("Användarnamnet finns ej registrerat, vill du registrera dig? Skriv: JA");
                string answer = Console.ReadLine();
                if (answer == "JA")
                {
                Console.Clear();
                Console.WriteLine("Ange användarnamn:");
                Console.WriteLine(UsernameInput);
                    Console.WriteLine("Skriv in ditt önskade lösenord.");
                    string InputPass = Console.ReadLine();
                    Customer c2 = new Customer(UsernameInput, InputPass);
                    Customers.Add(c2);
                    Console.WriteLine("Du är nu registrerad och kan logga in, du blir omdirigerad till hemskärmen.");
                    Console.ReadLine();                   
                }
                else
                {
                    Console.WriteLine("Du blir omdirigerad till hemskärmen.");
                }
            }
        
    }
    else if (answer1 == "2")
    {
        Console.Clear();
        Console.WriteLine("Skriv in önskat användarnamn.");
        string UsernameInput = Console.ReadLine();

        bool RegistrationSuccess = Register(UsernameInput);
        if (RegistrationSuccess)
        {
            Console.WriteLine("Skriv in önskat lösenord.");
            string PasswordInput = Console.ReadLine();

            Customer c1 = new Customer(UsernameInput, PasswordInput);
            Customers.Add(c1);
            Console.WriteLine("Du är nu registrerad, du kan nu logga in och dirigeras om till hemskärmen.");
            Console.ReadLine();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Användarnamn upptaget! Du skickas tillbaka till hemskärmen.");
            Console.ReadLine();
        }

    }
    else
    {
        Console.WriteLine("Hejdå!");
        Console.ReadLine();
        break;
    }
}



bool Register (string user)
{
    foreach (Customer c in Customers)
    {
        if (c.Username == user)
        {
            return false;
        }
    }
    return true;
}


bool LoginUsername (string user)
{
    foreach (Customer c in Customers)
    {
        if (c.Username == user)
        {
            return true;
        }
    }
    return false;
}

bool Login (string user, string pass)
{
    foreach (Customer c in Customers)
    {
        if (c.Username == user && c.Password == pass)
        {
            return true;
        }
    }
    return false;
}

public class Product
{
    public string Name;
    public double Price;

    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public void ShowProduct()
    {
        Console.WriteLine(Name + ", " + Price + "SEK");
    }
}

public class Customer
{
    public string Username;
    public string Password;
    public List<Product> Cart = new List<Product>();

    public Customer (string username, string password)
    {
        Username = username;
        Password = password;
    }


    public List<Product> CheckoutCart()
    {
        double total = 0;
        foreach (Product product in Cart)
        {
            total += product.Price; 
        }
        Console.WriteLine("Din slutsumma är " + total + "SEK.");
        Cart = new List<Product>();
        return Cart;
    }

    public List<Product> AddToCart(Product p)
    {
        Cart.Add(p);
        Console.WriteLine("1st " + p.Name + " har blivit tillagd i din varukorg.");
        return Cart;
    }

    public void ShowCart()
    {
        double ColaCounter = 0;
        double PigelinCounter = 0;
        double MarabouCounter = 0;
        double ColaPriceTotal = 0;
        double PigelinPriceTotal = 0;
        double MarabouPriceTotal = 0;

        foreach (Product p in Cart)
        {
            if (p.Name == "Pigelin")
            {
                PigelinCounter++;
                PigelinPriceTotal += 12;
            }
            else if (p.Name == "Coca Cola")
            {
                ColaCounter++;
                ColaPriceTotal += 15.99;
            }
            else
            {
                MarabouCounter++;
                MarabouPriceTotal += 24.95;
            }

        }
        if (ColaCounter > 0)
        {
            Console.WriteLine(ColaCounter + "st Coca Cola: " + ColaPriceTotal + " SEK");
        }
        if (PigelinCounter > 0)
        {
            Console.WriteLine(PigelinCounter + "st Pigelin: " + PigelinPriceTotal + " SEK");
        }
        if (MarabouCounter > 0)
        {
            Console.WriteLine(MarabouCounter + "st Marabou: " +  MarabouPriceTotal + " SEK");
        }
        Console.WriteLine("Totalt: " + (MarabouPriceTotal + PigelinPriceTotal + ColaPriceTotal) + " SEK");
    }

    public void ToString()
    {
        Console.WriteLine("Username: " + Username + " Password: " + Password);
        ShowCart();
    }
}

