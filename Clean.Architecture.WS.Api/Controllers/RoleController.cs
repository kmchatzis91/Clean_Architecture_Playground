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

        [HttpPost]
        [Route("roles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddRole([FromBody] AddRoleRequest request)
        {
            try
            {
                _logger.LogInformation($"AddRole, request: {JsonConvert.SerializeObject(request)}");

                var validations = AddRoleRequestValidation(request);

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

                var validations = UpdateRoleRequestValidation(request);

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
        private string AddRoleRequestValidation(AddRoleRequest request)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                errors.Add("name");
            }

            if (errors.Count == 1)
            {
                return $"{errors[0]} is required!";
            }

            if (errors.Count == 2)
            {
                return $"{errors[0]} and {errors[1]} are required!";
            }

            if (errors.Count > 2)
            {
                var allErrors = "";

                foreach (var e in errors)
                {
                    if (e == errors.Last())
                    {
                        allErrors += $"and {e}";
                        break;
                    }

                    allErrors += $"{e}, ";
                }

                return $"{allErrors} are required!";
            }

            return Consts.Ok;
        }

        private string UpdateRoleRequestValidation(UpdateRoleRequest request)
        {
            var errors = new List<string>();

            if (request.RoleId == 0)
            {
                errors.Add("roleId");
            }

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                errors.Add("name");
            }

            if (errors.Count == 1)
            {
                return $"{errors[0]} is required!";
            }

            if (errors.Count == 2)
            {
                return $"{errors[0]} and {errors[1]} are required!";
            }

            if (errors.Count > 2)
            {
                var allErrors = "";

                foreach (var e in errors)
                {
                    if (e == errors.Last())
                    {
                        allErrors += $"and {e}";
                        break;
                    }

                    allErrors += $"{e}, ";
                }

                return $"{allErrors} are required!";
            }

            return Consts.Ok;
        }
        #endregion
    }
}
