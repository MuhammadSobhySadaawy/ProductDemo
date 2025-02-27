using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ProductDemo.Domain.Entities
{
    public class AspNetUser : IdentityUser
    {
        
        //public string Id { get; set; }

        //public string UserName { get; set; }

      
        //public string NormalizedUserName { get; set; }

     
        //public string Email { get; set; }

       
        //public string NormalizedEmail { get; set; }

     
        //public bool EmailConfirmed { get; set; }

        //public string PasswordHash { get; set; }
        //public string SecurityStamp { get; set; }
        //public string ConcurrencyStamp { get; set; }
        //public string PhoneNumber { get; set; }

        //public bool PhoneNumberConfirmed { get; set; }

        //public bool TwoFactorEnabled { get; set; }

        //public DateTimeOffset? LockoutEnd { get; set; }

        //public bool LockoutEnabled { get; set; }

        //public int AccessFailedCount { get; set; }

      
        //public string FirstName { get; set; }

        //public string LastName { get; set; }

      
        public bool IsBlocked { get; set; } = false;

        //public DateTimeOffset? BlockedAt { get; set; }
        //public string BlockedBy { get; set; }

     
        //public string CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

       
        //public string ModifiedBy { get; set; }

        //public DateTime? ModifiedAt { get; set; }

        public DateTime? LastLoginDate { get; set; }

      
        //public int LoginCount { get; set; } = 0;

   
        //public string OtherName { get; set; }
    }
}
