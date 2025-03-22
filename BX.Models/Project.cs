using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BX.Models
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del proyecto es obligatorio.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "La descripción del proyecto es obligatoria.")]
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        #region Foreign Keys
        [Required]
        public string? ProjectStatusId { get; set; } // Puede ser: Entregado, Construccion, Venta, Remodelacion
        public int PropertyId { get; set; }
        public string? ClientId { get; set; }
        public string? AdminId { get; set; }
        #endregion

        #region Navigation attributes
        [ForeignKey("ClientId")]
        public virtual ApplicationUser Client { get; set; }
        [ForeignKey("AdminId")]
        public virtual ApplicationUser? Admin { get; set; }
        [ForeignKey("PropertyId")]
        public virtual Property Property { get; set; }
        [ForeignKey("ProjectStatusId")]
        public virtual ProjectStatus Status { get; set; }
        public virtual ICollection<ProjectTask> Tasks { get; set; }
        #endregion
    }
}