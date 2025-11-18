using SQLite;

public class Year
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; } = ""; // e.g. "2025"
}
