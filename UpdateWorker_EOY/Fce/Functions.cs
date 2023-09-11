using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateWorker_EOY.Fce
{
    public class Functions
    {
        public static void DeleteMigration(string pathApi)
        {
            var migrationDirectory = Path.Combine(pathApi, "Migrations");

            if (Directory.Exists(migrationDirectory))
            {
                var migrationFiles = Directory.GetFiles(migrationDirectory, "*.cs")
              .Where(file => !file.EndsWith(".Designer.cs"))
              .ToList();
                if (migrationFiles.Count <= 2)
                {
                    Console.WriteLine("Máte méně než dvě migrační soubory. Nic nebude smazáno.");
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    var migrationFile = Directory.GetFiles(migrationDirectory, "*.cs")
                            .Where(file => !file.EndsWith(".Designer.cs"))
                            .ToList();

                    // Seřaďte migrace podle data vytvoření (nejnovější první)
                    migrationFile.Sort((a, b) => File.GetCreationTime(b).CompareTo(File.GetCreationTime(a)));

                    // Ponechte pouze tři nejnovější migrace
                    var migracjeToDelete = migrationFile.Skip(2);

                    // Odstraňte staré migrace
                    foreach (var migrationToDelete in migracjeToDelete)
                    {
                        File.Delete(migrationToDelete);
                        Console.WriteLine($"Migrace smazána: {migrationToDelete}");
                    }

                    Console.WriteLine("Operace dokončena.");
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Složka migrací nebyla nalezena.");
            }
        }

    }

}

