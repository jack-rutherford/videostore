using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Migrations
{
    [Migration(8)]
    public class M8_CustomerToZipCode : Migration
    {
        public override void Down()
        {
            Delete.ForeignKey("CustomerToZipCode")
                .OnTable("Customer")
                .InSchema(Names.Schema);
            Delete.Column("ZipCode_Id")
                .FromTable("Customer")
                .InSchema(Names.Schema);
        }

        public override void Up()
        {
            Alter.Table("Customer").InSchema(Names.Schema)
                .AddColumn("ZipCode_Id").AsString(50).Nullable();
            Create.ForeignKey("CustomerToZipCode")
                .FromTable("Customer")
                .InSchema(Names.Schema)
                .ForeignColumn("ZipCode_Id")
                .ToTable("ZipCode")
                .InSchema(Names.Schema)
                .PrimaryColumn("Code")
                .OnDelete(System.Data.Rule.SetNull)
                .OnUpdate(System.Data.Rule.Cascade);
        }
    }
}
