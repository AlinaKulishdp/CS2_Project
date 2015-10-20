namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        EditTime = c.DateTime(nullable: false),
                        Operator_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Operator_Id)
                .Index(t => t.Operator_Id);
            
            CreateTable(
                "dbo.Goods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SKU = c.String(),
                        Price = c.Double(nullable: false),
                        Count = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        EditTime = c.DateTime(nullable: false),
                        Category_Id = c.Int(),
                        Operator_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategories", t => t.Category_Id)
                .ForeignKey("dbo.Users", t => t.Operator_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Operator_Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        Type = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        EditTime = c.DateTime(nullable: false),
                        Operator_Id = c.Int(),
                        Goods_Id = c.Int(),
                        Customer_Id = c.Int(),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Operator_Id)
                .ForeignKey("dbo.Goods", t => t.Goods_Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Operator_Id)
                .Index(t => t.Goods_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Login = c.String(),
                        Password = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        EditTime = c.DateTime(nullable: false),
                        Operator_Id = c.Int(),
                        PersonalInfo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Operator_Id)
                .ForeignKey("dbo.PersonalInfoes", t => t.PersonalInfo_Id)
                .ForeignKey("dbo.Roles", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.Operator_Id)
                .Index(t => t.PersonalInfo_Id);
            
            CreateTable(
                "dbo.PersonalInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsActive = c.Boolean(nullable: false),
                        EditTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsActive = c.Boolean(nullable: false),
                        EditTime = c.DateTime(nullable: false),
                        Operator_Id = c.Int(),
                        Role_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Operator_Id)
                .ForeignKey("dbo.Roles", t => t.Role_Id)
                .Index(t => t.Operator_Id)
                .Index(t => t.Role_Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsActive = c.Boolean(nullable: false),
                        EditTime = c.DateTime(nullable: false),
                        Contacts_Id = c.Int(),
                        Operator_Id = c.Int(),
                        PersonalInfo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContactInfoes", t => t.Contacts_Id)
                .ForeignKey("dbo.Users", t => t.Operator_Id)
                .ForeignKey("dbo.PersonalInfoes", t => t.PersonalInfo_Id)
                .Index(t => t.Contacts_Id)
                .Index(t => t.Operator_Id)
                .Index(t => t.PersonalInfo_Id);
            
            CreateTable(
                "dbo.ContactInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(),
                        Adress = c.String(),
                        Telephone = c.String(),
                        Email = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        EditTime = c.DateTime(nullable: false),
                        Operator_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Operator_Id)
                .Index(t => t.Operator_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalCost = c.Double(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        EditTime = c.DateTime(nullable: false),
                        Customer_Id = c.Int(),
                        Operator_Id = c.Int(),
                        Status_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.Users", t => t.Operator_Id)
                .ForeignKey("dbo.OrderStatus", t => t.Status_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Operator_Id)
                .Index(t => t.Status_Id);
            
            CreateTable(
                "dbo.GoodsRows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Count = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        EditTime = c.DateTime(nullable: false),
                        Goods_Id = c.Int(),
                        Operator_Id = c.Int(),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Goods", t => t.Goods_Id)
                .ForeignKey("dbo.Users", t => t.Operator_Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Goods_Id)
                .Index(t => t.Operator_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        EditTime = c.DateTime(nullable: false),
                        Operator_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Operator_Id)
                .Index(t => t.Operator_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "PersonalInfo_Id", "dbo.PersonalInfoes");
            DropForeignKey("dbo.Orders", "Status_Id", "dbo.OrderStatus");
            DropForeignKey("dbo.OrderStatus", "Operator_Id", "dbo.Users");
            DropForeignKey("dbo.Orders", "Operator_Id", "dbo.Users");
            DropForeignKey("dbo.GoodsRows", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.GoodsRows", "Operator_Id", "dbo.Users");
            DropForeignKey("dbo.GoodsRows", "Goods_Id", "dbo.Goods");
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Comments", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Customers", "Operator_Id", "dbo.Users");
            DropForeignKey("dbo.Customers", "Contacts_Id", "dbo.ContactInfoes");
            DropForeignKey("dbo.ContactInfoes", "Operator_Id", "dbo.Users");
            DropForeignKey("dbo.Comments", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.ProductCategories", "Operator_Id", "dbo.Users");
            DropForeignKey("dbo.Goods", "Operator_Id", "dbo.Users");
            DropForeignKey("dbo.Comments", "Goods_Id", "dbo.Goods");
            DropForeignKey("dbo.Comments", "Operator_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Id", "dbo.Roles");
            DropForeignKey("dbo.Permissions", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.Permissions", "Operator_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "PersonalInfo_Id", "dbo.PersonalInfoes");
            DropForeignKey("dbo.Users", "Operator_Id", "dbo.Users");
            DropForeignKey("dbo.Goods", "Category_Id", "dbo.ProductCategories");
            DropIndex("dbo.OrderStatus", new[] { "Operator_Id" });
            DropIndex("dbo.GoodsRows", new[] { "Order_Id" });
            DropIndex("dbo.GoodsRows", new[] { "Operator_Id" });
            DropIndex("dbo.GoodsRows", new[] { "Goods_Id" });
            DropIndex("dbo.Orders", new[] { "Status_Id" });
            DropIndex("dbo.Orders", new[] { "Operator_Id" });
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            DropIndex("dbo.ContactInfoes", new[] { "Operator_Id" });
            DropIndex("dbo.Customers", new[] { "PersonalInfo_Id" });
            DropIndex("dbo.Customers", new[] { "Operator_Id" });
            DropIndex("dbo.Customers", new[] { "Contacts_Id" });
            DropIndex("dbo.Permissions", new[] { "Role_Id" });
            DropIndex("dbo.Permissions", new[] { "Operator_Id" });
            DropIndex("dbo.Users", new[] { "PersonalInfo_Id" });
            DropIndex("dbo.Users", new[] { "Operator_Id" });
            DropIndex("dbo.Users", new[] { "Id" });
            DropIndex("dbo.Comments", new[] { "Order_Id" });
            DropIndex("dbo.Comments", new[] { "Customer_Id" });
            DropIndex("dbo.Comments", new[] { "Goods_Id" });
            DropIndex("dbo.Comments", new[] { "Operator_Id" });
            DropIndex("dbo.Goods", new[] { "Operator_Id" });
            DropIndex("dbo.Goods", new[] { "Category_Id" });
            DropIndex("dbo.ProductCategories", new[] { "Operator_Id" });
            DropTable("dbo.OrderStatus");
            DropTable("dbo.GoodsRows");
            DropTable("dbo.Orders");
            DropTable("dbo.ContactInfoes");
            DropTable("dbo.Customers");
            DropTable("dbo.Permissions");
            DropTable("dbo.Roles");
            DropTable("dbo.PersonalInfoes");
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
            DropTable("dbo.Goods");
            DropTable("dbo.ProductCategories");
        }
    }
}
