namespace FamilyBible.api.Entities;

public class ImportVerseModel
{
    public string abbrev { get; set; }
    public List<List<string>> chapters { get; set; }
}