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

            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == userDto.Email);
            if (existingUser != null)
            {
                return BadRequest(new ApiResponse { Message = "Email address already exists", Result = null });
            }

            var existingUser1 = await _context.Users.FirstOrDefaultAsync(u => u.Username == userDto.Username);
            if (existingUser1 != null)
            {
                return BadRequest(new ApiResponse { Message = "Username address already exists", Result = null });
            }

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

            if (!string.IsNullOrEmpty(userDto.Email) && userDto.Email != user.Email)
            {
                var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == userDto.Email);
                if (existingUser != null)
                {
                    return BadRequest(new ApiResponse { Message = "Email address already exists", Result = null });
                }
                user.Email = userDto.Email;
            }

            if (!string.IsNullOrEmpty(userDto.Username) && userDto.Username != user.Username)
            {
                var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == userDto.Username);
                if (existingUser != null)
                {
                    return BadRequest(new ApiResponse { Message = "Username address already exists", Result = null });
                }
                user.Username = userDto.Username;
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
                PublishedAt = newsDTO.PublishedAt,
                Image = newsDTO.Image
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
            news.Image = newsDTO.Image;
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

        [HttpGet("users/search")]
        public async Task<ActionResult<ApiResponse>> SearchUser([FromQuery] string? email, [FromQuery] string? username)
        {
            if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(username))
            {
                return BadRequest(new ApiResponse { Message = "Email or username must be provided", Result = null });
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email || u.Username == username);

            if (user == null)
            {
                return NotFound(new ApiResponse { Message = "User not found", Result = null });
            }

            return Ok(new ApiResponse { Message = "User found", Result = user });
        }
    }
}