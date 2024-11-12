namespace FamilyBible.api.Entities;

public class VerseModel
{
    public int Id { get; set; }
    public int Chapter { get; set; }
    public int Verse { get; set; }
    public string? Text { get; set; }
    public int Book { get; set; }
    public string? Version { get; set; }
    
}