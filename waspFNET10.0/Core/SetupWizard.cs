using System;
using WASP.Config;

namespace WASP.Core
{
    static class SetupWizard
    {
        public static void Run()
        {
            Console.WriteLine("=== WASP SETUP WIZARD ===");
            Console.WriteLine("This runs only once.");

            var cfg = new WaspConfig();

            cfg.SafeMode = AskYesNo("Enable Safe Mode (recommended)?");
            cfg.HashDlls = AskYesNo("Enable DLL hash protection?");
            cfg.Verbose  = AskYesNo("Enable verbose logging?");

            ConfigManager.Save(cfg);

            Console.WriteLine("[OK] Setup complete!");
            Console.WriteLine("Restart WASP to continue...");
        }

        static bool AskYesNo(string question)
        {
            while (true)
            {
                Console.Write($"{question} [Y/N]: ");
                var key = Console.ReadKey().Key;
                Console.WriteLine();

                if (key == ConsoleKey.Y) return true;
                if (key == ConsoleKey.N) return false;
            }
        }
    }
}
