namespace RudenSoftApp.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Manager")]
    public partial class Manager
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Manager()
        {
            Office = new HashSet<Office>();
        }

        [Key]
        public string UserProfileId { get; set; }

        [StringLength(300)]
        public string ResumeUrl { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Office> Office { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }
}
