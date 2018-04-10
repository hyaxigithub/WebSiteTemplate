namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SysMenu")]
    public partial class SysMenu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SysMenu()
        {
            SysMenu1 = new HashSet<SysMenu>();
            SysMenuSysRoleSysOperation = new HashSet<SysMenuSysRoleSysOperation>();
            SysOperation = new HashSet<SysOperation>();
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
        public string Url { get; set; }

        [StringLength(200)]
        public string Iconic { get; set; }

        public int? Sort { get; set; }

        [StringLength(4000)]
        public string Remark { get; set; }

        [StringLength(200)]
        public string State { get; set; }

        [StringLength(200)]
        public string CreatePerson { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }

        [StringLength(200)]
        public string UpdatePerson { get; set; }

        [StringLength(200)]
        public string IsLeaf { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SysMenu> SysMenu1 { get; set; }

        public virtual SysMenu SysMenu2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SysMenuSysRoleSysOperation> SysMenuSysRoleSysOperation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SysOperation> SysOperation { get; set; }
    }
}
