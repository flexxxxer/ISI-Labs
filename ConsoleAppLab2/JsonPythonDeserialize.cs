using System.Diagnostics;

namespace ConsoleAppLab2
{
    public static class JsonPythonDeserialize
    {
        public static void Run()
        {
            var psi = new ProcessStartInfo()
            {
                WorkingDirectory = "Assets",
                Arguments = "customjsonoperations.py",
                FileName = "python3",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                CreateNoWindow = true
            };

            var process = Process.Start(psi);
            process!.WaitForExit();
            
            string output = process.StandardOutput.ReadToEnd();
            Console.WriteLine(output);
        }
    }
}
