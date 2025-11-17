using SQLite;

public class Term
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; } // e.g. "Term 1"
    public int YearId { get; set; }  // Link to Year
}
