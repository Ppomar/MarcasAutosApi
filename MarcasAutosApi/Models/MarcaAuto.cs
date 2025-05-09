using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace MarcasAutosApi.Models
{
    public class MarcaAuto
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public string Country { get; set; } = default!;

        public int FoundedYear { get; set; }

        public bool IsActive { get; set; }

        public string ImageUrl { get; set; } = default!;

        public DateTime Created { get; set; } = DateTime.UtcNow;

        public DateTime Updated { get; set; }
    }
}
