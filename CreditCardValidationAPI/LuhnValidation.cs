
namespace CreditCardValidationAPI
{
    /// <summary>
    /// Luhn Validation Service.
    /// </summary>
    public class LuhnValidation
    {
        /// <summary>
        /// Validation of credit card with Luhn algorithm.
        /// </summary>
        /// <param name="cardNumber">Credit Card Number.</param>
        /// <returns>Boolean value stating if the card is valid or not.</returns>
        public bool ValidateCreditCard(string cardNumber)
        {
            int sum = 0;
            bool alternate = false;
            for (int i = cardNumber.Length - 1; i >= 0; i--)
            {
                int digit = int.Parse(cardNumber[i].ToString());
                if (alternate)
                {
                    digit *= 2;
                    if (digit > 9)
                    {
                        digit -= 9; 
                    }
                }
                sum += digit;
                alternate = !alternate;
            }
            return (sum % 10 == 0);
        }
    }
}

   