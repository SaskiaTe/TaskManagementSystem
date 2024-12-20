using System.Runtime.InteropServices.JavaScript;

namespace TaskManagementSystem;

public class Task
{
    private String titel { get; set; }
    private String beschreibung  { get; set; }
    private DateOnly erstelldatum { get; set; }
    private int prioriteat  { get; set; }
    private int scheatzung { get; set; }
    private Status status { get; set; }
    private User autor { get; set; }
    
    public Task(string titel, string beschreibung, DateOnly erstelldatum, int prioriteat, int scheatzung, Status status, User autor)
    {
        this.titel = titel;
        this.beschreibung = beschreibung;
        this.erstelldatum = erstelldatum;
        this.prioriteat = prioriteat;
        this.scheatzung = scheatzung;
        this.status = status;
        this.autor = autor;
    }
    
    public void UpdateStatus(Status newStatus)
    {
        status = newStatus; 
    }

    public Status getStatus()
    {
        return status;
    }
    
    public virtual void displayTask()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=====================================");
        Console.WriteLine($"         Aufgabe: {titel}");
        Console.WriteLine("=====================================");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"Beschreibung: {beschreibung}");
        Console.WriteLine($"Erstellungsdatum: {erstelldatum.ToShortDateString()}");
        Console.WriteLine($"Priorität: {prioriteat}"); 
        Console.WriteLine($"Schätzung: {scheatzung} Stunden");
        Console.WriteLine($"Status: {status}");
        
        Console.WriteLine("=====================================");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Autor: {autor.getName()}");
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine("=====================================");    
    }
}