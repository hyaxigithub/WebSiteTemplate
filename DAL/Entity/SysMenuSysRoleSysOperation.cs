namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SysMenuSysRoleSysOperation")]
    public partial class SysMenuSysRoleSysOperation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [StringLength(36)]
        public string Id { get; set; }

        [StringLength(36)]
        public string SysMenuId { get; set; }

        [StringLength(36)]
        public string SysOperationId { get; set; }

        [StringLength(36)]
        public string SysRoleId { get; set; }

        public virtual SysMenu SysMenu { get; set; }

        public virtual SysOperation SysOperation { get; set; }

        public virtual SysRole SysRole { get; set; }
    }
}
