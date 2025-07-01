using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DAL.DataAccess;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ServiceLayer.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserInfoRepo<UserInfo> _userRepo;
        private readonly IConfiguration _config;

        public UserInfoController(IUserInfoRepo<UserInfo> userRepo, IConfiguration config)
        {
            _userRepo = userRepo;
            _config = config;
        }

        // Returns all user records
        [HttpGet("All")]
        public IActionResult FetchAllUsers()
        {
            var users = _userRepo.GetAllUsers();

            return users != null && users.Any()
                ? Ok(users)
                : NotFound("No users found.");
        }

        // Returns a user by email ID
        [HttpGet("ByEmail/{emailId}")]
        public IActionResult FetchUserByEmail(string emailId)
        {
            var user = _userRepo.GetUserByEmail(emailId);

            return user != null
                ? Ok(user)
                : NotFound($"User with email '{emailId}' not found.");
        }

        // Registers a new user
        [HttpPost("Register")]
        public IActionResult RegisterUser([FromBody] UserInfo user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = _userRepo.AddUser(user);
            return Created(HttpContext.Request.Path, created);
        }

        // Updates an existing user (Admin only)
        [HttpPut("Edit")]
        [Authorize(Roles = "Admin")]
        public IActionResult ModifyUser([FromBody] UserInfo user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = _userRepo.UpdateUser(user);

            return updated != null
                ? Accepted(HttpContext.Request.Path, updated)
                : NotFound("User not found or update failed.");
        }

        // Deletes a user by email (Admin only)
        [HttpDelete("Remove/{emailId}")]
        [Authorize(Roles = "Admin")]
        public IActionResult RemoveUser(string emailId)
        {
            var deleted = _userRepo.DeleteUser(emailId);

            return deleted != null
                ? Ok(deleted)
                : NotFound($"No user found with email = {emailId}");
        }

        // Validates user and returns JWT token
        [HttpPost("Login")]
        public IActionResult Authenticate([FromBody] UserInfo credentials)
        {
            var validUser = _userRepo.ValidateUser(credentials.EmailId);

            if (validUser != null)
            {
                var token = GenerateJwtToken(credentials);
                return Ok(token);
            }

            return Unauthorized("Invalid credentials.");
        }

        // Generates JWT token (not exposed as an endpoint)
        [NonAction]
        private string GenerateJwtToken(UserInfo user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.EmailId),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
