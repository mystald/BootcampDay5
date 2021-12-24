using System.ComponentModel.DataAnnotations;

namespace BootcampDay5.ValidationAttributes
{
    public class AuthorFirstLastNameValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var author = (Dtos.AuthorInsertDto)validationContext.ObjectInstance;

            if (author.FirstName == author.LastName)
            {
                return new ValidationResult("FirstName and LastName must be different",
                    new[] { nameof(Dtos.AuthorInsertDto) });
            }

            return ValidationResult.Success;
        }

    }
}
