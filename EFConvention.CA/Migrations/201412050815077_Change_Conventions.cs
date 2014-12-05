namespace EFConvention.CA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_Conventions : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addresses", "FullAddress", c => c.String(maxLength: 450));
            AlterColumn("dbo.Customers", "FirstName", c => c.String(maxLength: 150));
            AlterColumn("dbo.Customers", "LastName", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "LastName", c => c.String());
            AlterColumn("dbo.Customers", "FirstName", c => c.String());
            AlterColumn("dbo.Addresses", "FullAddress", c => c.String());
        }
    }
}
