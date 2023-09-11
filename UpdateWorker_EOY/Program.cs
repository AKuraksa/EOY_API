using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UpdateWorker_EOY.Fce;

using static System.Net.Mime.MediaTypeNames;

class Program
{
   
    static async Task Main()
    {

      


        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("UpgradeWorker se spouští");
        var adress = AppDomain.CurrentDomain.BaseDirectory;
        var workingDirectory = Functions.PathDrivers();



        var command = "cmd.exe";
        var argumentsMIG = $"/C dotnet ef migrations add {Guid.NewGuid()}";
        var argumentsUPDATE = $"/C dotnet ef database update";



        var processMigration = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = command,
                Arguments = argumentsMIG,
                WorkingDirectory = workingDirectory,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };
      
       
        var processUpdate = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = command,
                Arguments = argumentsUPDATE,
                WorkingDirectory = workingDirectory,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };

      
        
        processMigration.Start();
        var loadingMIGThread = new Thread(() =>
        {   Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Vytváření migrace");
            while (!processMigration.HasExited)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        });
        loadingMIGThread.Start();
        var migrationOutput = processMigration.StandardOutput.ReadToEnd();
        var migrationError = processMigration.StandardError.ReadToEnd();
        processMigration.WaitForExit();
        loadingMIGThread.Join();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Výstup migrace:");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(migrationOutput);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Chyby migrace:");
        if (migrationError == "")
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Žádná chyba");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(migrationError);
        }

        processUpdate.Start();
        var loadingThread = new Thread(() =>
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Aktualizace databáze");
            while (!processUpdate.HasExited)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        });
        loadingThread.Start();

        var updateOutput = processUpdate.StandardOutput.ReadToEnd();
        var updateError = processUpdate.StandardError.ReadToEnd();
        processUpdate.WaitForExit();
        loadingThread.Join();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Výstup aktualizace databáze:");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(updateOutput);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Chyby aktualizace databáze:");
        if (migrationError == "")
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Žádná chyba");
            Functions.DeleteMigration();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(updateError);

        }
      
    } 
}