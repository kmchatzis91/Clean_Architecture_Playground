using Clean.Architecture.WS.Api.Requests;
using Clean.Architecture.WS.Api.Utils;
using Clean.Architecture.WS.Application.Contracts;
using Clean.Architecture.WS.Domain.Entities;
using Clean.Architecture.WS.Domain.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.Design;

namespace Clean.Architecture.WS.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        #region Fields & Properties
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly RequestValidationService _requestValidationService;
        #endregion

        #region Constructor
        public EmployeeController(
            IConfiguration configuration, 
            ILogger<EmployeeController> logger, 
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
        [Route("employees")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<List<EmployeeView>> GetEmployees()
        {
            _logger.LogInformation("GetEmployees");
            var employees = await _unitOfWork.EmployeeRepository.GetView();
            return employees;
        }

        [HttpGet]
        [Route("employees/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<EmployeeView> GetEmployeeById([FromRoute] long id)
        {
            _logger.LogInformation($"GetEmployeeById, id: {id}");
            var employee = await _unitOfWork.EmployeeRepository.GetViewById(id);
            return employee;
        }

        [HttpPost]
        [Route("employees")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeRequest request)
        {
            try
            {
                _logger.LogInformation($"AddEmployee, request: {JsonConvert.SerializeObject(request)}");

                var validations = _requestValidationService.AddEmployeeRequestValidation(request);

                if (validations != Consts.Ok)
                {
                    return Problem(detail: validations);
                }

                var employee = new Employee()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    RoleId = request.RoleId,
                    CompanyId = request.CompanyId,
                };

                var result = await _unitOfWork.EmployeeRepository.Add(employee);

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
        [Route("employees")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeRequest request)
        {
            try
            {
                _logger.LogInformation($"UpdateEmployee, request: {JsonConvert.SerializeObject(request)}");

                var validations = _requestValidationService.UpdateEmployeeRequestValidation(request);

                if (validations != Consts.Ok)
                {
                    return Problem(detail: validations);
                }

                var employee = new Employee()
                {
                    EmployeeId = request.EmployeeId,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    RoleId = request.RoleId,
                    CompanyId = request.CompanyId,
                };

                var result = await _unitOfWork.EmployeeRepository.Update(employee);

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

        [HttpDelete]
        [Route("employees/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteEmployee([FromRoute] long id)
        {
            try
            {
                _logger.LogInformation($"DeleteEmployee, id: {id}");

                if (id == 0)
                {
                    return Problem(detail: "id is required!");
                }

                var result = await _unitOfWork.EmployeeRepository.DeleteById(id);

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
    }
}
