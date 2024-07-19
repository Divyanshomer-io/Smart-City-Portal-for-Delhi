using Smart_City_Portal_WEB_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Smart_City_Portal_WEB_API.Models.NewFolder5;

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
        public async Task<ActionResult<ApiResponse>> CreateUser(UsersDTO userDTO)
        {
            var user = new User
            {
                Username = userDTO.Username,
                Email = userDTO.Email,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                LastLoginTime = userDTO.LastLoginTime
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(new ApiResponse { Message = "User created successfully", Result = user });
        }

        [HttpPut("users/{id}")]
        public async Task<ActionResult<ApiResponse>> UpdateUser(int id, UsersDTO userDTO)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new ApiResponse { Message = "User not found", Result = null });
            }
            user.Username = userDTO.Username;
            user.Email = userDTO.Email;
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
        public async Task<ActionResult<ApiResponse>> CreatePublicTransportSchedule(PublicTransportScheduleDTO scheduleDTO)
        {
            var schedule = new PublicTransportSchedule
            {
                StartTime = scheduleDTO.StartTime,
                EndTime = scheduleDTO.EndTime,
                Frequency = scheduleDTO.Frequency
            };
            _context.PublicTransportSchedules.Add(schedule);
            await _context.SaveChangesAsync();
            return Ok(new ApiResponse { Message = "Public Transport Schedule created successfully", Result = schedule });
        }

        [HttpPut("publictransportschedules/{id}")]
        public async Task<ActionResult<ApiResponse>> UpdatePublicTransportSchedule(int id, PublicTransportScheduleDTO scheduleDTO)
        {
            var schedule = await _context.PublicTransportSchedules.FindAsync(id);
            if (schedule == null)
            {
                return NotFound(new ApiResponse { Message = "Public Transport Schedule not found", Result = null });
            }
            schedule.StartTime = scheduleDTO.StartTime;
            schedule.EndTime = scheduleDTO.EndTime;
            schedule.Frequency = scheduleDTO.Frequency;
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
        public async Task<ActionResult<ApiResponse>> CreateMetroSchedule(MetroScheduleDTO scheduleDTO)
        {
            var schedule = new MetroSchedule
            {
                StartTime = scheduleDTO.StartTime,
                EndTime = scheduleDTO.EndTime,
                Frequency = scheduleDTO.Frequency
            };
            _context.MetroSchedules.Add(schedule);
            await _context.SaveChangesAsync();
            return Ok(new ApiResponse { Message = "Metro Schedule created successfully", Result = schedule });
        }

        [HttpPut("metroschedules/{id}")]
        public async Task<ActionResult<ApiResponse>> UpdateMetroSchedule(int id, MetroScheduleDTO scheduleDTO)
        {
            var schedule = await _context.MetroSchedules.FindAsync(id);
            if (schedule == null)
            {
                return NotFound(new ApiResponse { Message = "Metro Schedule not found", Result = null });
            }
            schedule.StartTime = scheduleDTO.StartTime;
            schedule.EndTime = scheduleDTO.EndTime;
            schedule.Frequency = scheduleDTO.Frequency;
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

        // WeatherUpdates

        [HttpGet("weatherupdates")]
        public async Task<ActionResult<ApiResponse>> GetWeatherUpdates()
        {
            var updates = await _context.WeatherUpdates.ToListAsync();
            return Ok(new ApiResponse { Message = "Weather Updates retrieved successfully", Result = updates });
        }

        [HttpGet("weatherupdates/{id}")]
        public async Task<ActionResult<ApiResponse>> GetWeatherUpdate(int id)
        {
            var update = await _context.WeatherUpdates.FindAsync(id);
            if (update == null)
            {
                return NotFound(new ApiResponse { Message = "Weather Update not found", Result = null });
            }
            return Ok(new ApiResponse { Message = "Weather Update retrieved successfully", Result = update });
        }

        [HttpPost("weatherupdates")]
        public async Task<ActionResult<ApiResponse>> CreateWeatherUpdate(WeatherUpdateDTO updateDTO)
        {
            var update = new WeatherUpdate
            {
                Temperature = updateDTO.Temperature,
                Humidity = updateDTO.Humidity,
                WeatherDescription = updateDTO.WeatherDescription,
                Timestamp = updateDTO.Timestamp
            };
            _context.WeatherUpdates.Add(update);
            await _context.SaveChangesAsync();
            return Ok(new ApiResponse { Message = "Weather Update created successfully", Result = update });
        }

        [HttpPut("weatherupdates/{id}")]
        public async Task<ActionResult<ApiResponse>> UpdateWeatherUpdate(int id, WeatherUpdateDTO updateDTO)
        {
            var update = await _context.WeatherUpdates.FindAsync(id);
            if (update == null)
            {
                return NotFound(new ApiResponse { Message = "Weather Update not found", Result = null });
            }
            update.Temperature = updateDTO.Temperature;
            update.Humidity = updateDTO.Humidity;
            update.WeatherDescription = updateDTO.WeatherDescription;
            update.Timestamp = updateDTO.Timestamp;
            await _context.SaveChangesAsync();
            return Ok(new ApiResponse { Message = "Weather Update updated successfully", Result = update });
        }

        [HttpDelete("weatherupdates/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteWeatherUpdate(int id)
        {
            var update = await _context.WeatherUpdates.FindAsync(id);
            if (update == null)
            {
                return NotFound(new ApiResponse { Message = "Weather Update not found", Result = null });
            }
            _context.WeatherUpdates.Remove(update);
            await _context.SaveChangesAsync();
            return Ok(new ApiResponse { Message = "Weather Update deleted successfully", Result = update });
        }

        // EmergencyServices

        [HttpGet("emergencyservices")]
        public async Task<ActionResult<ApiResponse>> GetEmergencyServices()
        {
            var services = await _context.EmergencyServices.ToListAsync();
            return Ok(new ApiResponse { Message = "Emergency Services retrieved successfully", Result = services });
        }

        [HttpGet("emergencyservices/{id}")]
        public async Task<ActionResult<ApiResponse>> GetEmergencyService(int id)
        {
            var service = await _context.EmergencyServices.FindAsync(id);
            if (service == null)
            {
                return NotFound(new ApiResponse { Message = "Emergency Service not found", Result = null });
            }
            return Ok(new ApiResponse { Message = "Emergency Service retrieved successfully", Result = service });
        }

        [HttpPost("emergencyservices")]
        public async Task<ActionResult<ApiResponse>> CreateEmergencyService(EmergencyServiceDTO serviceDTO)
        {
            var service = new EmergencyService
            {
                ServiceName = serviceDTO.ServiceName,
                ContactNumber = serviceDTO.ContactNumber,
                IsActive = serviceDTO.IsActive
            };
            _context.EmergencyServices.Add(service);
            await _context.SaveChangesAsync();
            return Ok(new ApiResponse { Message = "Emergency Service created successfully", Result = service });
        }

        [HttpPut("emergencyservices/{id}")]
        public async Task<ActionResult<ApiResponse>> UpdateEmergencyService(int id, EmergencyServiceDTO serviceDTO)
        {
            var service = await _context.EmergencyServices.FindAsync(id);
            if (service == null)
            {
                return NotFound(new ApiResponse { Message = "Emergency Service not found", Result = null });
            }
            service.ServiceName = serviceDTO.ServiceName;
            service.ContactNumber = serviceDTO.ContactNumber;
            service.IsActive = serviceDTO.IsActive;
            await _context.SaveChangesAsync();
            return Ok(new ApiResponse { Message = "Emergency Service updated successfully", Result = service });
        }

        [HttpDelete("emergencyservices/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteEmergencyService(int id)
        {
            var service = await _context.EmergencyServices.FindAsync(id);
            if (service == null)
            {
                return NotFound(new ApiResponse { Message = "Emergency Service not found", Result = null });
            }
            _context.EmergencyServices.Remove(service);
            await _context.SaveChangesAsync();
            return Ok(new ApiResponse { Message = "Emergency Service deleted successfully", Result = service });
        }

        // LocalNews

        [HttpGet("localnews")]
        public async Task<ActionResult<ApiResponse>> GetLocalNews()
        {
            var news = await _context.LocalNews.ToListAsync();
            return Ok(new ApiResponse { Message = "Local News retrieved successfully", Result = news });
        }

        [HttpGet("localnews/{id}")]
        public async Task<ActionResult<ApiResponse>> GetLocalNews(int id)
        {
            var news = await _context.LocalNews.FindAsync(id);
            if (news == null)
            {
                return NotFound(new ApiResponse { Message = "Local News not found", Result = null });
            }
            return Ok(new ApiResponse { Message = "Local News retrieved successfully", Result = news });
        }

        [HttpPost("localnews")]
        public async Task<ActionResult<ApiResponse>> CreateLocalNews(LocalNewsDTO newsDTO)
        {
            var news = new LocalNews
            {
                Title = newsDTO.Title,
                Content = newsDTO.Content,
                PublishedAt = newsDTO.PublishedAt
            };
            _context.LocalNews.Add(news);
            await _context.SaveChangesAsync();
            return Ok(new ApiResponse { Message = "Local News created successfully", Result = news });
        }

        [HttpPut("localnews/{id}")]
        public async Task<ActionResult<ApiResponse>> UpdateLocalNews(int id, LocalNewsDTO newsDTO)
        {
            var news = await _context.LocalNews.FindAsync(id);
            if (news == null)
            {
                return NotFound(new ApiResponse { Message = "Local News not found", Result = null });
            }
            news.Title = newsDTO.Title;
            news.Content = newsDTO.Content;
            news.PublishedAt = newsDTO.PublishedAt;
            await _context.SaveChangesAsync();
            return Ok(new ApiResponse { Message = "Local News updated successfully", Result = news });
        }

        [HttpDelete("localnews/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteLocalNews(int id)
        {
            var news = await _context.LocalNews.FindAsync(id);
            if (news == null)
            {
                return NotFound(new ApiResponse { Message = "Local News not found", Result = null });
            }
            _context.LocalNews.Remove(news);
            await _context.SaveChangesAsync();
            return Ok(new ApiResponse { Message = "Local News deleted successfully", Result = news });
        }
    }
}
