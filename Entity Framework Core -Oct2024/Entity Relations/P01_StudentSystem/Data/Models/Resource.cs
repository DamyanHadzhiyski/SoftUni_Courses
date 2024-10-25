using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using P01_StudentSystem.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }

        [Required]
        [MaxLength(50)]
        [Unicode]
        public string? Name { get; set; }

        public string? Url { get; set; }

        public ResourceType ResourceType { get; set; }

        public int CourseId { get; set; }

        public Course? Course { get; set; }
    }
}
