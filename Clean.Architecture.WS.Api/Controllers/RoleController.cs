using Clean.Architecture.WS.Api.Requests;
using Clean.Architecture.WS.Api.Utils;
using Clean.Architecture.WS.Application.Contracts;
using Clean.Architecture.WS.Domain.Entities;
using Clean.Architecture.WS.Domain.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        private readonly RequestValidationService _requestValidationService;
        #endregion

        #region Constructor
        public RoleController(
            IConfiguration configuration, 
            ILogger<RoleController> logger, 
            IUnitOfWork unitOfWork,
            RequestValidationService requestValidationService)
        {
            _configuration = configuration;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _requestValidationService = requestValidationService;
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

        [HttpPost]
        [Route("roles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddRole([FromBody] AddRoleRequest request)
        {
            try
            {
                _logger.LogInformation($"AddRole, request: {JsonConvert.SerializeObject(request)}");

                var validations = _requestValidationService.AddRoleRequestValidation(request);

                if (validations != Consts.Ok)
                {
                    return Problem(detail: validations);
                }

                var role = new Role()
                {
                    Name = request.Name
                };

                var result = await _unitOfWork.RoleRepository.Add(role);

                if (!result)
                {
                    return Problem();
                }

                return Ok();
            }
            catch (Exception)
            {
                return Problem();
            }
        }

        [HttpPut]
        [Route("roles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleRequest request)
        {
            try
            {
                _logger.LogInformation($"UpdateRole, request: {JsonConvert.SerializeObject(request)}");

                var validations = _requestValidationService.UpdateRoleRequestValidation(request);

                if (validations != Consts.Ok)
                {
                    return Problem(detail: validations);
                }

                var role = new Role()
                {
                    RoleId = request.RoleId,
                    Name = request.Name
                };

                var result = await _unitOfWork.RoleRepository.Update(role);

                if (!result)
                {
                    return Problem();
                }

                return Ok();
            }
            catch (Exception)
            {
                return Problem();
            }
        }
        #endregion

        #region Validations

        #endregion
    }
}
