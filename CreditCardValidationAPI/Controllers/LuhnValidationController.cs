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
        [Route("ValidateCreditCard")]
        public ActionResult<bool> ValidateCreditCard([FromBody] string cardNumber)
        {
            bool isValid = false;
            try
            {
                if (string.IsNullOrWhiteSpace(cardNumber))
                {
                    return BadRequest("Card number cannot is null/empty.");
                }
                else if (!cardNumber.All(char.IsDigit))
                {
                    return BadRequest("Card number should have numbers only.");
                }
                else if (cardNumber.Length < 13 || cardNumber.Length > 19)
                {
                    return BadRequest(new { message = "Credit card number must be between 13 and 19 digits long." });
                }
                isValid = _luhnValidationService.ValidateCreditCard(cardNumber);
            }
            catch (Exception exception)
            {
                return StatusCode(500, new { message = "An unexpected error occurred. Please try again later."+exception });
            }
            return Ok(isValid);
        }

    }
}
