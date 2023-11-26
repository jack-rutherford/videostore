using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrations
{
    [Migration(4)]
    public class M4_ZipCode : Migration
    {
        public override void Down()
        {
            Delete.Table("ZipCode").InSchema(Names.Schema);
        }

        public override void Up()
        {
            Create.Table("ZipCode")
                .InSchema(Names.Schema)
                .WithColumn("Code").AsString(50).PrimaryKey().NotNullable()
                .WithColumn("City").AsString(50).Nullable()
                .WithColumn("State").AsString(50).Nullable();
        }
    }
}
