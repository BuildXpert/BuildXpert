using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BX.Models
{
    public class ApplicationUser : IdentityUser
    {

        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = "Cliente";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
        public virtual ICollection<Project> ProjectsAsAdmin { get; set; } = new List<Project>();
    }
}
