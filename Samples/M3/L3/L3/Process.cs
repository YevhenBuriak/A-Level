using System.Diagnostics;

namespace L3;

// https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.process?view=net-7.0

internal static class ProcessSmaples
{
    public static void Execute()
    {
        using var process = new Process();

        process.StartInfo.FileName = "powershell.exe";
        process.StartInfo.RedirectStandardInput = true;
        process.StartInfo.RedirectStandardOutput = true;
        process.Start();

        _ = process.Id;
        _ = process.MachineName;

        // Write data to the standard input of the process
        using var writer = process.StandardInput;
        writer.WriteLine("Get-ComputerInfo");



        // Wait for the process to exit
        process.WaitForExit();

        // Display the exit code
        Console.WriteLine("Notepad exited with code: " + process.ExitCode);
    }
}
