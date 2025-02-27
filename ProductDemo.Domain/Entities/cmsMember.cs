using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductDemo.Domain.Entities
{
   
public class CmsMember
    {
        [Key]
        [ForeignKey("UmbracoContent")]
        public int NodeId { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(1000)]
        public string LoginName { get; set; } = string.Empty;

        [Required]
        [MaxLength(1000)]
        public string Password { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? PasswordConfig { get; set; }

        [MaxLength(255)]
        public string? SecurityStampToken { get; set; }

        public DateTime? EmailConfirmedDate { get; set; }

        public int? FailedPasswordAttempts { get; set; }

        public bool IsLockedOut { get; set; } = false;

        [Required]
        public bool IsApproved { get; set; } = true;

        public DateTime? LastLoginDate { get; set; }

        public DateTime? LastLockoutDate { get; set; }

        public DateTime? LastPasswordChangeDate { get; set; }

        //public virtual UmbracoContent? UmbracoContent { get; set; }
    

}
}
