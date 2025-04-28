using System.Diagnostics;
using BuyingTypeService.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


var argsList = args.ToList();

var baseConfiguration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var environment = baseConfiguration["Environment"] ?? "Development";

var envIndex = argsList.FindIndex(a => a.Equals("--environment", StringComparison.OrdinalIgnoreCase));
if (envIndex >= 0 && envIndex + 1 < argsList.Count)
{
    environment = argsList[envIndex + 1];
    argsList.RemoveAt(envIndex + 1); 
    argsList.RemoveAt(envIndex);  
}

Console.WriteLine($"Running in {environment} environment...");

// Ortama göre config yükle
var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{environment}.json", optional: true)
    .Build();

var serviceCollection = new ServiceCollection();


var serviceProvider = serviceCollection.BuildServiceProvider();


if (!argsList.Any())
{
    ShowUsage();
    return;
}

var command = argsList[0];

switch (command.ToLower())
{
    case "add-migration":
        if (argsList.Count < 2)
        {
            Console.WriteLine("Migration name is required. Usage: add-migration {MigrationName}");
            return;
        }
        var migrationName = argsList[1];
        AddMigration(migrationName);
        break;

    case "update-database":
        UpdateDatabase();
        break;

    case "list-migrations":
        ListMigrations();
        break;

    case "remove-migration":
        RemoveMigration();
        break;

    case "reset-database":
        ResetDatabase();
        break;

    case "drop-database":
        DropDatabase();
        break;

    case "script-migrations":
        ScriptMigrations();
        break;

    default:
        Console.WriteLine($"Unknown command: {command}");
        ShowUsage();
        break;
}

bool AskForConfirmation(string message)
{
    Console.Write($"{message} (y/n): ");
    var key = Console.ReadKey();
    Console.WriteLine();
    return key.Key == ConsoleKey.Y;
}


void ShowUsage()
{
    Console.WriteLine("Available commands:");
    Console.WriteLine(" - add-migration {MigrationName}");
    Console.WriteLine(" - update-database");
    Console.WriteLine(" - drop-database");
    Console.WriteLine(" - script-migrations");
}

void ListMigrations()
{
    using var scope = serviceProvider.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<BuyingTypeDbContext>();

    var migrations = dbContext.Database.GetAppliedMigrations();

    Console.WriteLine("Applied Migrations:");
    foreach (var migration in migrations)
    {
        Console.WriteLine($" - {migration}");
    }
}

void RemoveMigration()
{
    if (!AskForConfirmation("Are you sure you want to REMOVE the last migration?"))
    {
        Console.WriteLine("Cancelled.");
        return;
    }

    Console.WriteLine("Removing last migration...");

    var workingDirectory = Path.Combine(AppContext.BaseDirectory, "../../../../../");
    workingDirectory = Path.GetFullPath(workingDirectory);

    var process = new Process
    {
        StartInfo = new ProcessStartInfo
        {
            FileName = "dotnet",
            Arguments = "ef migrations remove --project src/Services/BuyingTypeService/BuyingTypeService.Persistence/BuyingTypeService.Persistence.csproj --startup-project src/Services/BuyingTypeService/BuyingTypeService.Migrator/BuyingTypeService.Migrator.csproj",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true,
            WorkingDirectory = workingDirectory
        }
    };

    process.Start();

    string output = process.StandardOutput.ReadToEnd();
    string errors = process.StandardError.ReadToEnd();

    process.WaitForExit();

    Console.WriteLine(output);

    if (!string.IsNullOrWhiteSpace(errors))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(errors);
        Console.ResetColor();
    }

    Console.WriteLine("Last migration removed (if possible).");
}


void ResetDatabase()
{
    if (!AskForConfirmation("Are you sure you want to RESET the database? This will drop all data!"))
    {
        Console.WriteLine("Cancelled.");
        return;
    }

    Console.WriteLine("Resetting database...");
    DropDatabase();
    UpdateDatabase();
    Console.WriteLine("Database reset and updated with latest migrations.");
}



void AddMigration(string migrationName)
{
    Console.WriteLine($"Adding migration '{migrationName}'...");

    var workingDirectory = Path.Combine(AppContext.BaseDirectory, "../../../../../");
    workingDirectory = Path.GetFullPath(workingDirectory);

    var process = new Process
    {
        StartInfo = new ProcessStartInfo
        {
            FileName = "dotnet",
            Arguments = $"ef migrations add {migrationName} --project src/Services/BuyingTypeService/BuyingTypeService.Persistence/BuyingTypeService.Persistence.csproj --startup-project src/Services/BuyingTypeService/BuyingTypeService.Migrator/BuyingTypeService.Migrator.csproj",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true,
            WorkingDirectory = workingDirectory // ✅ Çalışma dizinini solution root yapıyoruz!
        }
    };

    process.Start();

    string output = process.StandardOutput.ReadToEnd();
    string errors = process.StandardError.ReadToEnd();

    process.WaitForExit();

    Console.WriteLine(output);

    if (!string.IsNullOrWhiteSpace(errors))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(errors);
        Console.ResetColor();
    }

    Console.WriteLine($"Migration '{migrationName}' created successfully!");
}

void UpdateDatabase()
{
    using var scope = serviceProvider.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<BuyingTypeDbContext>();
    Console.WriteLine("Applying pending migrations...");
    dbContext.Database.Migrate();
    Console.WriteLine("Database updated successfully!");
}

void DropDatabase()
{
    if (!AskForConfirmation("Are you sure you want to DROP the database?"))
    {
        Console.WriteLine("Cancelled.");
        return;
    }

    using var scope = serviceProvider.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<BuyingTypeDbContext>();
    Console.WriteLine("Dropping database...");
    dbContext.Database.EnsureDeleted();
    Console.WriteLine("Database dropped successfully!");
}


void ScriptMigrations()
{
    using var scope = serviceProvider.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<BuyingTypeDbContext>();
    Console.WriteLine("Generating migration script...");
    var sqlScript = dbContext.Database.GenerateCreateScript();
    var outputPath = Path.Combine(AppContext.BaseDirectory, "MigrationScript.sql");
    File.WriteAllText(outputPath, sqlScript);
    Console.WriteLine($"Migration script written to {outputPath}");
}

