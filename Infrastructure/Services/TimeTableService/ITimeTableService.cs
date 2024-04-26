using Domain.DTOs.TimeTableDTO;
using Domain.Filter;
using Domain.Responses;

namespace Infrastructure.Services.TimeTableService;

public interface ITimeTableService
{
    
    Task<PagedResponse<List<GetTimeTableDTO>>> GetTimeTablesAsync(TimeTableFilter filter);
    Task<Response<GetTimeTableDTO>> GetTimeTableByIdAsync(int id);
    Task<Response<string>> CreateTimeTableAsync(AddTimeTableDTO timeTable);
    Task<Response<string>> UpdateTimeTableAsync(UpdateTimeTableDTO timeTable);
    Task<Response<bool>> DeleteTimeTableAsync(int id);
}


