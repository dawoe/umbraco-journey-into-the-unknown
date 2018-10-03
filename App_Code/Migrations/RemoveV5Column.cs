using System;

using Umbraco.Core;
using Umbraco.Core.Logging;
using Umbraco.Core.Persistence.Migrations;
using Umbraco.Core.Persistence.SqlSyntax;

//[Migration("2.0.0", 1, "DUUG")]
//public class RemoveV5Column : MigrationBase
//{
//    public RemoveV5Column(ISqlSyntaxProvider sqlSyntax, ILogger logger)
//        : base(sqlSyntax, logger)
//    {
//    }

//    public override void Up()
//    {
//        this.Delete.Column("HasRunV5").FromTable("DuugFestAttendee");        
//    }

//    public override void Down()
//    {

//    }
//}