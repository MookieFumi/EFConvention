namespace EFConvention.CA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_Model : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomersAddressesContactPersons", "AddressId", "dbo.CustomersAddresses");
            DropIndex("dbo.CustomersAddressesContactPersons", new[] { "AddressId" });
            RenameColumn(table: "dbo.CustomersAddressesContactPersons", name: "AddressId", newName: "Address_AddressId");
            AlterColumn("dbo.CustomersAddressesContactPersons", "Address_AddressId", c => c.Int());
            CreateIndex("dbo.CustomersAddressesContactPersons", "Address_AddressId");
            AddForeignKey("dbo.CustomersAddressesContactPersons", "Address_AddressId", "dbo.CustomersAddresses", "AddressId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomersAddressesContactPersons", "Address_AddressId", "dbo.CustomersAddresses");
            DropIndex("dbo.CustomersAddressesContactPersons", new[] { "Address_AddressId" });
            AlterColumn("dbo.CustomersAddressesContactPersons", "Address_AddressId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.CustomersAddressesContactPersons", name: "Address_AddressId", newName: "AddressId");
            CreateIndex("dbo.CustomersAddressesContactPersons", "AddressId");
            AddForeignKey("dbo.CustomersAddressesContactPersons", "AddressId", "dbo.CustomersAddresses", "AddressId", cascadeDelete: true);
        }
    }
}
