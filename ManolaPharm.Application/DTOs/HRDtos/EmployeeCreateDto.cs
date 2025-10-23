using System;
using System.ComponentModel.DataAnnotations;

namespace ManolaPharm.Application.DTOs.HRDtos
{
    public class EmployeeCreateDto
    {
        [Required, MaxLength(100)]
        public string FirstName { get; set; }

        [Required, MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Phone { get; set; }

        [Required]
        public Guid DepartmentId { get; set; }

        [Required]
        public Guid RoleId { get; set; }

        public DateTime DateOfBirth { get; set; }
        public DateTime DateHired { get; set; }
    }
}
