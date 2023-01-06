using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortfolioApiV1.Models.Dtos;
using PortfolioApiV1.Repositories;

namespace PortfolioApiV1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await userRepository.GetAllAsync();

            var usersDto = mapper.Map<List<Models.Dtos.User>>(users);

            return Ok(usersDto);
        }

        [HttpGet]
        [Route("{UserId:guid}")]
        [ActionName("GetUserAsync")]
        public async Task<IActionResult> GetUserAsync(Guid UserId)
        {
            var user = await userRepository.GetByIdAsync(UserId);

            if (user == null)
            {
                return NotFound();
            }

            var userDto = mapper.Map<Models.Dtos.User>(user);

            return Ok(userDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserAsync([FromBody] AddUserRequest addUserRequest)
        {
            var user = new Models.Domain.User
            {
                Avatar = addUserRequest.Avatar,
                Name = addUserRequest.Name,
                LastName = addUserRequest.LastName,
                Salt = addUserRequest.Salt,
                Email = addUserRequest.Email,
                Password = addUserRequest.Password,
                Phone = addUserRequest.Phone,
                Birthday = addUserRequest.Birthday,
                IsAdmin = addUserRequest.IsAdmin,
                About = addUserRequest.About
            };

            user = await userRepository.AddUserAsync(user);

            var userDto = new Models.Dtos.User
            {
                UserId = user.UserId,
                Avatar = user.Avatar,
                Name = user.Name,
                LastName = user.LastName,
                Salt = user.Salt,
                Email = user.Email,
                Password = user.Password,
                Phone = user.Phone,
                Birthday = user.Birthday,
                IsAdmin = user.IsAdmin,
                About = user.About,
                CreatedAt = user.CreatedAt
            };

            return CreatedAtAction(nameof(GetUserAsync), new { userId = userDto.UserId }, userDto);
        }

        [HttpPut]
        [Route("{UserId:guid}")]
        public async Task<IActionResult> UpdateUserAsync([FromRoute] Guid UserId, [FromBody] 
        Models.Dtos.UpdateUserRequest updateUserRequest)
        {
            var user = new Models.Domain.User
            {
                Avatar = updateUserRequest.Avatar,
                Name = updateUserRequest.Name,
                LastName = updateUserRequest.LastName,
                Salt = updateUserRequest.Salt,
                Email = updateUserRequest.Email,
                Password = updateUserRequest.Password,
                Phone = updateUserRequest.Phone,
                Birthday = updateUserRequest.Birthday,
                IsAdmin = updateUserRequest.IsAdmin,
                About = updateUserRequest.About
            };

            user = await userRepository.UpdateUserAsync(UserId, user);

            if (user == null)
            {
                return NotFound();
            }

            var userDto = new Models.Dtos.User
            {
                UserId = user.UserId,
                Avatar = user.Avatar,
                Name = user.Name,
                LastName = user.LastName,
                Salt = user.Salt,
                Email = user.Email,
                Password = user.Password,
                Phone = user.Phone,
                Birthday = user.Birthday,
                IsAdmin = user.IsAdmin,
                About = user.About,
                CreatedAt = user.CreatedAt
            };

            return Ok(userDto);
        }

        [HttpDelete]
        [Route("{UserId:guid}")]
        public async Task<IActionResult> DeleteUserAsync(Guid UserId)
        {
            var user = await userRepository.DeleteUserAsync(UserId);

            if (user == null)
            {
                return NotFound();
            }

            var userDto = mapper.Map<Models.Dtos.User>(user);

            return Ok(userDto);
        }
    }
}
