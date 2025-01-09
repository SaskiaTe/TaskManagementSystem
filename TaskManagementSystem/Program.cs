namespace TaskManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Tasklist tasklist = new Tasklist();
            List<User> users = new List<User>();

            while (true)
            {
                Console.WriteLine("\nTask Management System Menu:");
                Console.WriteLine("1. Aufgabe hinzufügen");
                Console.WriteLine("2. Aufgabe anzeigen");
                Console.WriteLine("3. Aufgabe filtern");
                Console.WriteLine("4. Benutzer hinzufügen");
                Console.WriteLine("5. Aufgaben zu Benutzer zuweisen");
                Console.WriteLine("6. Beenden");
                Console.Write("Bitte eine Option wählen: ");

                int option;
                if (int.TryParse(Console.ReadLine(), out option))
                {
                    switch (option)
                    {
                        case 1:
                            Console.Write("Titel: ");
                            string titel = Console.ReadLine();
                            Console.Write("Beschreibung: ");
                            string beschreibung = Console.ReadLine();
                            Console.Write("Priorität (1-5): ");
                            int prioritaet = int.Parse(Console.ReadLine());
                            Console.Write("Schätzung (Stunden): ");
                            int schaetzung = int.Parse(Console.ReadLine());
                            Console.Write("Status (0: OFFEN, 1: INBEARBEITUNG, 2: ABGESCHLOSSEN, 3: WARTEND, 4: BLOKIERD): ");
                            Status status = (Status)int.Parse(Console.ReadLine());

                            Console.Write("Benutzername für den Autor: ");
                            string autorName = Console.ReadLine();
                            User autor = new User(users.Count + 1, autorName);

                            Task newTask = new Task(titel, beschreibung, DateOnly.FromDateTime(DateTime.Now), prioritaet, schaetzung, status, autor);
                            tasklist.addTask(newTask);
                            Console.WriteLine("Aufgabe erfolgreich hinzugefügt!");
                            break;

                        case 2:
                            Console.WriteLine("Alle Aufgaben anzeigen:");
                            foreach (var task in tasklist.getAllTasks())
                            {
                                task.displayTask();
                            }
                            break;

                        case 3:
                            Console.Write("Status zum Filtern eingeben (0: OFFEN, 1: INBEARBEITUNG, 2: ABGESCHLOSSEN, 3: WARTEND, 4: BLOKIERD): ");
                            Status filterStatus = (Status)int.Parse(Console.ReadLine());
                            var filteredTasks = tasklist.filterTasks(filterStatus);

                            if (filteredTasks.Count == 0)
                            {
                                Console.WriteLine("Keine Aufgaben gefunden mit diesem Status.");
                            }
                            else
                            {
                                Console.WriteLine("Gefilterte Aufgaben:");
                                foreach (var task in filteredTasks)
                                {
                                    task.displayTask();
                                }
                            }
                            break;

                        case 4:
                            Console.Write("Benutzername: ");
                            string name = Console.ReadLine();
                            bool nameExists = users.Any(user => user.getName().Equals(name, StringComparison.OrdinalIgnoreCase));
                            if (nameExists)
                            {
                                Console.WriteLine("Der Benutzername existiert bereits. Bitte wählen Sie einen anderen Namen.");
                            }
                            else
                            {
                                User newUser = new User(users.Count + 1, name);
                                users.Add(newUser);
                                Console.WriteLine("Benutzer erfolgreich hinzugefügt!");
                            }
                            break;

                        case 5:
                            Console.WriteLine("Benutzer auswählen:");
                            for (int i = 0; i < users.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {users[i].getName()}");
                            }
                            int userChoice = int.Parse(Console.ReadLine()) - 1;

                            Console.WriteLine("Wählen Sie eine Aufgabe aus:");
                            var tasks = tasklist.getAllTasks();
                            for (int i = 0; i < tasks.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {tasks[i].getTitle()} {tasks[i].getStatus()}");
                            }
                            int taskChoice = int.Parse(Console.ReadLine()) - 1;

                            users[userChoice].assignTasks(new List<Task> { tasks[taskChoice] });
                            Console.WriteLine("Aufgabe erfolgreich zugewiesen!");
                            break;

                        case 6:
                            return;

                        default:
                            Console.WriteLine("Ungültige Option. Bitte erneut versuchen.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Bitte eine gültige Zahl eingeben.");
                }
            }
        }
    }
}
