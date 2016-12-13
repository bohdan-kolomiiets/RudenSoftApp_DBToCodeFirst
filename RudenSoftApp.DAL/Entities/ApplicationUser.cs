namespace RudenSoftApp.DAL.Entities
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ApplicationUser")]
    public partial class ApplicationUser: IdentityUser
    {
        public virtual UserProfile UserProfile { get; set; }
    }
}
