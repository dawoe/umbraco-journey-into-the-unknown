using System;

using Umbraco.Core.Logging;
using Umbraco.Core.Persistence.Migrations;
using Umbraco.Core.Persistence.SqlSyntax;

[Migration("1.0.0", 1, "DUUG")]
public class CreateDuugFestTable : MigrationBase
{
   
    public CreateDuugFestTable(ISqlSyntaxProvider sqlSyntax, ILogger logger)
        : base(sqlSyntax, logger)
    {
    }

    public override void Up()
    {
        this.Create.Table("DuugFestAttendee")
            .WithColumn("Id").AsInt32().Identity().PrimaryKey("PK_DuugFestAttendee")
            .WithColumn("Name").AsString(100).NotNullable()
            .WithColumn("HasRunV5").AsBoolean();
    }

    public override void Down()
    {
       
    }
}