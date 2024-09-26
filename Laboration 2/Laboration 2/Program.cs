using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using System.Text.Json.Serialization;
using Metoder;
using KlasserOchObjekt;
using System.Collections.Generic;


Product Pigelin = new Product("Pigelin", 12);
Product Cola = new Product("Coca Cola", 15.99);
Product Marabou = new Product("Marabou", 24.95);

List <Product> products = new List<Product> { { Pigelin }, { Cola }, { Marabou } };

CustomerGold Test1 = new CustomerGold("Test1", "Test1", new List<Product>());
CustomerSilver Test2 = new CustomerSilver("Test2", "Test2", new List<Product>());
CustomerBronze Test3 = new CustomerBronze("Test3", "Test3", new List<Product>());
Customer Bas1 = new Customer("Bas1", "Bas1", new List<Product>());


List<Customer> Customers = new List<Customer> { { Test1 }, { Test2 }, { Test3 }, { Bas1 } };



string filePath = "data.json";
LoadObjects();

while (1 == 1)
{
    Console.Clear();
    Console.WriteLine("Välkommen till Johans Kiosk!");
    Console.WriteLine("1. Logga in");
    Console.WriteLine("2. Registrera ny kund");
    Console.WriteLine("Valfri annan symbol för att avsluta.");
    Console.WriteLine("Vänligen svara med 1 eller 2 för att gå vidare.");
    ConsoleKeyInfo answer1 = Console.ReadKey();
    if (answer1.Key == ConsoleKey.D1)
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
                                ConsoleKeyInfo answer = Console.ReadKey();


                                if (answer.Key == ConsoleKey.D1)
                                {
                                    while (1 == 1)
                                    {
                                        Console.Clear();
                                        Console.Write("1"); Pigelin.ShowProduct();
                                        Console.Write("2"); Cola.ShowProduct();
                                        Console.Write("3"); Marabou.ShowProduct();
                                        Console.WriteLine();
                                        Console.WriteLine("Skriv in siffran framför den produkt du vill lägga till i varukorgen och tryck enter eller valfri symbol och/eller enter för att gå tillbaka till menyn.");
                                        string answer2 = Console.ReadLine();
                                        if (answer2 == "1" || answer2 == "2" || answer2 == "3")
                                        {
                                            for (int i = 0; i < products.Count; i++)
                                            {
                                                
                                                if (Convert.ToInt32(answer2) == i + 1)
                                                {
                                                    Console.Clear();
                                                    Active.AddToCart(products[i]);
                                                    Console.ReadLine();
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Du blir omdirigerad tillbaka til menyn.");
                                            Console.ReadLine();
                                            break;
                                        }
                                    }
                                }
                                else if (answer.Key == ConsoleKey.D2)
                                {
                                    Console.Clear();
                                    Active.ShowCart();
                                    Console.WriteLine("Skriv in 1 för att avsluta köp eller valfri symbol för att gå tillbaka.");
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
                                else if (answer.Key == ConsoleKey.D3)
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
                    Console.WriteLine("Fel lösenord, vill du försöka igen? Skriv JA. Skriv annars valfri symbol eller klicka bara enter för att komma till hemskärmen.");
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
            Console.WriteLine("Användarnamnet finns ej registrerat, vill du registrera dig? Skriv: JA. Skriv annars valfri symbol eller klicka enter för att komma till hemskärmen.");
            string answer = Console.ReadLine();
            if (answer == "JA")
            {
                Console.Clear();
                Console.WriteLine("Ange användarnamn:");
                Console.WriteLine(UsernameInput);
                Console.WriteLine("Skriv in ditt önskade lösenord.");
                string InputPass = Console.ReadLine();
                Customers.Add(CustomerType(UsernameInput, InputPass));
                Console.WriteLine("Du är nu registrerad och kan logga in, du blir omdirigerad till hemskärmen.");
                Console.ReadLine();                   
            }
            else
            {
                    Console.WriteLine("Du blir omdirigerad till hemskärmen.");
            }
        }
        
    }
    else if (answer1.Key == ConsoleKey.D1)
    {
        while (1 == 1)
        {
            Console.Clear();
            Console.WriteLine("Skriv in önskat användarnamn.");
            string UsernameInput = Console.ReadLine();

            bool RegistrationSuccess = Register(UsernameInput);
            if (RegistrationSuccess)
            {
                Console.WriteLine("Skriv in önskat lösenord.");
                string PasswordInput = Console.ReadLine();
                Customers.Add(CustomerType(UsernameInput, PasswordInput));
                Console.WriteLine("Du är nu registrerad, du kan nu logga in och dirigeras om till hemskärmen.");
                Console.ReadLine();
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Användarnamn upptaget! Skriv JA för att försöka igen eller valfri annan symbol eller klicka enter för att komma till hemskärmen.");
                string answer = Console.ReadLine();
                if (answer == "JA")
                {
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
        Console.WriteLine("Hejdå!");
        Console.ReadLine();
        break;
    }
}
SaveObjects();



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

Customer CustomerType (string UsernameInput, string InputPass)
{
    Customer c2;
    while (1 == 1)
    {
        Console.WriteLine("Skriv in kundtyp, GOLD, SILVER, BRONZE eller BAS.");
        string kundtyp = Console.ReadLine();
        if (kundtyp == "GOLD")
        {
            c2 = new CustomerGold(UsernameInput, InputPass, new List<Product>());
            break;
        }
        else if (kundtyp == "SILVER")
        {
            c2 = new CustomerSilver(UsernameInput, InputPass, new List<Product>());
            break;
        }
        else if (kundtyp == "BRONZE")
        {
            c2 = new CustomerBronze(UsernameInput, InputPass, new List<Product>());
            break;
        }
        else if (kundtyp == "BAS")
        {
            c2 = new Customer(UsernameInput, InputPass, new List<Product>());
            break;
        }
        else
        {
            Console.WriteLine("Vänligen svara med ett av alternativen.");
        }
    }
    return c2;
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

void SaveObjects()
{
    string jsonString = JsonSerializer.Serialize(Customers, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText(filePath, jsonString);
}

void LoadObjects()
{
    string savedJson = File.ReadAllText(filePath);
    var options = new JsonSerializerOptions
    {
        IncludeFields = true, 
        WriteIndented = true
    };

    Customers = JsonSerializer.Deserialize<List<Customer>>(savedJson, options);
}
public class Product
{
    public string Name { get; set; }
    public double Price {  get; set; }

    public Product() { }
    public Product(string Name, double Price)
    {
        this.Name = Name;
        this.Price = Price;
    }

    public void ShowProduct()
    {
        Console.WriteLine(Name + ", " + Price + "SEK");
    }
}

public class Customer
{
    public string Username { get; private set; }
    public string Password { get; private set; }
    public List<Product> Cart { get; set; }

    public Customer(string Username, string Password, List<Product> Cart)
    {
        this.Username = Username;
        this.Password = Password;
        this.Cart = Cart ?? new List<Product>();
    }

    public virtual List<Product> CheckoutCart()
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

    public virtual void ShowCart()
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

public class CustomerGold : Customer 
{
    public CustomerGold(string Username, string Password, List<Product> Cart) : base (Username, Password, Cart)
    {
    }
    public override void ShowCart()
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
            Console.WriteLine(MarabouCounter + "st Marabou: " + MarabouPriceTotal + " SEK");
        }
        Console.WriteLine("Totalt: " + (MarabouPriceTotal + PigelinPriceTotal + ColaPriceTotal) + " SEK");
        Console.WriteLine("Med din rabatt på 15%: " + (MarabouPriceTotal + PigelinPriceTotal + ColaPriceTotal)*0.85);
    }

    public override List<Product> CheckoutCart()
    {
        double total = 0;
        foreach (Product product in Cart)
        {
            total += product.Price;
        }
        Console.WriteLine("Din slutsumma är " + total * 0.85 + "SEK.");
        Cart = new List<Product>();
        return Cart;
    }

}

public class CustomerSilver : Customer
{
    public CustomerSilver(string Username, string Password, List<Product> Cart) : base(Username, Password, Cart)
    {
    }
    public override void ShowCart()
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
            Console.WriteLine(MarabouCounter + "st Marabou: " + MarabouPriceTotal + " SEK");
        }
        Console.WriteLine("Totalt: " + (MarabouPriceTotal + PigelinPriceTotal + ColaPriceTotal) + " SEK");
        Console.WriteLine("Med din rabatt på 10%: " + (MarabouPriceTotal + PigelinPriceTotal + ColaPriceTotal) * 0.90);
    }

    public override List<Product> CheckoutCart()
    {
        double total = 0;
        foreach (Product product in Cart)
        {
            total += product.Price;
        }
        Console.WriteLine("Din slutsumma är " + total * 0.90 + "SEK.");
        Cart = new List<Product>();
        return Cart;
    }
}
public class CustomerBronze: Customer
{
    public CustomerBronze(string Username, string Password, List<Product> Cart) : base(Username, Password, Cart)
    {
    }
    public override void ShowCart()
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
            Console.WriteLine(MarabouCounter + "st Marabou: " + MarabouPriceTotal + " SEK");
        }
        Console.WriteLine("Totalt: " + (MarabouPriceTotal + PigelinPriceTotal + ColaPriceTotal) + " SEK");
        Console.WriteLine("Med din rabatt på 5%: " + (MarabouPriceTotal + PigelinPriceTotal + ColaPriceTotal) * 0.95);
    }

    public override List<Product> CheckoutCart()
    {
        double total = 0;
        foreach (Product product in Cart)
        {
            total += product.Price;
        }
        Console.WriteLine("Din slutsumma är " + total * 0.95 + "SEK.");
        Cart = new List<Product>();
        return Cart;
    }

}