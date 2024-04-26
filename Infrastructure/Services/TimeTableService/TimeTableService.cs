using System.Data.Common;
using AutoMapper;
using Domain.DTOs.TimeTableDTO;
using Domain.Entities;
using Domain.Filter;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.TimeTableService;

public class TimeTableService(DataContext _context, IMapper _mapper) : ITimeTableService
{

    public async Task<Response<string>> CreateTimeTableAsync(AddTimeTableDTO timeTable)
    {
        try
        {

            var mapped = _mapper.Map<TimeTable>(timeTable.ToTime);
            await _context.TimeTables.AddAsync(mapped);
            await _context.SaveChangesAsync();
            return new Response<string>(System.Net.HttpStatusCode.Accepted, "Success");
        }
        catch (System.Exception e)
        {

           
           return new Response<string>(System.Net.HttpStatusCode.InternalServerError,e.Message);
        }
        
    }

    public Task<Response<bool>> DeleteTimeTableAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<GetTimeTableDTO>> GetTimeTableByIdAsync(int id)
    {
        try
        {
            var time = await _context.TimeTables.FirstOrDefaultAsync(x => x.Id == id);
            if (time == null)
                return new Response<GetTimeTableDTO>(System.Net.HttpStatusCode.BadRequest, "TimeTable not found");
            var mapped = _mapper.Map<GetTimeTableDTO>(time);
            return new Response<GetTimeTableDTO>(mapped);
        }
        catch (Exception e)
        {
            return new Response<GetTimeTableDTO>(System.Net.HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<PagedResponse<List<GetTimeTableDTO>>> GetTimeTablesAsync(TimeTableFilter filter)
    {
          try
        {
            var time = _context.TimeTables.AsQueryable();
            if (!string.IsNullOrEmpty(filter.DayOfWeek))
            time =time.Where(e => e.DayOfWeek.ToString().Contains(filter.DayOfWeek));
                if(filter.TimeTableType!=null)
                time = time.Where(e => e.TimeTableType == filter.TimeTableType);
            
            var response = await time
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize).ToListAsync();
            var totalRecord = time.Count();

            var mapped = _mapper.Map<List<GetTimeTableDTO>>(response);
            return new PagedResponse<List<GetTimeTableDTO>>(mapped, filter.PageNumber, filter.PageSize, totalRecord);

        }
        catch (DbException dbEx)
        {
            return new PagedResponse<List<GetTimeTableDTO>>(System.Net.HttpStatusCode.InternalServerError, dbEx.Message);
        }
        catch (Exception ex)
        {
            return new PagedResponse<List<GetTimeTableDTO>>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
       
    }

    public async Task<Response<string>> UpdateTimeTableAsync(UpdateTimeTableDTO timeTable)
    {
        try
        {
            var mappedtimeTable = _mapper.Map<TimeTable>(timeTable);
            _context.TimeTables.Update(mappedtimeTable);
            var update = await _context.SaveChangesAsync();
            if (update == 0) return new Response<string>(System.Net.HttpStatusCode.BadRequest, "timeTable not found");
            return new Response<string>("timeTable updated successfully");
        }
        catch (Exception e)
        {
            return new Response<string>(System.Net.HttpStatusCode.InternalServerError, e.Message);
        }
    }

}
