using System;
namespace Tickets
{
    struct Tickets
    {
        public string title;
        public string available;
        public int id;
        public double price;
        public string type;
        public string duration;
        public string status;

        public Tickets(string title, string available, int id, double price, string type, string duration, string status)
        {
            this.title = title;
            this.available = available;
            this.id = id;
            this.price = price;
            this.type = type;
            this.duration = duration;
            this.status = status;
        }

        public void SetCatalog(string title, string duration)
        {
            this.title = title;
            this.duration = duration;
        }
        public void SetId()
        {
            Random rand = new Random();
            this.id = rand.Next(10000);
        }
        public int GetId()
        {
            return this.id;
        }
        public void SetType(string type)
        {
            this.type = type;
        }

        public string GetType()
        {
            return this.type;
        }
        public void SetStatus(string status)
        {
            if (status.ToLower() == "y")
            {
                this.status = "Filled";
            }
            else
            {
                this.status = "Vacant";
            }
        }
        public string GetStatus()
        {
            return this.status;
        }
        public double GetPrice()
        {
            double FullPrice = 27.59;
            double AdjustedPrice;
            if (this.type.ToLower() == "student")
            {
                AdjustedPrice = Math.Round(FullPrice * 0.5, 2);
            }
            else if (this.type.ToLower() == "senior")
            {
                AdjustedPrice = Math.Round(FullPrice * 0.3, 2);
            }
            else
            {
                AdjustedPrice = FullPrice;
            }
            this.price = AdjustedPrice;
            return this.price;
        }
        public void GetCatalog()
        {
            Console.WriteLine("TITLE: " + this.title);
            Console.WriteLine("DURATION: " + this.duration);
            Console.WriteLine("PRICE: $" + GetPrice());
        }
        public void GetConfirmation()
        {
            Console.WriteLine("ID: " + this.id);
            Console.WriteLine("TITLE: " + this.title);
            Console.WriteLine("Duration: " + this.duration);
            Console.WriteLine("TYPE: " + this.type);
            Console.WriteLine("PRICE: $" + GetPrice());
        }
        //Rando ID
        //Title
        //Availible
        //duration


        //STEPS
        //Print 3 Movies with duration, price, remaining

        //Ask if theyd like to purchase
        //if yes, remaining - 1
        //ask type of ticket (Student, Adult or Senior)
        //Print Ticket info (Id, Movie, Duration, Type, Price)
        //Get Confirmation
        //if n, remaining + 1

        //Print menu again with updated remaining tickets for each movie.
    }

    public class Program
    {
        static void CheckRemaining(int x)
        {
            Tickets[,] Details = new Tickets[10, 3];


        }
        static void Initialize()
        {
        }
        static void Main(string[] args)
        {

                int choice;
                string MovieChoice, Duration;
                Tickets[,] Details = new Tickets[10, 3];
                Tickets[] movies = new Tickets[3];
            while (true)
            {
                int k = 0;
                int[] Remaining = { 1, 10, 10 };
                movies[0].SetCatalog("Avengers", "143 Minutes");
                movies[1].SetCatalog("Iron Man", "126 Minutes");
                movies[2].SetCatalog("SpiderMan", "121 Minutes");

                foreach (Tickets i in movies)
                {
                    i.SetType("Adult");
                    i.GetCatalog();
                    for (int j = 0; j < Details.GetLength(0); j++)
                    {
                        if (Details[j, k].GetStatus() == "Filled")
                        {
                            Remaining[k]--;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (Remaining[k] > 0)
                    {
                        Console.WriteLine("AVAILABLE: " + Remaining[k] + "\n");
                    }
                    else
                    {
                        Console.WriteLine("SOLD OUT\n");
                    }

                    k++;
                }
                //change
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("---------------------------");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("Which Movie would you like?");
                Console.WriteLine("Please Type 1, 2, or 3");
                choice = int.Parse(Console.ReadLine()) - 1;
                if (Remaining[choice] > 0)
                {
                    if (choice == 0)
                    {
                        MovieChoice = "Avengers";
                        Duration = "143 Minutes";
                    }
                    else if (choice == 1)
                    {
                        MovieChoice = "Iron Man";
                        Duration = "126 Minutes";
                    }
                    else
                    {
                        MovieChoice = "Spiderman";
                        Duration = "121 Minutes";
                    }
                    for (int i = 0; i < Details.GetLength(0); i++)
                    {
                        if (Details[i, choice].GetStatus() != "Filled")
                        {
                            Console.WriteLine("Are you a Student, Senior, or Adult?");
                            Details[i, choice].SetType(Console.ReadLine());
                            Details[i, choice].SetId();
                            Details[i, choice].SetCatalog(MovieChoice, Duration);

                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Type Y or N to confirm your ticket");
                            Console.ForegroundColor = ConsoleColor.White;
                            Details[i, choice].GetConfirmation();
                            Details[i, choice].SetStatus(Console.ReadLine());
                            Console.Clear();
                            if (Details[i, choice].GetStatus() == "Filled")
                            {
                                Console.WriteLine("Thank you for your purchase!");
                            }
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    }
                }
                else {
                    Console.Clear();
                    Console.ForegroundColor= ConsoleColor.DarkRed;
                    Console.WriteLine("Movie is sold out, Press enter to try again");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    Console.Clear();
                        }
            }
        }
    }
}