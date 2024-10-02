using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using System.Text.Json.Serialization;
using KlasserOchObjekt;
using System.Collections.Generic;


Product Pigelin = new Product("Pigelin", 12);
Product Cola = new Product("Coca Cola", 16);
Product Marabou = new Product("Marabou", 25);

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
                            string valuta = "SEK";

                            while (1 == 1)
                            {
                                Console.Clear();
                                Console.WriteLine("Välkommen " + UsernameInput + "!");
                                Console.WriteLine("Meny");
                                Console.WriteLine("1. Handla");
                                Console.WriteLine("2. Kundvagn");
                                Console.WriteLine("3. Ändra valuta");
                                Console.WriteLine("4. Logga ut");
                                ConsoleKeyInfo answer = Console.ReadKey();
                                
                                if (answer.Key == ConsoleKey.D1)
                                {
                                    while (1 == 1)
                                    {
                                        Console.Clear();
                                        Product.ShowProduct(valuta, products);
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
                                                    Console.ReadKey();
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Du blir omdirigerad tillbaka til menyn.");
                                            Console.ReadKey();
                                            break;
                                        }
                                    }
                                }
                                else if (answer.Key == ConsoleKey.D2)
                                {
                                    Console.Clear();
                                    Active.ShowCart(valuta);
                                    Console.WriteLine("Skriv in 1 för att avsluta köp eller valfri symbol för att gå tillbaka.");
                                    string answer2 = Console.ReadLine();
                                    if (answer2 == "1")
                                    {
                                        Console.Clear();
                                        Active.CheckoutCart(valuta);
                                        Console.WriteLine("Du återvänder nu till menyn.");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Du återvänder nu till menyn.");
                                        Console.ReadKey();
                                    }

                                }
                                else if (answer.Key == ConsoleKey.D3)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Nuvarande valuta: " + valuta);
                                    Console.WriteLine("Vilken valuta vill du se priser i?");
                                    Console.WriteLine("SEK");
                                    Console.WriteLine("EUR");
                                    Console.WriteLine("GBP");
                                    Console.WriteLine("Skriv in önskad valuta och klicka enter eller annat svar för att gå tillbaka till menyn.");
                                    string answer2 = Console.ReadLine();
                                    if (answer2 == valuta)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Du ser redan priser i " + answer2 + ".");
                                        Console.ReadKey();
                                    }
                                    else if (answer2 == "GBP")
                                    {
                                        Console.Clear();
                                        valuta = "GBP";
                                        Console.WriteLine("Du har bytt valuta till GBP.");
                                        Console.ReadKey();
                                    }
                                    else if (answer2 == "EUR")
                                    {
                                        Console.Clear();
                                        valuta = "EUR";
                                        Console.WriteLine("Du har bytt valuta till EUR.");
                                        Console.ReadKey();
                                    }
                                    else if (answer2 == "SEK")
                                    {
                                        Console.Clear();
                                        valuta = "SEK";
                                        Console.WriteLine("Du har bytt valuta till SEK.");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Du blir omdirigerad till menyn.");
                                        Console.ReadKey();
                                    }
                                }
                                else if (answer.Key == ConsoleKey.D4)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Hejdå.");
                                    Console.ReadKey();
                                    break;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Vänligen svara med 1, 2, 3 eller 4.");
                                    Console.ReadKey();
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
                Console.ReadKey();                   
            }
            else
            {
                    Console.WriteLine("Du blir omdirigerad till hemskärmen.");
            }
        }
        
    }
    else if (answer1.Key == ConsoleKey.D2)
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
                Console.ReadKey();
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
        Console.ReadKey();
        break;
    }
}
SaveObjects();



bool Register(string user)
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

Customer CustomerType(string UsernameInput, string InputPass)
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

bool LoginUsername(string user)
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

bool Login(string user, string pass)
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
    var options = new JsonSerializerOptions
    {
        WriteIndented = true,
        Converters = { new CustomerConverter() }
    };

    string jsonString = JsonSerializer.Serialize(Customers, options);
    File.WriteAllText(filePath, jsonString);
}

void LoadObjects()
{
    var options = new JsonSerializerOptions
    {
        Converters = { new CustomerConverter() }
    };

    try
    {
        string savedJson = File.ReadAllText(filePath);
        Customers = JsonSerializer.Deserialize<List<Customer>>(savedJson, options);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

