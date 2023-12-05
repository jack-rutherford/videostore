using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Migrations
{
    [Migration(10)]
    public class M10_ZipCodeAreaAssociation : Migration
    {
        public override void Down()
        {
            Delete.Table("ZipCodeAreaAssociation").InSchema(Names.Schema);
        }

        public override void Up()
        {
            Create.Table("ZipCodeAreaAssociation").InSchema(Names.Schema)
            .WithColumn("Area_Id").AsInt32().Nullable()
            .WithColumn("ZipCodes").AsInt32().Nullable()
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable();
        }
    }
}
