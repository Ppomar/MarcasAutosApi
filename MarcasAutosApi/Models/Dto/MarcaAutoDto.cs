using System.ComponentModel.DataAnnotations;

namespace MarcasAutosApi.Models.Dto
{
    public class MarcaAutoDto : IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre de la marca obligatorio")]
        public string Name { get; set; } = default!;

        [Required(ErrorMessage = "Pais de la marca obligatorio")]
        public string Country { get; set; } = default!;

        public int FoundedYear { get; set; }

        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Url de la imagen de la marca obligatorio")]
        public string ImageUrl { get; set; } = default!;

        #region Validaciones Personalizadas

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (FoundedYear < 1700 || FoundedYear > DateTime.UtcNow.Year)
            {
                yield return new ValidationResult(
                    $"El año de fundación debe estar entre 1700 y {DateTime.UtcNow.Year}.",
                    new[] { nameof(FoundedYear) });
            }
        }

        #endregion Validaciones Personalizadas
    }
}
