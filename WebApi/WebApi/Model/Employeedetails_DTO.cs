﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Model
{
    public class Employeedetails_DTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
        [StringLength(150)]
        public string LastName { get; set; }
        [StringLength(250)]
        public string Email { get; set; }
        public int Age { get; set; }
        public DateTime Doj { get; set; }
        [StringLength(20)]
        public string Gender { get; set; }
        public int IsMarried { get; set; }
        public int IsActive { get; set; }
        public int DeginationId { get; set; }
        public string Designation { get; set; }

    }
}