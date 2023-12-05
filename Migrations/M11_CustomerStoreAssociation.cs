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
            Delete.Table("CustomerStoreAssociation").InSchema(Names.Schema);
        }

        public override void Up()
        {
            Create.Table("CustomerStoreAssociation").InSchema(Names.Schema)
            .WithColumn("Customer_Id").AsInt32().Nullable()
            .WithColumn("PreferredStores").AsInt32().Nullable()
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable();
        }
    }
}
