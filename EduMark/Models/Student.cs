using SQLite;

public class Student
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string FullName { get; set; } = "";
    public int ClassId { get; set; }
}
