using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Migrations
{
    [Migration(3)]
    public class M3_Video : Migration
    {
        public override void Down()
        {
            Delete.Table("Video").InSchema(Names.Schema);
        }

        public override void Up()
        {
            Create.Table("Video")
                  .InSchema(Names.Schema)
                  .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                  .WithColumn("PurchaseDate").AsDateTime().Nullable()
                  .WithColumn("NewArrival").AsBoolean().NotNullable();
               
        }
    }
}
