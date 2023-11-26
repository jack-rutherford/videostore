using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrations
{
    [Migration(6)]
    public class M6_Area : Migration
    {         
        public override void Down()
        {
            Delete.Table("Area").InSchema(Names.Schema);
        }

        public override void Up()
        {
            Create.Table("Area")
                .InSchema(Names.Schema)
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Name").AsString(50).NotNullable();
                //.WithColumn("StoreId").AsInt32().ForeignKey("FK_Area_Store", Names.Schema, "Store", "Id").NotNullable();
        }

    }
}
