using fin_back.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace fin_back.Models.Organization
{
    public class OrganizationCreate
    {
        public int? RegNum { get; set; } //УНП
        public string? OrgType { get; set; }
        public string? OrgName { get; set; }
        public string? OrgEmail { get; set; }
        public string? OrgAddress { get; set; }
        public string Email { get; set; } = null!;
    }
}
