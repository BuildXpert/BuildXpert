using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BX.Models
{
    public class ProjectTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El título de la tarea es obligatorio.")]
        public string Title { get; set; }

        public bool IsCompleted { get; set; } = false;

        public int ProjectId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.Now; 

        [MaxLength(500)]
        public string Description { get; set; }


        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }
    }
}
