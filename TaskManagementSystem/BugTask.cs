namespace TaskManagementSystem;

public class BugTask : Task
{
    private int schwirigkeit { get; set; }

    public BugTask(string titel, string beschreibung, DateOnly erstelldatum, int prioriteat, int scheatzung, Status status, User autor, int schwirigkeit)
        : base(titel, beschreibung, erstelldatum, prioriteat, scheatzung, status, autor)
    {
        this.schwirigkeit = schwirigkeit;
    }

    public override void displayTask()
    {
        base.displayTask();
            
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Schwierigkeit: {schwirigkeit}");
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine("=====================================");
    }
}