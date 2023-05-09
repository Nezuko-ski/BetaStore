using BetaStore.Core.DTOs;
using BetaStore.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BetaStore.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _service;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public InvoiceController(IInvoiceService service)
        {
            _service = service;
        }
        /// <summary>
        /// Gets total invoice amount given a bill
        /// </summary>
        /// <param name="dTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GenerateInvoiceAmount([FromBody] InvoiceRequestDTO dTO)
        {
            var response = new ResponseDTO<InvoiceResponseDTO>();
            try
            {
                var validationContext = new ValidationContext(dTO);
                var validationResult = new List<ValidationResult>();
                var isValid = Validator.TryValidateObject(dTO, validationContext, validationResult, true);

                if (isValid)
                {
                    var result = await _service.CalculateTotalInvoiceAmount(dTO.InvoiceItems, dTO.CustomerId);
                    response.StatusCode = StatusCodes.Status200OK;
                    response.Data = new InvoiceResponseDTO
                    {
                        InvoiceAmount = result
                    };
                    response.Message = "Invoice Amount Generated Successfully";
                    return StatusCode(response.StatusCode, response);
                }
                else
                {
                    response.StatusCode = StatusCodes.Status400BadRequest;
                    response.Message = "Invalid Request";
                    response.Errors = validationResult.Select(x => x.ErrorMessage).ToList();
                    return StatusCode(response.StatusCode, response);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
