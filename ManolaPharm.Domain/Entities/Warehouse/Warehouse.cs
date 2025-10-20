using System;
using System.ComponentModel.DataAnnotations;

namespace ManolaPharm.Domain.Entities.Warehouse
{
    /// <summary>
    /// Represents a physical warehouse or storage location.
    /// </summary>
    public class Warehouse
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Location { get; set; }

        [MaxLength(250)]
        public string Address { get; set; }

        [MaxLength(100)]
        public string City { get; set; }

        [MaxLength(100)]
        public string State { get; set; }

        [MaxLength(100)]
        public string Country { get; set; }

        [MaxLength(150)]
        public string Manager { get; set; }

        [MaxLength(50)]
        public string Phone { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [Range(0, 100000)]
        public int Capacity { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
