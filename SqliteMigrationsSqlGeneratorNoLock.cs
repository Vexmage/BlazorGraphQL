using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Sqlite.Migrations;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Infrastructure;

public class SqliteMigrationsSqlGeneratorNoLock : SqliteMigrationsSqlGenerator
{
    public SqliteMigrationsSqlGeneratorNoLock(
        MigrationsSqlGeneratorDependencies dependencies,
        IRelationalAnnotationProvider relationalAnnotationProvider)
        : base(dependencies, relationalAnnotationProvider)
    {
    }

    protected override void Generate(
        CreateTableOperation operation,
        IModel? model,
        MigrationCommandListBuilder builder,
        bool terminate)
    {
        if (operation.Name == "__EFMigrationsLock")
        {
            return; // Skip creating the lock table
        }

        base.Generate(operation, model, builder, terminate);
    }
}
