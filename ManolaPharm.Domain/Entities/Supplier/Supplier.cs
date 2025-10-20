using System;
using System.ComponentModel.DataAnnotations;

namespace ManolaPharm.Domain.Entities.Supplier
{
    /// <summary>
    /// Represents a supplier providing goods or services to ManolaPharm.
    /// </summary>
    public class Supplier
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string ContactPerson { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        [MaxLength(100)]
        public string City { get; set; }

        [MaxLength(100)]
        public string State { get; set; }

        [MaxLength(100)]
        public string Country { get; set; }

        [MaxLength(500)]
        public string Notes { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
    }
}
