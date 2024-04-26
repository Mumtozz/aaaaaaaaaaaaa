using Domain.Enums;

namespace Domain.Entities;

public class TimeTable
{

    public int Id { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public TimeSpan FromTime { get; set; }
    public TimeSpan ToTime { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public int GroupId { get; set; }
    public virtual Group? Group { get; set; }
    public TimeTableType TimeTableType { get; set; }
    
}
