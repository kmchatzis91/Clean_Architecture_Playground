using Clean.Architecture.WS.Application.Contracts;
using Clean.Architecture.WS.Domain.Entities;
using Clean.Architecture.WS.Domain.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Architecture.WS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        #region Fields & Properties
        private readonly IConfiguration _configuration;
        private readonly ILogger<RoleController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public RoleController(IConfiguration configuration, ILogger<RoleController> logger, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        [HttpGet]
        [Route("roles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<List<Role>> GetAllRoles()
        {
            _logger.LogInformation("GetAllRoles");
            var roles = await _unitOfWork.RoleRepository.Get();
            return roles;
        }

        [HttpGet]
        [Route("roles/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Role> GetRoleById([FromRoute] long id)
        {
            _logger.LogInformation($"GetRoleById id: {id}");
            var role = await _unitOfWork.RoleRepository.GetById(id);
            return role;
        }
        #endregion
    }
}
