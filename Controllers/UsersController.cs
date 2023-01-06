using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    }
}
