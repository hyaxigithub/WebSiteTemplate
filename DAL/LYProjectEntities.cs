namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LYProjectEntities : DbContext
    {
        public LYProjectEntities()
            : base("name=LYConnectionStrings")
        {
        }

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Article> Articles { get; set; }


        public virtual DbSet<FileUploader> FileUploader { get; set; }
        public virtual DbSet<SysDepartment> SysDepartment { get; set; }
        public virtual DbSet<SysException> SysException { get; set; }
        public virtual DbSet<SysField> SysField { get; set; }
        public virtual DbSet<SysLog> SysLog { get; set; }
        public virtual DbSet<SysMenu> SysMenu { get; set; }
        public virtual DbSet<SysMenuSysRoleSysOperation> SysMenuSysRoleSysOperation { get; set; }
        public virtual DbSet<SysOperation> SysOperation { get; set; }
        public virtual DbSet<SysPerson> SysPerson { get; set; }
        public virtual DbSet<SysRole> SysRole { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<FileUploader>()
                .Property(e => e.FullPath)
                .IsUnicode(false);

            modelBuilder.Entity<SysDepartment>()
                .HasMany(e => e.SysDepartment1)
                .WithOptional(e => e.SysDepartment2)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<SysField>()
                .HasMany(e => e.SysField1)
                .WithOptional(e => e.SysField2)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<SysMenu>()
                .HasMany(e => e.SysMenu1)
                .WithOptional(e => e.SysMenu2)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<SysMenu>()
                .HasMany(e => e.SysOperation)
                .WithMany(e => e.SysMenu)
                .Map(m => m.ToTable("SysMenuSysOperation").MapLeftKey("SysMenuId").MapRightKey("SysOperationId"));

            modelBuilder.Entity<SysPerson>()
                .Property(e => e.Remark)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SysPerson>()
                .Property(e => e.Version)
                .IsFixedLength();

            modelBuilder.Entity<SysPerson>()
                .HasMany(e => e.SysRole)
                .WithMany(e => e.SysPerson)
                .Map(m => m.ToTable("SysRoleSysPerson").MapLeftKey("SysPersonId").MapRightKey("SysRoleId"));
        }
    }
}
