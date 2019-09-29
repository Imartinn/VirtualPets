using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VirtualPets.Logic.Interfaces;
using VirtualPets.Logic.Models;

namespace VirtualPets.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userService.GetUsersAsync();
        }

        [HttpPost]
        public async Task<Guid> CreateUserAsync([FromBody]string name)
        {
            return await _userService.CreateUserAsync(name);
        }
        
        [HttpDelete]
        public async Task DeleteUserAsync([FromQuery]Guid userId)
        {
            await _userService.RemoveUserAsync(userId);
        }
    }
}
