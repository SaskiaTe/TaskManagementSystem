namespace TaskManagementSystem;

public class BugTask : Task
{
    private int schwirigkeit { get; set; }

    public BugTask(string titel, string beschreibung, DateOnly erstelldatum, int prioriteat, int scheatzung, Status status, User autor, int schwirigkeit)
        : base(titel, beschreibung, erstelldatum, prioriteat, scheatzung, status, autor)
    {
        this.schwirigkeit = schwirigkeit;
    }

    public override void DisplayTask()
    {
        base.DisplayTask();
            
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Schwierigkeit: {schwirigkeit}");
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine("=====================================");
    }
}