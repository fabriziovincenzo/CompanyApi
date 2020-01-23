namespace CompanyApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address1 = c.String(nullable: false),
                        Locality = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Tva = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Tva = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.PersonCompany",
                c => new
                    {
                        Person_Id = c.Int(nullable: false),
                        Company_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_Id, t.Company_Id })
                .ForeignKey("dbo.Person", t => t.Person_Id, cascadeDelete: true)
                .ForeignKey("dbo.Company", t => t.Company_Id, cascadeDelete: true)
                .Index(t => t.Person_Id)
                .Index(t => t.Company_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonCompany", "Company_Id", "dbo.Company");
            DropForeignKey("dbo.PersonCompany", "Person_Id", "dbo.Person");
            DropForeignKey("dbo.Person", "Id", "dbo.Address");
            DropForeignKey("dbo.Company", "Id", "dbo.Address");
            DropIndex("dbo.PersonCompany", new[] { "Company_Id" });
            DropIndex("dbo.PersonCompany", new[] { "Person_Id" });
            DropIndex("dbo.Person", new[] { "Id" });
            DropIndex("dbo.Company", new[] { "Id" });
            DropTable("dbo.PersonCompany");
            DropTable("dbo.Person");
            DropTable("dbo.Company");
            DropTable("dbo.Address");
        }
    }
}
