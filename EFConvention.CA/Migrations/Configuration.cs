using System.Collections.ObjectModel;
using EFConvention.CA.Model.Entities;

namespace EFConvention.CA.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EFConvention.CA.Model.EFConventionContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "EFConvention.CA.Model.EFConventionContext";
        }

        protected override void Seed(EFConvention.CA.Model.EFConventionContext context)
        {
        }
    }
}
