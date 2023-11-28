using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Migrations
{
    [Migration(9)]
    public class M9_VideoToStore : Migration
    {
       public override void Down()
        {
            Delete.ForeignKey("VideoToStore").OnTable("Video").InSchema(Names.Schema);
            Delete.Column("Store_Id").FromTable("Video").InSchema(Names.Schema);
        }

        public override void Up()
        {
            Alter.Table("Video")
                .InSchema(Names.Schema)
                .AddColumn("Store_Id").AsInt32().Nullable();
            Create.ForeignKey("VideoToStore")
                .FromTable("Video")
                .InSchema(Names.Schema)
                .ForeignColumn("Store_Id")
                .ToTable("Store")
                .InSchema(Names.Schema)
                .PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.SetNull)
                .OnUpdate(System.Data.Rule.Cascade);
        }
    }
}
