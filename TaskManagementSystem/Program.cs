namespace TaskManagementSystem
{
    class Program
    {
        static Tasklist tasklist = new Tasklist();
        static List<User> users = new List<User>();

        static void Main(string[] args)
        {
            while (true)
            {
                ShowMenu();
                int option = GetValidatedInt("Bitte eine Option wählen: ");

                switch (option)
                {
                    case 1:
                        AddTask();
                        break;
                    case 2:
                        DisplayAllTasks();
                        break;
                    case 3:
                        FilterTasks();
                        break;
                    case 4:
                        AddUser();
                        break;
                    case 5:
                        AssignTaskToUser();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Ungültige Option. Bitte erneut versuchen.");
                        break;
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("\nTask Management System Menu:");
            Console.WriteLine("1. Aufgabe hinzufügen");
            Console.WriteLine("2. Aufgabe anzeigen");
            Console.WriteLine("3. Aufgabe filtern");
            Console.WriteLine("4. Benutzer hinzufügen");
            Console.WriteLine("5. Aufgaben zu Benutzer zuweisen");
            Console.WriteLine("6. Beenden");
        }

        static int GetValidatedInt(string message)
        {
            int result;
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out result))
                    return result;
                Console.WriteLine("Bitte eine gültige Zahl eingeben.");
            }
        }

        static int GetValidatedStatus(string message)
        {
            int result;
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out result) && result >= 0 && result <= 4)
                    return result;
                Console.WriteLine("Bitte eine Zahl zwischen 0 und 4 eingeben.");
            }
        }

        static string GetValidatedString(string message)
        {
            string input;
            while (true)
            {
                Console.Write(message);
                input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input) && !input.Any(char.IsDigit))
                    return input;
                Console.WriteLine("Bitte geben Sie einen gültigen Text ohne Zahlen ein.");
            }
        }

        static void AddTask()
        {
            Console.WriteLine("Welche Art von Aufgabe möchten Sie hinzufügen? (1: BugTask, 2: FeatureTask)");
            int taskType = GetValidatedInt("Bitte wählen Sie 1 oder 2: ");

            string titel = GetValidatedString("Titel: ");
            string beschreibung = GetValidatedString("Beschreibung: ");
            int prioritaet = GetValidatedInt("Priorität (1-5): ");
            int schaetzung = GetValidatedInt("Schätzung (Stunden): ");
            int statusInt = GetValidatedStatus("Status (0: OFFEN, 1: INBEARBEITUNG, 2: ABGESCHLOSSEN, 3: WARTEND, 4: BLOKIERD): ");
            Status status = (Status)statusInt;

            string autorName = GetValidatedString("Benutzername für den Autor: ");
            User autor = new User(users.Count + 1, autorName);
            users.Add(autor);

            if (taskType == 1)
            {
                int schwierigkeit = GetValidatedInt("Schwierigkeit (1-10): ");
                BugTask newTask = new BugTask(titel, beschreibung, DateOnly.FromDateTime(DateTime.Now), prioritaet, schaetzung, status, autor, schwierigkeit);
                tasklist.addTask(newTask);
            }
            else if (taskType == 2)
            {
                int releaseDatum = GetValidatedInt("Release-Datum (JJJJMMTT): ");
                FeatureTask newTask = new FeatureTask(titel, beschreibung, DateOnly.FromDateTime(DateTime.Now), prioritaet, schaetzung, status, autor, releaseDatum);
                tasklist.addTask(newTask);
            }

            Console.WriteLine("Aufgabe erfolgreich hinzugefügt!");
        }

        static void DisplayAllTasks()
        {
            Console.WriteLine("Alle Aufgaben anzeigen:");
            foreach (var task in tasklist.getAllTasks())
            {
                task.displayTask();
            }
        }

        static void FilterTasks()
        {
            int statusInt = GetValidatedStatus("Status zum Filtern eingeben (0: OFFEN, 1: INBEARBEITUNG, 2: ABGESCHLOSSEN, 3: WARTEND, 4: BLOKIERD): ");
            Status filterStatus = (Status)statusInt;
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
        }

        static void AddUser()
        {
            string name = GetValidatedString("Benutzername: ");
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
        }

        static void AssignTaskToUser()
        {
            Console.WriteLine("Benutzer auswählen:");
            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {users[i].getName()}");
            }
            int userChoice = GetValidatedInt("Benutzerwahl: ") - 1;

            Console.WriteLine("Wählen Sie eine Aufgabe aus:");
            var tasks = tasklist.getAllTasks();
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i].getTitle()} {tasks[i].getStatus()}");
            }
            int taskChoice = GetValidatedInt("Aufgabenauswahl: ") - 1;

            users[userChoice].assignTasks(new List<Task> { tasks[taskChoice] });
            Console.WriteLine("Aufgabe erfolgreich zugewiesen!");
        }
    }
}
