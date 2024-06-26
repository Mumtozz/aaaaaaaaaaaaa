using Domain.Enums;

namespace Domain.DTOs.TimeTableDTO;

public class AddTimeTableDTO
{
    
    public DayOfWeek DayOfWeek { get; set; }
    public TimeSpan FromTime { get; set; } 
    public TimeSpan ToTime { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public int GroupId { get; set; }
    public TimeTableType TimeTableType { get; set; }
}
