using Microsoft.AspNetCore.Mvc;

namespace CreditCardValidationAPI.Controllers
{
    public class LuhnValidationController : Controller
    {
        /// <summary>
        /// Luhn Validation Service parameter.
        /// </summary>
        private readonly LuhnValidation _luhnValidationService;

        /// <summary>
        /// Inject the service through the constructor.
        /// </summary>
        /// <param name="luhnValidationService">Object type for Luhn Validation.</param>
        public LuhnValidationController(LuhnValidation luhnValidationService)
        {
            _luhnValidationService = luhnValidationService;
        }

        /// <summary>
        /// Web API for credit card validation
        /// </summary>
        /// <param name="cardNumber">String number of credit card</param>
        /// <returns></returns>
        [HttpPost]
        [Route("validate")]
        public ActionResult<bool> ValidateCreditCard([FromBody] string cardNumber)
        { 
            if(string.IsNullOrWhiteSpace(cardNumber))
            {
                return BadRequest("Card number cannot is null/empty.");
            }
            else if (!cardNumber.All(char.IsDigit)) 
            {
                return BadRequest("Card number should have numbers only.");
            }
            bool isValid = _luhnValidationService.ValidateCreditCard(cardNumber);

            return Ok(isValid);
        }

    }
}
