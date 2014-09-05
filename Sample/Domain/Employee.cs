using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sample.Domain
{
    public enum Sex
    {
        Unknown,
        Man,
        Woman
    }

    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        public Sex Sex { get; set; }
        
        public DateTime Birthday { get; set; }
        
        public DateTime JoinDate { get; set; }

        [Required]
        public string IDCard { get; set; }

        public string Image { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public int EducationId { get; set; }
        public Education Education { get; set; }
    }

    public class Education
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime JoinDate { get; set; }
    }
}