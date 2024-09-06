using Demo01.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey key;
            do
            {
                Console.Clear();
                Console.WriteLine("Bienvenue dans le gestionnaire d'application");
                Console.WriteLine("Que souhaitez-vous faire ?");
                Console.WriteLine("(C)onsulter - (A)jouter - (Q)uitter");
                key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.A:
                        AddSoft();
                        break;
                    case ConsoleKey.C:
                        ShowSoft();
                        break;
                }
            } while (key != ConsoleKey.Q);
            Console.WriteLine("Au revoir!");
        }

        private static void ShowSoft()
        {
            ConsoleKey key;
            do
            {
                Console.Clear();
                Console.WriteLine("Que voulez-vous afficher ?");
                Console.WriteLine("(J)eux - (A)pplications - Avec (I)dentifiant - (R)evenir en arrière");
                key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.J:
                        IEnumerable<Game> games;
                        using (DataContext dataContext = new DataContext())
                        {
                            games = dataContext
                                .Softs
                                .OfType<Game>()
                                .Include(g => g.ServerDetails);
                            foreach (Game jeu in games)
                            {
                                Console.Write($"{jeu.Id} | {jeu.Name} | {((jeu.Description.Length > 20) ? jeu.Description.Substring(0, 20) : jeu.Description)} | {jeu.PegiClassification}");
                                if(jeu.ServerDetails is not null)
                                {
                                    Console.Write($" | {jeu.ServerDetails.IpAddress}");
                                }
                                Console.WriteLine();
                            }
                        }
                        break;
                    case ConsoleKey.A:
                        IEnumerable<Application> apps;
                        using (DataContext dataContext = new DataContext())
                        {
                            apps = dataContext
                                .Softs
                                .OfType<Application>()
                                .Include(g => g.ServerDetails);
                            foreach (Application app in apps)
                            {
                                Console.Write($"{app.Id} | {app.Name} | {((app.Description.Length > 20) ? app.Description.Substring(0, 20) : app.Description)} | {((app.IsMobile) ? "Mobile" : "Desktop")}"); 
                                if (app.ServerDetails is not null)
                                {
                                    Console.Write($" | {app.ServerDetails.IpAddress}");
                                }
                                Console.WriteLine();
                            }
                        }
                        break;
                    case ConsoleKey.I:
                        Software? software;
                        Console.WriteLine("Quel identifiant voulez-vous consulter ?");
                        int id = int.Parse(Console.ReadLine());
                        using (DataContext dataContext = new DataContext())
                        {
                            software = dataContext.Softs.SingleOrDefault(s => s.Id == id);
                            switch (software)
                            {
                                case Game jeu:
                                    Console.WriteLine($"{jeu.Id} | {jeu.Name} | {((jeu.Description.Length > 20) ? jeu.Description.Substring(0, 20) : jeu.Description)} | {jeu.PegiClassification}");
                                    Console.WriteLine("Que voulez-vous faire ?");
                                    Console.WriteLine("(M)ettre à jour - (S)upprimer - (R)evenir en arrière");
                                    switch(Console.ReadKey(true).Key)
                                    {
                                        case ConsoleKey.M:
                                            UpdateGame(jeu);
                                            dataContext.SaveChanges();
                                            break;
                                        case ConsoleKey.S:
                                            dataContext.Remove(jeu);
                                            dataContext.SaveChanges();
                                            break;
                                    }
                                    break;
                                case Application app:
                                    Console.WriteLine($"{app.Id} | {app.Name} | {((app.Description.Length > 20) ? app.Description.Substring(0, 20) : app.Description)} | {((app.IsMobile) ? "Mobile" : "Desktop")}");
                                    Console.WriteLine("Que voulez-vous faire ?");
                                    Console.WriteLine("(M)ettre à jour - (S)upprimer - (R)evenir en arrière");
                                    switch (Console.ReadKey(true).Key)
                                    {
                                        case ConsoleKey.M:
                                            UpdateApp(app);
                                            dataContext.SaveChanges();
                                            break;
                                        case ConsoleKey.S:
                                            dataContext.Remove(app);
                                            dataContext.SaveChanges();
                                            break;
                                    }
                                    break;
                                case null:
                                    Console.WriteLine($"Aucune correspondance pour l'id {id}...");
                                    break;
                            }
                        }
                        break;
                }
                Console.WriteLine("Appuyez sur une touche pour continuer...");
                Console.ReadKey(true);
            } while (key != ConsoleKey.R);
        }

        private static void UpdateApp(Application app)
        {
            ConsoleKey key;
            do
            {
                Console.Clear();
                Console.WriteLine("Que voulez-vous mettre à jour ?");
                Console.WriteLine($"(N)om : {app.Name}");
                Console.WriteLine($"(D)escription : {app.Description}");
                Console.WriteLine($"Est-ce (M)obile : {app.IsMobile}");
                Console.WriteLine($"(R)evenir en arrière");
                key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.N:
                        Console.WriteLine("Veuillez indiquer le nouveau nom :");
                        app.Name = Console.ReadLine();
                        break;
                    case ConsoleKey.D:
                        Console.WriteLine("Veuillez indiquer la nouvelle description :");
                        app.Description = Console.ReadLine();
                        break;
                    case ConsoleKey.M:
                        Console.WriteLine("Changement du mode mobile");
                        app.IsMobile = !app.IsMobile;
                        break;
                }
            } while (key != ConsoleKey.R);
        }

        private static void UpdateGame(Game jeu)
        {
            ConsoleKey key;
            do
            {
                Console.Clear();
                Console.WriteLine("Que voulez-vous mettre à jour ?");
                Console.WriteLine($"(N)om : {jeu.Name}");
                Console.WriteLine($"(D)escription : {jeu.Description}");
                Console.WriteLine($"Classification (P)egi : {jeu.PegiClassification}");
                Console.WriteLine($"(R)evenir en arrière");
                key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.N:
                        Console.WriteLine("Veuillez indiquer le nouveau nom :");
                        jeu.Name = Console.ReadLine();
                        break;
                    case ConsoleKey.D:
                        Console.WriteLine("Veuillez indiquer la nouvelle description :");
                        jeu.Description = Console.ReadLine();
                        break;
                    case ConsoleKey.P:
                        Console.WriteLine("Veuillez indiquer la nouvelle classification Pegi :");
                        Console.WriteLine("(3) ans ou plus - (7) ans ou plus - 1(6) ans ou plus - 1(8) ans ou plus - (N)on défini");
                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.NumPad3:
                            case ConsoleKey.D3:
                                jeu.PegiClassification = "+3";
                                break;
                            case ConsoleKey.NumPad7:
                            case ConsoleKey.D7:
                                jeu.PegiClassification = "+7";
                                break;
                            case ConsoleKey.NumPad6:
                            case ConsoleKey.D6:
                                jeu.PegiClassification = "+16";
                                break;
                            case ConsoleKey.NumPad8:
                            case ConsoleKey.D8:
                                jeu.PegiClassification = "+18";
                                break;
                            default:
                                jeu.PegiClassification = "NaN";
                                break;
                        }
                        break;
                }
            } while (key != ConsoleKey.R);
        }

        private static void AddSoft()
        {
            ConsoleKey key;
            do
            {
                Console.Clear();
                Console.WriteLine("Que voulez-vous ajouter ?");
                Console.WriteLine("(J)eu - (A)pplication - (R)evenir en arrière");
                key = Console.ReadKey(true).Key;
                int year, month, day;
                switch (key)
                {
                    case ConsoleKey.J:
                        Game jeu = new Game();
                        Console.WriteLine("Quel est le nom du jeu :");
                        jeu.Name = Console.ReadLine();
                        Console.WriteLine("Le jeu consiste a :");
                        jeu.Description = Console.ReadLine();
                        Console.WriteLine("Est-ce un jeu online :");
                        Console.WriteLine("(O)ui - (N)on");
                        jeu.IsOnline = Console.ReadKey(true).Key == ConsoleKey.O;
                        Console.WriteLine("Est-ce un jeu multijoueur à écran partagé :");
                        Console.WriteLine("(O)ui - (N)on");
                        jeu.IsSplitScreen = Console.ReadKey(true).Key == ConsoleKey.O;
                        Console.WriteLine("Pour quel public ce jeu est-il destiné : ");
                        Console.WriteLine("(3) ans ou plus - (7) ans ou plus - 1(6) ans ou plus - 1(8) ans ou plus - (N)on défini");
                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.NumPad3:
                            case ConsoleKey.D3:
                                jeu.PegiClassification = "+3";
                                break;
                            case ConsoleKey.NumPad7:
                            case ConsoleKey.D7:
                                jeu.PegiClassification = "+7";
                                break;
                            case ConsoleKey.NumPad6:
                            case ConsoleKey.D6:
                                jeu.PegiClassification = "+16";
                                break;
                            case ConsoleKey.NumPad8:
                            case ConsoleKey.D8:
                                jeu.PegiClassification = "+18";
                                break;
                            default:
                                jeu.PegiClassification = "NaN";
                                break;
                        }
                        Console.WriteLine("Quelle est la date de sortie ?");
                        Console.WriteLine("L'année:");
                        year = int.Parse(Console.ReadLine());
                        Console.WriteLine("Le mois:");
                        month = int.Parse(Console.ReadLine());
                        Console.WriteLine("Le jour:");
                        day = int.Parse(Console.ReadLine());
                        jeu.ReleaseDate = new DateTime(year, month, day);

                        //Appel de la base de donnée pour sauvegarder notre jeu
                        using (DataContext dataContext = new DataContext())
                        {
                            dataContext.Softs.Add(jeu);
                            dataContext.SaveChanges();
                        }
                        break;
                    case ConsoleKey.A:
                        Application app = new Application();
                        Console.WriteLine("Quel est le nom de l'application :");
                        app.Name = Console.ReadLine();
                        Console.WriteLine("L'application consiste a :");
                        app.Description = Console.ReadLine();
                        Console.WriteLine("Est-ce une application connectée :");
                        Console.WriteLine("(O)ui - (N)on");
                        app.IsOnline = Console.ReadKey(true).Key == ConsoleKey.O;
                        Console.WriteLine("Est-ce une application multimédia :");
                        Console.WriteLine("(O)ui - (N)on");
                        app.IsMultimedia = Console.ReadKey(true).Key == ConsoleKey.O;
                        Console.WriteLine("Est-ce une application mobile :");
                        Console.WriteLine("(O)ui - (N)on");
                        app.IsMobile = Console.ReadKey(true).Key == ConsoleKey.O;
                        Console.WriteLine("Quelle est la date de sortie ?");
                        Console.WriteLine("L'année:");
                        year = int.Parse(Console.ReadLine());
                        Console.WriteLine("Le mois:");
                        month = int.Parse(Console.ReadLine());
                        Console.WriteLine("Le jour:");
                        day = int.Parse(Console.ReadLine());
                        app.ReleaseDate = new DateTime(year, month, day);

                        //Appel de la base de donnée pour sauvegarder notre jeu
                        using (DataContext dataContext = new DataContext())
                        {
                            dataContext.Softs.Add(app);
                            dataContext.SaveChanges();
                        }
                        break;
                }
            } while (key != ConsoleKey.R);
        }
    }
}
