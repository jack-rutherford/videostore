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
            Delete.ForeignKey("FK_ZipCodeAreaAssociation_ZipCode_Id")
                .OnTable("ZipCodeAreaAssociation")
                .InSchema(Names.Schema);
            Delete.ForeignKey("FK_ZipCodeAreaAssociation_Area_Id")
                .OnTable("ZipCodeAreaAssociation")
                .InSchema(Names.Schema);
            Delete.Table("ZipCodeAreaAssociation")
                .InSchema(Names.Schema);
        }

        public override void Up()
        {
            Create.Table("ZipCodeAreaAssociation").InSchema(Names.Schema)
                .WithColumn("ZipCode_Id").AsString(50).NotNullable()
                .WithColumn("Area_Id").AsInt32().NotNullable();

            Create.ForeignKey("FK_ZipCodeAreaAssociation_ZipCode_Id")
                .FromTable("ZipCodeAreaAssociation")
                .InSchema(Names.Schema)
                .ForeignColumn("ZipCode_Id")
                .ToTable("ZipCode")
                .InSchema(Names.Schema)
                .PrimaryColumn("Code");

            Create.ForeignKey("FK_ZipCodeAreaAssociation_Area_Id")
                .FromTable("ZipCodeAreaAssociation")
                .InSchema(Names.Schema)
                .ForeignColumn("Area_Id")
                .ToTable("Area")
                .InSchema(Names.Schema)
                .PrimaryColumn("Id");
        }
    }
}
