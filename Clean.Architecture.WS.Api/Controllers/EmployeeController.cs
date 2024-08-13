using Clean.Architecture.WS.Api.Requests;
using Clean.Architecture.WS.Api.Utils;
using Clean.Architecture.WS.Application.Contracts;
using Clean.Architecture.WS.Domain.Entities;
using Clean.Architecture.WS.Domain.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.Design;

namespace Clean.Architecture.WS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        #region Fields & Properties
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public EmployeeController(IConfiguration configuration, ILogger<EmployeeController> logger, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _logger = logger;
            _unitOfWork = unitOfWork;
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

                var validations = AddEmployeeRequestValidation(request);

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

                var validations = UpdateEmployeeRequestValidation(request);

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

        #region Validations
        private string AddEmployeeRequestValidation(AddEmployeeRequest request)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(request.FirstName))
            {
                errors.Add("firstName");
            }

            if (string.IsNullOrWhiteSpace(request.LastName))
            {
                errors.Add("lastName");
            }

            if (string.IsNullOrWhiteSpace(request.Email))
            {
                errors.Add("email");
            }

            if (string.IsNullOrWhiteSpace(request.PhoneNumber))
            {
                errors.Add("phoneNumber");
            }

            if (request.RoleId == 0)
            {
                errors.Add("roleId");
            }

            if (request.CompanyId == 0)
            {
                errors.Add("companyId");
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

        private string UpdateEmployeeRequestValidation(UpdateEmployeeRequest request)
        {
            var errors = new List<string>();

            if (request.EmployeeId == 0)
            {
                errors.Add("employeeId");
            }

            if (string.IsNullOrWhiteSpace(request.FirstName))
            {
                errors.Add("firstName");
            }

            if (string.IsNullOrWhiteSpace(request.LastName))
            {
                errors.Add("lastName");
            }

            if (string.IsNullOrWhiteSpace(request.Email))
            {
                errors.Add("email");
            }

            if (string.IsNullOrWhiteSpace(request.PhoneNumber))
            {
                errors.Add("phoneNumber");
            }

            if (request.RoleId == 0)
            {
                errors.Add("roleId");
            }

            if (request.CompanyId == 0)
            {
                errors.Add("companyId");
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
