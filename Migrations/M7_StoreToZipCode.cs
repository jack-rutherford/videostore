using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Migrations
{
    [Migration(7)]
    public class M7_StoreToZipCode : Migration
    {
        public override void Down()
        {
            Delete.ForeignKey("StoreToZipCode").OnTable("Store").InSchema(Names.Schema);
            Delete.Column("ZipCode_Id").FromTable("Store").InSchema(Names.Schema);
        }

        public override void Up()
        {
            //Alter the structure of the Store table to associate a ZipCode with a Store
            Alter.Table("Store")
                .InSchema(Names.Schema)
                .AddColumn("ZipCode_Id").AsString(50).Nullable();
            Create.ForeignKey("StoreToZipCode")
              .FromTable("Store")
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
