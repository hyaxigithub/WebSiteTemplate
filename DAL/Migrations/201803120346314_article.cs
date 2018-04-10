namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class article : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Article", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropPrimaryKey("dbo.Article");
            DropPrimaryKey("dbo.AspNetUsers");
            DropPrimaryKey("dbo.AspNetRoles");
            DropPrimaryKey("dbo.AspNetUserClaims");
            CreateTable(
                "dbo.FileUploader",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 36),
                        Name = c.String(maxLength: 200),
                        Path = c.String(maxLength: 200),
                        FullPath = c.String(maxLength: 500, unicode: false),
                        Suffix = c.String(maxLength: 200),
                        Size = c.Int(),
                        Remark = c.String(maxLength: 4000),
                        State = c.String(maxLength: 200),
                        CreateTime = c.DateTime(),
                        CreatePerson = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SysDepartment",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 36),
                        Name = c.String(nullable: false, maxLength: 200),
                        ParentId = c.String(maxLength: 36),
                        Address = c.String(maxLength: 200),
                        Sort = c.Int(),
                        Remark = c.String(maxLength: 4000),
                        CreateTime = c.DateTime(),
                        CreatePerson = c.String(maxLength: 200),
                        UpdateTime = c.DateTime(),
                        UpdatePerson = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SysDepartment", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.SysPerson",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 36),
                        Name = c.String(nullable: false, maxLength: 200),
                        MyName = c.String(maxLength: 200),
                        Password = c.String(nullable: false, maxLength: 200),
                        SurePassword = c.String(maxLength: 200),
                        Sex = c.String(maxLength: 200),
                        SysDepartmentId = c.String(maxLength: 36),
                        Position = c.String(maxLength: 200),
                        MobilePhoneNumber = c.String(maxLength: 200),
                        PhoneNumber = c.String(maxLength: 200),
                        Province = c.String(maxLength: 200),
                        City = c.String(maxLength: 200),
                        Village = c.String(maxLength: 200),
                        Address = c.String(maxLength: 200),
                        EmailAddress = c.String(maxLength: 200),
                        Remark = c.Decimal(precision: 18, scale: 0),
                        State = c.String(maxLength: 200),
                        CreateTime = c.DateTime(),
                        CreatePerson = c.String(maxLength: 200),
                        UpdateTime = c.DateTime(),
                        UpdatePerson = c.String(maxLength: 200),
                        Version = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SysDepartment", t => t.SysDepartmentId)
                .Index(t => t.SysDepartmentId);
            
            CreateTable(
                "dbo.SysRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 36),
                        Name = c.String(nullable: false, maxLength: 200),
                        Description = c.String(maxLength: 4000),
                        CreateTime = c.DateTime(),
                        CreatePerson = c.String(maxLength: 200),
                        UpdateTime = c.DateTime(),
                        UpdatePerson = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SysMenuSysRoleSysOperation",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 36),
                        SysMenuId = c.String(maxLength: 36),
                        SysOperationId = c.String(maxLength: 36),
                        SysRoleId = c.String(maxLength: 36),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SysMenu", t => t.SysMenuId)
                .ForeignKey("dbo.SysOperation", t => t.SysOperationId)
                .ForeignKey("dbo.SysRole", t => t.SysRoleId)
                .Index(t => t.SysMenuId)
                .Index(t => t.SysOperationId)
                .Index(t => t.SysRoleId);
            
            CreateTable(
                "dbo.SysMenu",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 36),
                        Name = c.String(nullable: false, maxLength: 200),
                        ParentId = c.String(maxLength: 36),
                        Url = c.String(maxLength: 200),
                        Iconic = c.String(maxLength: 200),
                        Sort = c.Int(),
                        Remark = c.String(maxLength: 4000),
                        State = c.String(maxLength: 200),
                        CreatePerson = c.String(maxLength: 200),
                        CreateTime = c.DateTime(),
                        UpdateTime = c.DateTime(),
                        UpdatePerson = c.String(maxLength: 200),
                        IsLeaf = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SysMenu", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.SysOperation",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 36),
                        Name = c.String(maxLength: 200),
                        Function = c.String(maxLength: 200),
                        Iconic = c.String(maxLength: 200),
                        Sort = c.Int(),
                        Remark = c.String(maxLength: 4000),
                        State = c.String(maxLength: 200),
                        CreateTime = c.DateTime(),
                        CreatePerson = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SysException",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 36),
                        LeiXing = c.String(maxLength: 200),
                        Message = c.String(maxLength: 4000),
                        Result = c.String(maxLength: 200),
                        Remark = c.String(maxLength: 4000),
                        State = c.String(maxLength: 200),
                        CreateTime = c.DateTime(),
                        CreatePerson = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SysField",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 36),
                        MyTexts = c.String(nullable: false, maxLength: 200),
                        ParentId = c.String(maxLength: 36),
                        MyTables = c.String(maxLength: 200),
                        MyColums = c.String(maxLength: 200),
                        Sort = c.Int(),
                        Remark = c.String(maxLength: 4000),
                        CreateTime = c.DateTime(),
                        CreatePerson = c.String(maxLength: 200),
                        UpdateTime = c.DateTime(),
                        UpdatePerson = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SysField", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.SysLog",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 36),
                        PersonId = c.String(maxLength: 36),
                        Message = c.String(maxLength: 4000),
                        Result = c.String(maxLength: 200),
                        MenuId = c.String(maxLength: 36),
                        Ip = c.String(maxLength: 200),
                        Remark = c.String(maxLength: 4000),
                        State = c.String(maxLength: 200),
                        CreateTime = c.DateTime(),
                        CreatePerson = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SysMenuSysOperation",
                c => new
                    {
                        SysMenuId = c.String(nullable: false, maxLength: 36),
                        SysOperationId = c.String(nullable: false, maxLength: 36),
                    })
                .PrimaryKey(t => new { t.SysMenuId, t.SysOperationId })
                .ForeignKey("dbo.SysMenu", t => t.SysMenuId, cascadeDelete: true)
                .ForeignKey("dbo.SysOperation", t => t.SysOperationId, cascadeDelete: true)
                .Index(t => t.SysMenuId)
                .Index(t => t.SysOperationId);
            
            CreateTable(
                "dbo.SysRoleSysPerson",
                c => new
                    {
                        SysPersonId = c.String(nullable: false, maxLength: 36),
                        SysRoleId = c.String(nullable: false, maxLength: 36),
                    })
                .PrimaryKey(t => new { t.SysPersonId, t.SysRoleId })
                .ForeignKey("dbo.SysPerson", t => t.SysPersonId, cascadeDelete: true)
                .ForeignKey("dbo.SysRole", t => t.SysRoleId, cascadeDelete: true)
                .Index(t => t.SysPersonId)
                .Index(t => t.SysRoleId);
            
            AddColumn("dbo.Article", "ArticleId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUsers", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetRoles", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUserClaims", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Article", "ArticleId");
            AddPrimaryKey("dbo.AspNetUsers", "Id");
            AddPrimaryKey("dbo.AspNetRoles", "Id");
            AddPrimaryKey("dbo.AspNetUserClaims", "Id");
            AddForeignKey("dbo.Article", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            DropColumn("dbo.Article", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Article", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Article", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.SysField", "ParentId", "dbo.SysField");
            DropForeignKey("dbo.SysRoleSysPerson", "SysRoleId", "dbo.SysRole");
            DropForeignKey("dbo.SysRoleSysPerson", "SysPersonId", "dbo.SysPerson");
            DropForeignKey("dbo.SysMenuSysRoleSysOperation", "SysRoleId", "dbo.SysRole");
            DropForeignKey("dbo.SysMenuSysOperation", "SysOperationId", "dbo.SysOperation");
            DropForeignKey("dbo.SysMenuSysOperation", "SysMenuId", "dbo.SysMenu");
            DropForeignKey("dbo.SysMenuSysRoleSysOperation", "SysOperationId", "dbo.SysOperation");
            DropForeignKey("dbo.SysMenuSysRoleSysOperation", "SysMenuId", "dbo.SysMenu");
            DropForeignKey("dbo.SysMenu", "ParentId", "dbo.SysMenu");
            DropForeignKey("dbo.SysPerson", "SysDepartmentId", "dbo.SysDepartment");
            DropForeignKey("dbo.SysDepartment", "ParentId", "dbo.SysDepartment");
            DropIndex("dbo.SysRoleSysPerson", new[] { "SysRoleId" });
            DropIndex("dbo.SysRoleSysPerson", new[] { "SysPersonId" });
            DropIndex("dbo.SysMenuSysOperation", new[] { "SysOperationId" });
            DropIndex("dbo.SysMenuSysOperation", new[] { "SysMenuId" });
            DropIndex("dbo.SysField", new[] { "ParentId" });
            DropIndex("dbo.SysMenu", new[] { "ParentId" });
            DropIndex("dbo.SysMenuSysRoleSysOperation", new[] { "SysRoleId" });
            DropIndex("dbo.SysMenuSysRoleSysOperation", new[] { "SysOperationId" });
            DropIndex("dbo.SysMenuSysRoleSysOperation", new[] { "SysMenuId" });
            DropIndex("dbo.SysPerson", new[] { "SysDepartmentId" });
            DropIndex("dbo.SysDepartment", new[] { "ParentId" });
            DropPrimaryKey("dbo.AspNetUserClaims");
            DropPrimaryKey("dbo.AspNetRoles");
            DropPrimaryKey("dbo.AspNetUsers");
            DropPrimaryKey("dbo.Article");
            AlterColumn("dbo.AspNetUserClaims", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.AspNetRoles", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUsers", "Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Article", "ArticleId");
            DropTable("dbo.SysRoleSysPerson");
            DropTable("dbo.SysMenuSysOperation");
            DropTable("dbo.SysLog");
            DropTable("dbo.SysField");
            DropTable("dbo.SysException");
            DropTable("dbo.SysOperation");
            DropTable("dbo.SysMenu");
            DropTable("dbo.SysMenuSysRoleSysOperation");
            DropTable("dbo.SysRole");
            DropTable("dbo.SysPerson");
            DropTable("dbo.SysDepartment");
            DropTable("dbo.FileUploader");
            AddPrimaryKey("dbo.AspNetUserClaims", "Id");
            AddPrimaryKey("dbo.AspNetRoles", "Id");
            AddPrimaryKey("dbo.AspNetUsers", "Id");
            AddPrimaryKey("dbo.Article", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Article", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
