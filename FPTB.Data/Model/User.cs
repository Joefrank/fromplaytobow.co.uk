using System;
using System.ComponentModel.DataAnnotations;

namespace FPTB.Data.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public DateTime? LastVisit { get; set; }
        public int NoOfVisits { get; set; }
        public DateTime Created { get; set; }

        public DateTime? LastUpdated { get; set; }
        public int? LastUpdatedByUserId { get; set; }

        public string Roles { get; set; }
    }
}
