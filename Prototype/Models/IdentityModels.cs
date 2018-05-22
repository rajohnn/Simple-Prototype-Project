using L5.DomainModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Prototype.Models {

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    //public class ApplicationUser : IdentityUser {

    //    [DefaultValue(false)]
    //    public bool IsActive { get; set; }

    //    [DefaultValue(false)]
    //    public bool IsTempPassword { get; set; }

    //    public DateTimeOffset Created { get; set; }
    //    public DateTimeOffset Modified { get; set; }

    //    public virtual List<Location> Locations { get; set; }

    //    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager) {
    //        // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
    //        var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
    //        // Add custom user claims here
    //        return userIdentity;
    //    }
    //}

    //public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {

    //    public ApplicationDbContext()
    //        : base("PrototypeContext", throwIfV1Schema: false) {
    //    }

    //    public static ApplicationDbContext Create() {
    //        return new ApplicationDbContext();
    //    }
    //}
}