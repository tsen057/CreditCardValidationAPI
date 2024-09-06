# Credit Card Validation API
This is a simple ASP.NET Core Web API for validating credit card numbers using the Luhn algorithm.

# Endpoints
- POST /api/luhnvalidation/validate: Validates a credit card number and returns `true` if valid, `false` if invalid.

# Error Handling
- **400 Bad Request**: Returned when the input is invalid. Example:
- **500 Internal Server Error**: Returned when an unexpected error occurs. Example:
  
