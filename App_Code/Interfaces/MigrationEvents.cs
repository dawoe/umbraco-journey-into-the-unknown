using System;
using System.Linq;

using Semver;

using Umbraco.Core;
using Umbraco.Core.Logging;
using Umbraco.Core.Persistence.Migrations;

/// <summary>
/// Summary description for MigrationEvents
/// </summary>
public class MigrationEvents : ApplicationEventHandler
{
    protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
    {
        SemVersion targetVersion = new SemVersion(1, 0, 0, string.Empty, null); ;
       // RunMigrations(applicationContext, targetVersion);
    }

    private static void RunMigrations(ApplicationContext applicationContext, SemVersion targetVersion)
    {
        var currentVersion = new SemVersion(0, 0, 0);

        var migrations = applicationContext.Services.MigrationEntryService.GetAll("DUUG");

        var latestMigration = migrations.OrderByDescending(x => x.Version).FirstOrDefault();

        if (latestMigration != null)
        {
            currentVersion = latestMigration.Version;
        }

        targetVersion = new SemVersion(2, 0, 0, string.Empty, null);

        if (targetVersion == currentVersion)
        {
            // we are up to date
            return;
        }

        var migrationsRunner = new MigrationRunner(
            applicationContext.Services.MigrationEntryService,
            applicationContext.ProfilingLogger.Logger,
            currentVersion,
            targetVersion,
            "DUUG");

        try
        {
            migrationsRunner.Execute(applicationContext.DatabaseContext.Database);
        }
        catch (Exception e)
        {
            // we catch all other errors
            LogHelper.Error<MigrationEvents>("Error running migrations", e);
        }
    }
}