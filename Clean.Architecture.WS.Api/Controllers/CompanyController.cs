using Clean.Architecture.WS.Application.Contracts;
using Clean.Architecture.WS.Domain.Entities;
using Clean.Architecture.WS.Domain.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Architecture.WS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        #region Fields & Properties
        private readonly IConfiguration _configuration;
        private readonly ILogger<CompanyController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public CompanyController(IConfiguration configuration, ILogger<CompanyController> logger, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _logger = logger;
            _unitOfWork = unitOfWork;
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
        #endregion
    }
}
