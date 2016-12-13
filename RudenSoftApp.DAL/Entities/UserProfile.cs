namespace RudenSoftApp.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserProfile")]
    public partial class UserProfile
    {
        [Key]
        public string ApplicationUserId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? Age { get; set; }

        [StringLength(300)]
        public string PhotoUrl { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual MainAdmin MainAdmin { get; set; }

        public virtual Manager Manager { get; set; }

        public virtual Seller Seller { get; set; }
    }
}
