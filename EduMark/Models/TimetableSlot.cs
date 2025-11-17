using SQLite;

public class TimetableSlot
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public int TeacherId { get; set; }   // Link to Teacher
    public int ClassId { get; set; }     // Link to Class
    public string DayOfWeek { get; set; } // e.g. "Monday"
    public string StartTime { get; set; } // e.g. "08:00"
    public string EndTime { get; set; }   // e.g. "09:00"
}
