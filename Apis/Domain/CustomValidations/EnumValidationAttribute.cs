using System.ComponentModel.DataAnnotations;

namespace Domain.CustomValidations
{
    public class EnumValidationAttribute : ValidationAttribute
    {
        private readonly Type _enumType;

        private const string DefaultErrorMessage = "Invalid value. Allowed values are: {0}";
        public EnumValidationAttribute(Type enumType)
        {
            _enumType = enumType;
            ErrorMessage = GetDefaultErrorMessage();
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!Enum.IsDefined(_enumType, value))
            {
                var enumValues = Enum.GetValues(_enumType);
                var allowedValues = string.Join(", ", enumValues.Cast<object>());

                return new ValidationResult(string.Format(ErrorMessage, allowedValues));
            }

            return ValidationResult.Success;
        }
        private string GetDefaultErrorMessage()
        {
            var enumValues = Enum.GetValues(_enumType);
            var allowedValues = string.Join(", ", enumValues.Cast<object>());
            return string.Format(DefaultErrorMessage, allowedValues);
        }
    }
}
