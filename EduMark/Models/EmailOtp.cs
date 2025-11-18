using SQLite;

public class EmailOtp
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Email { get; set; } = "";
    public string Otp { get; set; } = "";      // 8-digit OTP
    public DateTime Expiry { get; set; } // Expiration timestamp
}
