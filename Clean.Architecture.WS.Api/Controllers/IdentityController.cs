using Clean.Architecture.WS.Api.Requests;
using Clean.Architecture.WS.Api.Response;
using Clean.Architecture.WS.Api.Utils;
using Clean.Architecture.WS.Application.Contracts;
using Clean.Architecture.WS.Domain.Entities;
using Clean.Architecture.WS.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Clean.Architecture.WS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        #region Fields & Properties
        private readonly IConfiguration _configuration;
        private readonly ILogger<RoleController> _logger;
        #endregion

        #region Constructor
        public IdentityController(IConfiguration configuration, ILogger<RoleController> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        #endregion

        #region Methods
        [HttpPost]
        [Route("token")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GenerateToken([FromBody] GenerateTokenRequest request)
        {
            try
            {
                _logger.LogInformation($"GenerateToken, request: {JsonConvert.SerializeObject(request)}");

                var claims = new List<Claim>()
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("userId", request.UserId.ToString()),
                    new Claim("firstName", request.FirstName),
                    new Claim("lastName", request.LastName),
                    new Claim(JwtRegisteredClaimNames.Email, request.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, request.Email),
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                (
                    issuer: _configuration["JwtSettings:Issuer"],
                    audience: _configuration["JwtSettings:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddSeconds(Convert.ToInt32(_configuration["JwtSettings:ExpirationSeconds"])),
                    signingCredentials: credentials
                );

                var response = new TokenResponse()
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    ExpirationSeconds = Convert.ToInt32(_configuration["JwtSettings:ExpirationSeconds"])
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem();
            }
        }
        #endregion
    }
}
