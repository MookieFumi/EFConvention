namespace EFConvention.CA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Contact_Person_Entity : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Addresses", newName: "CustomersAddresses");
            CreateTable(
                "dbo.CustomersAddressesContactPersons",
                c => new
                    {
                        ContactPersonId = c.Int(nullable: false, identity: true),
                        AddressId = c.Int(nullable: false),
                        Name = c.String(maxLength: 150),
                        Departament = c.String(),
                    })
                .PrimaryKey(t => t.ContactPersonId)
                .ForeignKey("dbo.CustomersAddresses", t => t.AddressId, cascadeDelete: true)
                .Index(t => t.AddressId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomersAddressesContactPersons", "AddressId", "dbo.CustomersAddresses");
            DropIndex("dbo.CustomersAddressesContactPersons", new[] { "AddressId" });
            DropTable("dbo.CustomersAddressesContactPersons");
            RenameTable(name: "dbo.CustomersAddresses", newName: "Addresses");
        }
    }
}
