namespace EFConvention.CA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove_City_Property_From_Address : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CustomersAddresses", "City");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomersAddresses", "City", c => c.String());
        }
    }
}
