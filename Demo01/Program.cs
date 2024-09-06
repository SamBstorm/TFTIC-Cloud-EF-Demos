using Demo01.Entities;

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
                Console.WriteLine("(A)jouter - (Q)uitter"); 
                key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.A:
                        AddSoft();
                        break;
                }
            } while (key != ConsoleKey.Q);
            Console.WriteLine("Au revoir!");
        }

        static void AddSoft()
        {
            ConsoleKey key;
            do
            {
                Console.Clear();
                Console.WriteLine("Que voulez-vous ajouter ?");
                Console.WriteLine("(J)eux - (A)pplication - (R)evenir en arrière"); 
                key = Console.ReadKey().Key;
                int year, month, day;
                switch (key) {
                    case ConsoleKey.J:
                        Game jeu = new Game();
                        Console.WriteLine("Quel est le nom du jeu :");
                        jeu.Name = Console.ReadLine();
                        Console.WriteLine("Le jeu consiste a :");
                        jeu.Description = Console.ReadLine();
                        Console.WriteLine("Est-ce un jeu online :");
                        Console.WriteLine("(O)ui - (N)on");
                        jeu.IsOnline = Console.ReadKey().Key == ConsoleKey.O;
                        Console.WriteLine("Est-ce un jeu multijoueur à écran partagé :");
                        Console.WriteLine("(O)ui - (N)on");
                        jeu.IsSplitScreen = Console.ReadKey().Key == ConsoleKey.O;
                        Console.WriteLine("Pour quel public ce jeu est-il destiné : ");
                        Console.WriteLine("(3) ans ou plus - (7) ans ou plus - 1(6) ans ou plus - 1(8) ans ou plus - (N)on défini");
                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.NumPad3:
                                jeu.PegiClassification = "+3";
                                break;
                            case ConsoleKey.NumPad7:
                                jeu.PegiClassification = "+7";
                                break;
                            case ConsoleKey.NumPad6:
                                jeu.PegiClassification = "+16";
                                break;
                            case ConsoleKey.NumPad8:
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
                        using(DataContext dataContext = new DataContext())
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
                        app.IsOnline = Console.ReadKey().Key == ConsoleKey.O;
                        Console.WriteLine("Est-ce une application multimédia :");
                        Console.WriteLine("(O)ui - (N)on");
                        app.IsMultimedia = Console.ReadKey().Key == ConsoleKey.O;
                        Console.WriteLine("Est-ce une application mobile :");
                        Console.WriteLine("(O)ui - (N)on");
                        app.IsMobile = Console.ReadKey().Key == ConsoleKey.O;
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
