using Microsoft.AspNetCore.Identity;
using System;

namespace SMPSystem.Models
{
    public class DbUser : IdentityUser
    {
        public string Ra { get; set; }
        public string Document { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastUpdate { get; set; } = DateTime.Now;
        public bool Deleted { get; set; }
    }
}
