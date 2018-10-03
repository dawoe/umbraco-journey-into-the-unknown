using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Umbraco.Core;
using Umbraco.Core.Logging;
using Umbraco.Core.Persistence.Migrations;
using Umbraco.Core.Persistence.SqlSyntax;

//[Migration("2.0.0", 2, "DUUG")]

//public class CreateContent : MigrationBase
//{
   
//    public override void Up()
//    {
//        var contentService = ApplicationContext.Current.Services.ContentService;

//        var content = contentService.CreateContent("From Mirgration", 1106, "contentPage", 0);
//        content.SetValue("pageTitle", "Created from migration");
//        contentService.Save(content);
//    }

//    public override void Down()
//    {        
//    }

//    public CreateContent(ISqlSyntaxProvider sqlSyntax, ILogger logger)
//        : base(sqlSyntax, logger)
//    {
//    }
//}