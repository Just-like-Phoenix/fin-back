using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fin_back.Data.Entities
{
    public class Organization
    {
        [Key]
        [Required]
        public int? RegNum { get; set; } //УНП
        [Required]
        public string? OrgType { get; set; } 
        [Required]
        public string? OrgName { get; set; }
        [Required]
        public string? OrgEmail { get; set; }
        [Required]
        public string? OrgAddress { get; set;}

        [Required]
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
    }
}
