using SQLite;

public class Teacher
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string FullName { get; set; } = "";
    public string Email { get; set; } = "";
    public string PasswordHash { get; set; } = "";
    public bool IsVerified { get; set; } = false;
    public string ProfilePicturePath { get; set; } = "";
}
