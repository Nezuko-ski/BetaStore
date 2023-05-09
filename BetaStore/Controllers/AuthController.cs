using BetaStore.Core.DTOs;
using BetaStore.Core.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BetaStore.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public AuthController(IAuthService service)
        {
            _service = service;
        }
        /// <summary>
        /// Create a new customer
        /// </summary>
        /// <param name="dTO"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("create-customer")]
        public async Task<IActionResult> Register(CreateCustomerDTO dTO)
        {
            var result = await _service.CreateCustomerAsync(dTO);
            return StatusCode(result.StatusCode, result);
        }
        /// <summary>
        /// Get All Customers
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var result = await _service.GetAllCustomers();
            return StatusCode(result.StatusCode, result);
        }
        /// <summary>
        /// Get Customer By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCustomerById/{Id}")]
        public async Task<IActionResult> GetCustomerById([FromRoute] string Id)
        {
            var result = await _service.GetCustomerByIdAsync(Id);
            return StatusCode(result.StatusCode, result);
        }
        /// <summary>
        /// Get Customer By Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCustomerByName/{name}")]
        public async Task<IActionResult> GetCustomerByName([FromRoute] string name)
        {
            var result = await _service.GetCustomerByNameAsync(name);
            return StatusCode(result.StatusCode, result);
        }
    }
}
