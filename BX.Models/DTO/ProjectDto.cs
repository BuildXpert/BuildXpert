using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BX.Models.DTO
{
    public class ProjectDto
    {
        #region PROJECT FIELDS
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        #region Foreign Keys
        public string? ProjectStatusId { get; set; } = "Entregado";// Puede ser: Entregado, Construccion, Venta, Remodelacion
        public int? PropertyId { get; set; }
        public string? ClientId { get; set; }
        public string? AdminId { get; set; }
        #endregion
        #endregion

        #region PROPERTY FIELDS
        public string PropertyName { get; set; }
        public string PropertyDescription { get; set; }
        public string PropertyStatus { get; set; } = "Disponible"; // Puede ser: Disponible, Vendido, En Construcción, En Remodelación
        public DateTime PropertyCreatedDate { get; set; } = DateTime.Now;
        public string ConstructionType { get; set; }  // Prefabricados o Block
        public string Province { get; set; }  // Provincia
        public string Canton { get; set; }  // Cantón
        public double ConstructionSize { get; set; }  // Tamaño de construcción en m²
        public double LandSize { get; set; }  // Tamaño del terreno en m²
        public int Bedrooms { get; set; }  // Número de habitaciones
        public int Bathrooms { get; set; }  // Número de baños
        public decimal Price { get; set; }  // Precio de la propiedad
        public int Floors { get; set; }  // Número de plantas
        public bool HasGarage { get; set; }  // ¿Tiene cochera?
        public int GarageCapacity { get; set; }  // Capacidad de la cochera
        public bool IsCondominium { get; set; }  // ¿Es en condominio?
        #endregion 

        public Property ToProperty()
        {
            var property = new Property
            {
                Name = this.PropertyName,
                Description = this.PropertyDescription,
                Status = this.PropertyStatus,
                CreatedDate = this.PropertyCreatedDate,
                ConstructionType = this.ConstructionType,
                Province = this.Province,
                Canton = this.Canton,
                ConstructionSize = this.ConstructionSize,
                LandSize = this.LandSize,
                Bedrooms = this.Bedrooms,
                Bathrooms = this.Bathrooms,
                Price = this.Price,
                Floors = this.Floors,
                HasGarage = this.HasGarage,
                GarageCapacity = this.GarageCapacity,
                IsCondominium = this.IsCondominium
            };
            return property;
        }

        public Project ToProject()
        {
            var project = new Project
            {
                Id = this.Id ?? 0,
                Name = this.Name,
                Description = this.Description,

                CreatedDate = DateTime.Now,

                ProjectStatusId = this.ProjectStatusId,
                PropertyId = this.PropertyId ?? 0,
                ClientId = this.ClientId ?? new Guid().ToString(),
                AdminId = this.AdminId ?? new Guid().ToString()
            };
            return project;
        }
    }
}
