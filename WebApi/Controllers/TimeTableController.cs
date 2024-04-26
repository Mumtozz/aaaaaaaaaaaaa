using Domain.DTOs.TimeTableDTO;
using Domain.Filter;
using Domain.Responses;
using Infrastructure.Services.TimeTableService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class TimeTableController
{
    private readonly ITimeTableService _TimeTableService;

    public TimeTableController(ITimeTableService TimeTableService)
    {
        _TimeTableService = TimeTableService;
    }

    [HttpGet("get-TimeTable")]
    public async Task<Response<List<GetTimeTableDTO>>> GetTimeTableAsynccc([FromQuery] TimeTableFilter filter)
    {
        return await _TimeTableService.GetTimeTablesAsync(filter);
    }
    [HttpGet("{TimeTableId:int}")]
    public async Task<Response<GetTimeTableDTO>> GetTimeTableByIdAsync(int timeTableDTO)
    {
        return await _TimeTableService.GetTimeTableByIdAsync(timeTableDTO);
    }
    
    [HttpPost("create-TimeTable")]
    public async Task<Response<string>> AddTimeTableAsync(AddTimeTableDTO timeTableDTO)
    {
        return await _TimeTableService.CreateTimeTableAsync(timeTableDTO);
    }
    
    [HttpPut("update-TimeTable")]
    public async Task<Response<string>> UpdateTimeTableAsync(UpdateTimeTableDTO timeTableDTO)
    {
        return await _TimeTableService.UpdateTimeTableAsync(timeTableDTO);
    }
    
    [HttpDelete("{TimeTableId:int}")]
    public async Task<Response<bool>> DeleteStudentAsync(int TimeTableId)
    {
        return await _TimeTableService.DeleteTimeTableAsync(TimeTableId);
    }
 
}
