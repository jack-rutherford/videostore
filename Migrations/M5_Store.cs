using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrations
{
    [Migration(5)]
    public class M5_Store : Migration
    {
        public override void Down()
        {
            Delete.Table("Store").InSchema(Names.Schema);
        }

        public override void Up()
        {
            Create.Table("Store")
                  .InSchema(Names.Schema)
                  .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                  .WithColumn("PhoneNumber").AsString(15).Nullable()
                  .WithColumn("StreetAddress").AsString(50).NotNullable();
        }
    }
}
