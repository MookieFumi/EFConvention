namespace EFConvention.CA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reso : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomersAddressesContactPersons", "Address_AddressId", "dbo.CustomersAddresses");
            DropIndex("dbo.CustomersAddressesContactPersons", new[] { "Address_AddressId" });
            RenameColumn(table: "dbo.CustomersAddressesContactPersons", name: "Address_AddressId", newName: "AddressId");
            AlterColumn("dbo.CustomersAddressesContactPersons", "AddressId", c => c.Int(nullable: false));
            CreateIndex("dbo.CustomersAddressesContactPersons", "AddressId");
            AddForeignKey("dbo.CustomersAddressesContactPersons", "AddressId", "dbo.CustomersAddresses", "AddressId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomersAddressesContactPersons", "AddressId", "dbo.CustomersAddresses");
            DropIndex("dbo.CustomersAddressesContactPersons", new[] { "AddressId" });
            AlterColumn("dbo.CustomersAddressesContactPersons", "AddressId", c => c.Int());
            RenameColumn(table: "dbo.CustomersAddressesContactPersons", name: "AddressId", newName: "Address_AddressId");
            CreateIndex("dbo.CustomersAddressesContactPersons", "Address_AddressId");
            AddForeignKey("dbo.CustomersAddressesContactPersons", "Address_AddressId", "dbo.CustomersAddresses", "AddressId");
        }
    }
}
