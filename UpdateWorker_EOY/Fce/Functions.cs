using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace UpdateWorker_EOY.Fce
{
    public class Functions
    {
        public static void DeleteMigration()
        {
            var migrationDirectory = Path.Combine(PathDrivers());

            if (Directory.Exists(migrationDirectory))
            {
                var migrationFiles = Directory.GetFiles(migrationDirectory, "*.cs")
                            .Where(file => !file.EndsWith("EoyDbContextModelSnapshot.cs"))
                            .ToList();
                if (migrationFiles.Count <= 4)
                {
                    Console.WriteLine("Máte méně než dvě migrační soubory. Nic nebude smazáno.");
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    migrationFiles.Sort((a, b) => File.GetCreationTime(b).CompareTo(File.GetCreationTime(a)));

                    var migracjeToDelete = migrationFiles.Skip(4);


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
        public static string PathDrivers()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            
            var lookingPath = $"{path}\\EOY API\\Migrations";
    ;
            DriveInfo[] disky = DriveInfo.GetDrives();
            foreach (DriveInfo disk in disky)
            {
                if (disk.IsReady)
                {
                    path = FindPathDriver(disk.Name, lookingPath);
                }

            }
            return path;
        }

        private static string FindPathDriver(string disk, string lookingPath)
        {

            var file = "";

            try
            {
                string[] slozky = Directory.GetDirectories(disk, "*"); //tady to spadne do catch


                foreach (string slozka in slozky)
                {
                    if (string.Equals(slozka, Path.Combine(disk, "Documents and Settings"), StringComparison.OrdinalIgnoreCase))
                        continue;

                    try
                    {
                        if (slozka.Contains(lookingPath))
                        {
                            Console.WriteLine($"Adresa složky {lookingPath} byla nalezena {slozka}");
                            file = $"{disk}:{slozka}";
                        }
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        Console.WriteLine($"Nemáte oprávnění přistoupit k některým složkám na disku {disk}: {ex.Message}");
                        continue;
                    }
                }

                return file;
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Nemáte oprávnění přistoupit k některým složkám na disku {disk}: {ex.Message}");
                return file;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Nastala chyba při hledání na disku {disk}: {ex.Message}");
                return file;
            }



        }
    }

}