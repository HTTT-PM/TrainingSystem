using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using TraniningSystemAPI.Data;
using Microsoft.AspNetCore.Mvc;


namespace TraniningSystemAPI.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        public IConfiguration Configuration { get; }
        private readonly ModelContext _context;

        public LoginController(IConfiguration configuration, ModelContext context)
        {
            _context = context;
            Configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var account =
                _context.Account
                    .Where(item => item.Username == request.username && request.password == item.Password)
                    .FirstOrDefault();

            // Validate the user's credentials (e.g. using a database or other storage)
            // var user = await _userService.ValidateCredentials(request.Username, request.Password);
            if (account == null)
            {
                return Unauthorized();
            }

            // Generate a JWT for the user
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]);
            Console.WriteLine(key);
            Console.WriteLine(Configuration["AllowedHosts"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, account.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // Return the token to the client
            return Ok(new
            {
                Token = tokenString
            });
        }

        public class LoginRequest
        {
            public string username { get; set; }
            public string password { get; set; }
        }
    }

}