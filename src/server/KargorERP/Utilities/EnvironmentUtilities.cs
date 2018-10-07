using System;
using System.IO;
using DotNetEnv;

namespace KargorERP.Utilities
{
    public static class EnvironmentUtilities
    {
        public static void LoadEnvironmentFromFile()
        {
            var path = ".env";
            if (File.Exists(path) == false) path = "../../../.env";

            if (File.Exists(path))
            {
                Console.WriteLine($"Found environment file at \"{path}\"");
                DotNetEnv.Env.Load(path);
            }
        }
    }
}