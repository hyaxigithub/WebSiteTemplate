namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SysDepartment")]
    public partial class SysDepartment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SysDepartment()
        {
            SysDepartment1 = new HashSet<SysDepartment>();
            SysPerson = new HashSet<SysPerson>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [StringLength(36)]
        public string Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(36)]
        public string ParentId { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        public int? Sort { get; set; }

        [StringLength(4000)]
        public string Remark { get; set; }

        public DateTime? CreateTime { get; set; }

        [StringLength(200)]
        public string CreatePerson { get; set; }

        public DateTime? UpdateTime { get; set; }

        [StringLength(200)]
        public string UpdatePerson { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SysDepartment> SysDepartment1 { get; set; }

        public virtual SysDepartment SysDepartment2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SysPerson> SysPerson { get; set; }
    }
}
