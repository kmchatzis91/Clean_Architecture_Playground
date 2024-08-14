using Clean.Architecture.WS.Api.Requests;
using Clean.Architecture.WS.Api.Utils;
using Clean.Architecture.WS.Application.Contracts;
using Clean.Architecture.WS.Domain.Entities;
using Clean.Architecture.WS.Domain.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Clean.Architecture.WS.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        #region Fields & Properties
        private readonly IConfiguration _configuration;
        private readonly ILogger<CompanyController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly RequestValidationService _requestValidationService;
        #endregion

        #region Constructor
        public CompanyController(
            IConfiguration configuration, 
            ILogger<CompanyController> logger, 
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
        [Route("companies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<List<Company>> GetAllCompanies()
        {
            _logger.LogInformation("GetAllCompanies");
            var companies = await _unitOfWork.CompanyRepository.Get();
            return companies;
        }

        [HttpGet]
        [Route("companies/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Company> GetCompanyById([FromRoute] long id)
        {
            _logger.LogInformation($"GetCompanyById id: {id}");
            var company = await _unitOfWork.CompanyRepository.GetById(id);
            return company;
        }

        [HttpPost]
        [Route("companies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddCompany([FromBody] AddCompanyRequest request)
        {
            try
            {
                _logger.LogInformation($"AddCompany, request: {JsonConvert.SerializeObject(request)}");

                var validations = _requestValidationService.AddCompanyRequestValidation(request);

                if (validations != Consts.Ok)
                {
                    return Problem(detail: validations);
                }

                var company = new Company()
                {
                    Name = request.Name
                };

                var result = await _unitOfWork.CompanyRepository.Add(company);

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
        [Route("companies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCompany([FromBody] UpdateCompanyRequest request)
        {
            try
            {
                _logger.LogInformation($"UpdateCompany, request: {JsonConvert.SerializeObject(request)}");

                var validations = _requestValidationService.UpdateCompanyRequestValidation(request);

                if (validations != Consts.Ok)
                {
                    return Problem(detail: validations);
                }

                var company = new Company()
                {
                    CompanyId = request.CompanyId,
                    Name = request.Name
                };

                var result = await _unitOfWork.CompanyRepository.Update(company);

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
