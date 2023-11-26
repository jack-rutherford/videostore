using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Migrations
{
    [Migration(2)]
    public class M2_Customer : Migration
    {
        public override void Down()
        {
            Delete.Table("Customer").InSchema(Names.Schema);
        }

        public override void Up()
        {
            Create.Table("Customer")
                .InSchema(Names.Schema)
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("First").AsString(50).NotNullable()
                .WithColumn("Last").AsString(50).NotNullable()
                .WithColumn("Title").AsString(50)
                .WithColumn("Middle").AsString(50)
                .WithColumn("Suffix").AsString(50)
                .WithColumn("EmailAddress").AsString(50).NotNullable()
                .WithColumn("Phone").AsString(50)
                .WithColumn("StreetAddress").AsString(50)
                .WithColumn("City").AsString(50)
                .WithColumn("State").AsString(50)
                .WithColumn("Password").AsString(50);
        }
    }
}
