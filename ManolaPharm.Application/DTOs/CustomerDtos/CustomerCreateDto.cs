﻿using System.ComponentModel.DataAnnotations;

namespace ManolaPharm.Application.DTOs.CustomerDtos
{
    public class CustomerCreateDto
    {
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
    }
}
