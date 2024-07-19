using Smart_City_Portal_WEB_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Smart_City_Portal_WEB_API.Models;
using Smart_City_Portal_WEB_API.Models.DTOs;

namespace Smart_City_Portal_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CMSwebapiController : ControllerBase
    {
        private readonly SmartCityPortalContext _context;

        public CMSwebapiController(SmartCityPortalContext context)
        {
            _context = context;
        }

        public class ApiResponse
        {
            public object Result { get; set; }
            public string Message { get; set; }
        }

        // Users

        [HttpGet("users")]
        public async Task<ActionResult<ApiResponse>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(new ApiResponse { Message = "Users retrieved successfully", Result = users });
        }

        [HttpGet("users/{id}")]
        public async Task<ActionResult<ApiResponse>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new ApiResponse { Message = "User not found", Result = null });
            }
            return Ok(new ApiResponse { Message = "User retrieved successfully", Result = user });
        }

        [HttpPost("users")]
        public async Task<ActionResult<ApiResponse>> CreateUser([FromBody] UserDto userDto)
        {
            var user = new User
            {
                Username = userDto.Username,
                PasswordHash = userDto.PasswordHash,
                Email = userDto.Email,
                LastLoginTime = userDto.LastLoginTime,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, new ApiResponse { Message = "User created successfully", Result = user });
        }

        [HttpPut("users/{id}")]
        public async Task<ActionResult<ApiResponse>> UpdateUser(int id, [FromBody] UserDto userDto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new ApiResponse { Message = "User not found", Result = null });
            }

            user.Username = userDto.Username ?? user.Username;
            user.PasswordHash = userDto.PasswordHash ?? user.PasswordHash;
            user.Email = userDto.Email ?? user.Email;
            user.LastLoginTime = userDto.LastLoginTime ?? user.LastLoginTime;
            user.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return Ok(new ApiResponse { Message = "User updated successfully", Result = user });
        }

        [HttpDelete("users/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new ApiResponse { Message = "User not found", Result = null });
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(new ApiResponse { Message = "User deleted successfully", Result = user });
        }

        // PublicTransportSchedules

        [HttpGet("publictransportschedules")]
        public async Task<ActionResult<ApiResponse>> GetPublicTransportSchedules()
        {
            var schedules = await _context.PublicTransportSchedules.ToListAsync();
            return Ok(new ApiResponse { Message = "Public Transport Schedules retrieved successfully", Result = schedules });
        }

        [HttpGet("publictransportschedules/{id}")]
        public async Task<ActionResult<ApiResponse>> GetPublicTransportSchedule(int id)
        {
            var schedule = await _context.PublicTransportSchedules.FindAsync(id);
            if (schedule == null)
            {
                return NotFound(new ApiResponse { Message = "Public Transport Schedule not found", Result = null });
            }
            return Ok(new ApiResponse { Message = "Public Transport Schedule retrieved successfully", Result = schedule });
        }

        [HttpPost("publictransportschedules")]
        public async Task<ActionResult<ApiResponse>> CreatePublicTransportSchedule([FromBody] PublicTransportScheduleDto scheduleDto)
        {
            var schedule = new PublicTransportSchedule
            {
                StartTime = scheduleDto.StartTime,
                EndTime = scheduleDto.EndTime,
                Frequency = scheduleDto.Frequency
            };

            _context.PublicTransportSchedules.Add(schedule);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPublicTransportSchedule), new { id = schedule.Id }, new ApiResponse { Message = "Public Transport Schedule created successfully", Result = schedule });
        }

        [HttpPut("publictransportschedules/{id}")]
        public async Task<ActionResult<ApiResponse>> UpdatePublicTransportSchedule(int id, [FromBody] PublicTransportScheduleDto scheduleDto)
        {
            var schedule = await _context.PublicTransportSchedules.FindAsync(id);
            if (schedule == null)
            {
                return NotFound(new ApiResponse { Message = "Public Transport Schedule not found", Result = null });
            }

            schedule.StartTime = scheduleDto.StartTime;
            schedule.EndTime = scheduleDto.EndTime;
            schedule.Frequency = scheduleDto.Frequency;

            await _context.SaveChangesAsync();

            return Ok(new ApiResponse { Message = "Public Transport Schedule updated successfully", Result = schedule });
        }

        [HttpDelete("publictransportschedules/{id}")]
        public async Task<ActionResult<ApiResponse>> DeletePublicTransportSchedule(int id)
        {
            var schedule = await _context.PublicTransportSchedules.FindAsync(id);
            if (schedule == null)
            {
                return NotFound(new ApiResponse { Message = "Public Transport Schedule not found", Result = null });
            }

            _context.PublicTransportSchedules.Remove(schedule);
            await _context.SaveChangesAsync();

            return Ok(new ApiResponse { Message = "Public Transport Schedule deleted successfully", Result = schedule });
        }

        // MetroSchedules

        [HttpGet("metroschedules")]
        public async Task<ActionResult<ApiResponse>> GetMetroSchedules()
        {
            var schedules = await _context.MetroSchedules.ToListAsync();
            return Ok(new ApiResponse { Message = "Metro Schedules retrieved successfully", Result = schedules });
        }

        [HttpGet("metroschedules/{id}")]
        public async Task<ActionResult<ApiResponse>> GetMetroSchedule(int id)
        {
            var schedule = await _context.MetroSchedules.FindAsync(id);
            if (schedule == null)
            {
                return NotFound(new ApiResponse { Message = "Metro Schedule not found", Result = null });
            }
            return Ok(new ApiResponse { Message = "Metro Schedule retrieved successfully", Result = schedule });
        }

        [HttpPost("metroschedules")]
        public async Task<ActionResult<ApiResponse>> CreateMetroSchedule([FromBody] MetroScheduleDto scheduleDto)
        {
            var schedule = new MetroSchedule
            {
                StartTime = scheduleDto.StartTime,
                EndTime = scheduleDto.EndTime,
                Frequency = scheduleDto.Frequency
            };

            _context.MetroSchedules.Add(schedule);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMetroSchedule), new { id = schedule.Id }, new ApiResponse { Message = "Metro Schedule created successfully", Result = schedule });
        }

        [HttpPut("metroschedules/{id}")]
        public async Task<ActionResult<ApiResponse>> UpdateMetroSchedule(int id, [FromBody] MetroScheduleDto scheduleDto)
        {
            var schedule = await _context.MetroSchedules.FindAsync(id);
            if (schedule == null)
            {
                return NotFound(new ApiResponse { Message = "Metro Schedule not found", Result = null });
            }

            schedule.StartTime = scheduleDto.StartTime;
            schedule.EndTime = scheduleDto.EndTime;
            schedule.Frequency = scheduleDto.Frequency;

            await _context.SaveChangesAsync();

            return Ok(new ApiResponse { Message = "Metro Schedule updated successfully", Result = schedule });
        }

        [HttpDelete("metroschedules/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteMetroSchedule(int id)
        {
            var schedule = await _context.MetroSchedules.FindAsync(id);
            if (schedule == null)
            {
                return NotFound(new ApiResponse { Message = "Metro Schedule not found", Result = null });
            }

            _context.MetroSchedules.Remove(schedule);
            await _context.SaveChangesAsync();

            return Ok(new ApiResponse { Message = "Metro Schedule deleted successfully", Result = schedule });
        }
    }
}
