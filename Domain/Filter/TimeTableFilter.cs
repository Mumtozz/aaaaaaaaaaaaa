using Domain.Enums;

namespace Domain.Filter;

public class TimeTableFilter : PaginationFilter
{

    public string? DayOfWeek { get; set; }
    public TimeTableType TimeTableType { get; set; }

}
