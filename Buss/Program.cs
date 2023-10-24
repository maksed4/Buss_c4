using System;
using System.Collections.Generic;

namespace Bussen
{
    class Program
    {
        static void Main(string[] args)
        {
            var minbuss = new Buss();
            minbuss.Run();
            Console.ReadKey(true);
        }
    }

    class Buss
    {
        Passagerare[] sittplatser = new Passagerare[25]; //25 platser på bussen
        int maxålderförpassagerare = 110; // Maxgräns ålder

        public void Run()
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Välkommen till Bussen! ===");
                Console.WriteLine("\nVälj ett alternativ i menyn under.\n" +
                                  "[1] Lägg till passagerare\n" +
                                  "[2] Nuvarande passagerare\n" +
                                  "[3] Extra meny för passagerare\n" +
                                  "[4] Avsluta");
                int Valmeny1 = Convert.ToInt32(Console.ReadLine());
                switch (Valmeny1)
                {
                    // Lägg till passagerare
                    case 1:
                        {
                            Add_passenger();
                            break;
                        }
                    // Nuvarande passagerare
                    case 2:
                        {
                            Print_buss();
                            break;
                        }
                    // Extra meny för passagerare
                    case 3:
                        {
                            Console.WriteLine("===== Passenger interaktion =====");
                            Console.WriteLine("  [1] Hitta passagera\n" +
                                              "  [2] Totala åldern\n" +
                                              "  [3] Genomsnittliga åldern\n" +
                                              "  [4] Passagerare med högst ålder\n" +
                                              "  [5] Sortera bussen efter ålder\n" +
                                              "  [6] Tillbaka till huvudmenyn");
                            int Valmeny2 = Convert.ToInt32(Console.ReadLine());
                            switch (Valmeny2)
                            {
                                // Hitta passagera med en specifik ålder
                                case 1:
                                    {
                                        Find_age();
                                        break;
                                    }
                                // Totala åldern i bussen
                                case 2:
                                    {
                                        Calc_total_age();
                                        break;
                                    }
                                // Genomsnittliga åldern i bussen
                                case 3:
                                    {
                                        Calc_average_age();
                                        break;
                                    }
                                // Passagerare med högst ålder
                                case 4:
                                    {
                                        Max_age();
                                        break;
                                    }
                                // Sortera bussen efter ålder
                                case 5:
                                    {
                                        Sort_buss();
                                        break;
                                    }
                                // Tillbaka till huvudmenyn
                                case 6:
                                    {
                                        Console.WriteLine("Tillbaka... \n" +
                                                            "============================");
                                        continue;
                                    }
                                default:
                                    {
                                        Console.WriteLine("Var god och välj något från menyn");
                                        break;
                                    }
                            }
                            break;
                        }
                    // Avsluta program
                    case 4:
                        {
                            Environment.Exit(0);
                            return;
                        }

                    default:
                        {
                            Console.WriteLine("Var god och välj något från menyn");
                            break;
                        }
                }
            }//
        }

        private void Add_passenger()
        {
            string nyNamn;
            int nyÅlder = 0;

            Console.Clear();
            Console.WriteLine("=== Lägg till passagerare ===");
            //Skapa ett namn till passagerare
            while (true)
            {
                Console.Write("Namn på passageraren: ");
                try
                {
                    nyNamn = Console.ReadLine();
                    break;  
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            // Ge en ålder till passagerare
            while (true)
            {
                try
                {     
                    Console.Write("Passagerarens ålder: ");
                    nyÅlder = Convert.ToInt32(Console.ReadLine());
                    if (nyÅlder > maxålderförpassagerare)
                    {
                        Console.WriteLine("Var god och ange ett mindre värde.");
                    }
                    else if (nyÅlder < 0)
                    { 
                        Console.WriteLine("Var god och ange ett högre värde.");
                    }
                    else
                    {
                        break;  
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Var god och ange en siffra.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            // Söka efter tomma platser att lägga den nya passageraren
            for (int i = 0; i < sittplatser.Length - 1; i++)
            {
                if (sittplatser[i] == null)
                {
                    sittplatser[i] = new Passagerare(nyNamn, nyÅlder);
                    break;
                }
                else
                {
                    continue;
                }
            }

            Console.WriteLine(); // To get some space
            Console.WriteLine("Den nya passageraren har stigit på bussen. \n" +
                                          "Tryck på en tangent för att fortsätta...");
        }

        private void Print_buss()
        {
            Console.Clear();
            Console.WriteLine("=== Nuvarande passagerare ===");
            int sittplatsnummer = 0;
            foreach (Passagerare person in sittplatser)
            {
                sittplatsnummer++;
                if (person == null)
                {
                    Console.WriteLine("Sittplats nummer {0}: Den här platsen är tom.", sittplatsnummer);
                }
                else
                {
                    Console.WriteLine("Sittplats nummer {0}: {1}, {2} år.", sittplatsnummer, person.Namn, person.Ålder);
                }
            }
            Console.WriteLine("============================\n" +
                              "Tryck på en tangent för att fortsätta...");
            Console.ReadKey(true);
        }

        private void Find_age()
        {
            Console.Clear();
            Console.WriteLine("=== Hitta passagerare ===");

            int hittaspecifikålder = 0;
            while (true)
            {
                Console.Write("Ange ett önskat ålder att hitta genom alla passagerare: ");
                try
                {
                    hittaspecifikålder = Convert.ToInt32(Console.ReadLine());
                    if (hittaspecifikålder > maxålderförpassagerare)
                    {
                        Console.WriteLine("Var god och ange ett mindre värde.");
                    }
                    else if (hittaspecifikålder < 0)
                    {
                        Console.WriteLine("Var god och ange ett större värde.");
                    }
                    else
                    {
                        break;  
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Var god och ange en siffra.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            
            int antalpassagerare = 0;
            foreach (Passagerare person in sittplatser)
            {
                if (person == null)
                {
                    continue;   // plats är tom
                }
                else if (person.Ålder == hittaspecifikålder)
                {
                    Console.WriteLine(person.Namn);
                    antalpassagerare++;
                }
                else
                {
                    continue;
                }
            }

            if (antalpassagerare == 0)
            {
                Console.WriteLine("\nHittade ingen person i den åldern.");
            }
            else
            {
                Console.WriteLine("\nDu fick {0} matchning(ar) på din sökning.", antalpassagerare);
            }

            Console.WriteLine("============================\n" +
                              "Tryck på en tangent för att fortsätta...");
            Console.ReadKey(true);
        }

        private void Calc_total_age()
        {
            Console.Clear();
            Console.WriteLine("=== Totala åldern ===");
            int Totalaålderallapassagerare = 0;
            foreach (Passagerare person in sittplatser)
            {
                if (person == null)
                {
                    continue;   // plats är tom
                }
                else
                {
                    Totalaålderallapassagerare += person.Ålder;
                }
            }
            Console.WriteLine("Den totala summan för allas ålder är {0} år.", Totalaålderallapassagerare);

            Console.WriteLine("============================\n" +
                                          "Tryck på en tangent för att fortsätta...");
            Console.ReadKey(true);
        }

        private void Calc_average_age()
        {
            Console.Clear();
            Console.WriteLine("=== Genomsnittliga åldern ===");
            int numberOfPassengers = 0;
            int totalAgeOfPassengers = 0;
            foreach (Passagerare person in sittplatser)
            {
                if (person == null)
                {
                    continue;   // plats är tom
                }
                else
                {
                    totalAgeOfPassengers += person.Ålder;
                    numberOfPassengers++;
                }
            }
            Console.WriteLine("Den genomsnittliga åldern för alla passagerare är {0} år.", totalAgeOfPassengers / numberOfPassengers);

            Console.WriteLine("============================\n" +
                              "Tryck på en tangent för att fortsätta...");
            Console.ReadKey(true);
        }

        private void Max_age()
        {
            // Defining dataa
            int äldst = 0;

            Console.Clear();
            Console.WriteLine("=== Passagerare med högst ålder ===");
            // Find oldest passenger
            foreach (Passagerare person in sittplatser)
            {
                if (person == null)
                {
                    continue;
                }
                else if (person.Ålder > äldst)
                {
                    äldst = person.Ålder;
                }
            }

            Console.WriteLine("Den äldsta passageraren i bussen är: ");
            foreach (Passagerare person in sittplatser)
            {
                if (person == null)
                {
                    continue;
                }
                else if (person.Ålder == äldst)
                {
                    Console.WriteLine("{0} som är {1} år", person.Namn, person.Ålder);
                }
            }

            Console.WriteLine("============================\n" +
                              "Tryck på en tangent för att fortsätta...");
            Console.ReadKey(true);
        }

        private void Sort_buss()
        {
            Console.Clear();
            Console.WriteLine("=== Sortera bussen efter ålder ===");

            List<Passagerare> temporärsorteringslista = new List<Passagerare>();

            // Lägger till alla passagerare i en temporär sorterings lista
            foreach (Passagerare person in sittplatser)
            {
                if (person == null)
                {
                    continue;
                }
                else
                {
                    temporärsorteringslista.Add(person);
                }
            }
            // Soretering i den temporära sorteringslistan
            for (int i = 0; i < temporärsorteringslista.Count; i++)
            {
                int currentIntex = i;
                for (int j = i + 1; j < temporärsorteringslista.Count; j++)
                {
                    if (temporärsorteringslista[j].Ålder < temporärsorteringslista[currentIntex].Ålder)
                    {
                        currentIntex = j;
                    }
                }
                if (currentIntex != i)
                {
                    Passagerare temporärvärde = temporärsorteringslista[i];
                    temporärsorteringslista[i] = temporärsorteringslista[currentIntex];
                    temporärsorteringslista[currentIntex] = temporärvärde;
                }
            }
            // tar bort alla passagerare från sittplatser
            Array.Clear(sittplatser, 0, sittplatser.Length - 1);
            // Lägger tillbaka passagerare, sorterade efter ålder
            for (int i = 0; i < temporärsorteringslista.Count; i++)
            {
                sittplatser[i] = (temporärsorteringslista[i]);
            }
            // Skriv ut passagerare i ordning
            int seatNumber = 0;
            foreach (Passagerare person in sittplatser)
            {
                seatNumber++;
                if (person == null)
                {
                    Console.WriteLine("Sittplats nummer {0}: Den här platsen är tom.", seatNumber);
                }
                else
                {
                    Console.WriteLine("Sittplats nummer {0}: {1}, {2} år.", seatNumber, person.Namn, person.Ålder);
                }
            }

            Console.WriteLine("============================\n" +
                              "Tryck på en tangent för att fortsätta...");
            Console.ReadKey(true);
        }


        class Passagerare
        {
            private string namn;
            private int ålder;


            public Passagerare(string _namn, int _ålder)
            {
                this.Namn = _namn;
                this.Ålder = _ålder;
            }


            public string Namn
            {
                get { return namn; }
                set { namn = value; }
            }

            public int Ålder
            {
                get { return ålder; }
                set { ålder = value; }
            }
        }
    }
}