namespace TaskManagementSystem;

public class FeatureTask : Task
{
    private int releaseDatum { get; set; }

    public FeatureTask(string titel, string beschreibung, DateOnly erstelldatum, int prioriteat, int scheatzung, Status status, User autor, int releaseDatum)
        : base(titel, beschreibung, erstelldatum, prioriteat, scheatzung, status, autor)
    {
        this.releaseDatum = releaseDatum;
    }

    public override void DisplayTask()
    {
        base.DisplayTask();
            
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"ReleaseDatum: {releaseDatum}");
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine("=====================================");
    }
}