using SQLite;

public class Mark
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public int StudentId { get; set; }
    public string Subject { get; set; } = "";
    public double Score { get; set; }
    public double Weight { get; set; } // % of total
    public int TermId { get; set; }
}
