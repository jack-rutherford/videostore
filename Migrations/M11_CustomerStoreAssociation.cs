using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Migrations
{
    [Migration(11)]
    public class M11_CustomerStoreAssociation : Migration
    {
        public override void Down()
        {
            Delete.ForeignKey("FK_CustomerStoreAssociation_Customer_Id")
                .OnTable("CustomerStoreAssociation")
                .InSchema(Names.Schema);
            Delete.ForeignKey("FK_CustomerStoreAssociation_Store_Id")
                .OnTable("CustomerStoreAssociation")
                .InSchema(Names.Schema);
            Delete.Table("CustomerStoreAssociation")
                .InSchema(Names.Schema);
        }

        public override void Up()
        {
            Create.Table("CustomerStoreAssociation").InSchema(Names.Schema)
                .WithColumn("Customer_Id").AsInt32().NotNullable()
                .WithColumn("Store_Id").AsInt32().NotNullable();

            Create.ForeignKey("FK_CustomerStoreAssociation_Customer_Id")
                .FromTable("CustomerStoreAssociation")
                .InSchema(Names.Schema)
                .ForeignColumn("Customer_Id")
                .ToTable("Customer")
                .InSchema(Names.Schema)
                .PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.SetNull)
                .OnUpdate(System.Data.Rule.Cascade);

            Create.ForeignKey("FK_CustomerStoreAssociation_Store_Id")
                .FromTable("CustomerStoreAssociation")
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
