using Clean.Architecture.WS.Application.Contracts;
using Clean.Architecture.WS.Domain.Entities;
using Clean.Architecture.WS.Domain.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<List<EmployeeView>> GetAllEmployees()
        {
            _logger.LogInformation("GetAllEmployees");
            var employees = await _unitOfWork.EmployeeRepository.GetAllEmployeesInformation();
            return employees;
        }

        [HttpGet]
        [Route("employees/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<EmployeeView> GetEmployeeById([FromRoute] long id)
        {
            _logger.LogInformation($"GetEmployeeById id: {id}");
            var employee = await _unitOfWork.EmployeeRepository.GetEmployeeInformationById(id);
            return employee;
        }
        #endregion
    }
}
