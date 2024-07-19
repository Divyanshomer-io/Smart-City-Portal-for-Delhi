using Smart_City_Portal_WEB_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
    }
}
