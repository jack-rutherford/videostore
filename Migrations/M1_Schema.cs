using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Migrations
{
    [Migration(1)]
    public class M1_Schema : Migration
    {
        public override void Down()
        {
            Delete.Schema(Names.Schema);
        }

        public override void Up()
        {
            Create.Schema(Names.Schema);
        }
    }
}
