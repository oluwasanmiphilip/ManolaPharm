using System;
using System.ComponentModel.DataAnnotations;

namespace ManolaPharm.Application.DTOs.HRDtos
{
    public class EmployeeUpdateDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required, MaxLength(100)]
        public string FirstName { get; set; }

        [Required, MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Phone { get; set; }

        public Guid DepartmentId { get; set; }
        public Guid RoleId { get; set; }

        public DateTime DateHired { get; set; }
        public string Status { get; set; }
    }
}
