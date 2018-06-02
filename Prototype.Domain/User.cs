using L5.DomainModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Prototype.Domain {

    public class ApplicationUser : IdentityUser {
        public int? DataPartitionId { get; set; }

        [DefaultValue(false)]
        public bool IsActive { get; set; }

        [DefaultValue(false)]
        public bool IsTempPassword { get; set; }

        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Modified { get; set; }

        [ForeignKey("DataPartitionId")]
        public virtual DataPartition DataPartition { get; set; }

        public List<UserLocation> UserLocations { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager) {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}