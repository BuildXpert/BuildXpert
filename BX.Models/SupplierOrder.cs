using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BX.Models
{
    public class SupplierOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // 🔹 Relación con `Proveedor`
        [Required]
        public int SupplierId { get; set; }

        [ForeignKey("ProveedorId")]
        public Supplier Supplier { get; set; }

        // 🔹 Datos del pedido
        [Required(ErrorMessage = "El nombre del material es obligatorio.")]
        public string Material { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "La descripción del pedido es obligatoria.")]
        public string Description { get; set; }

        // 🔹 Fecha del pedido (solo usar una)
        [Required]
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        // 🔹 Monto del pedido
        [Required(ErrorMessage = "El monto del pedido es obligatorio.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        // 🔹 Estado del pedido
        [Required(ErrorMessage = "El estado del pedido es obligatorio.")]
        public string Status { get; set; } = "Pendiente";
    }
}