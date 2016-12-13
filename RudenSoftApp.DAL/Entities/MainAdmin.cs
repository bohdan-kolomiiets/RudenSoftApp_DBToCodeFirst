namespace RudenSoftApp.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MainAdmin")]
    public partial class MainAdmin
    {
        [Key]
        public string UserProfileId { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }
}
