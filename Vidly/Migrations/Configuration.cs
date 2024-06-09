using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Vidly.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Vidly.VidlyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        
        protected override void Seed(Vidly.VidlyDbContext context)
        {
            // Seed initial data if necessary
        }
    }
}