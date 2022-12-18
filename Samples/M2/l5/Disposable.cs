namespace L5;

// Unmanaged resources: https://stackoverflow.com/questions/3433197/what-exactly-are-unmanaged-resources
// IDisposable: https://learn.microsoft.com/en-us/dotnet/api/system.idisposable?view=net-7.0
// Finalization: https://www.youtube.com/watch?v=6_Upud25iFQ
// FileStream Examples: https://zetcode.com/csharp/filestream/

internal static class Disposable
{
    public static void Execute()
    {
        var path = @"C:\Users\Eugene\Downloads\txt.txt";

        var fileReader = new FileRead();
        fileReader.ReadFromFile(path);

        // !!
        var disposable = new MyDisposable(path);
        disposable.FileStream.Dispose();
    }

    public class FileRead
    {
        public void ReadFromFile(string path)
        {
            using var fs = File.OpenRead(path);
            using var sr = new StreamReader(fs);

            string line;

            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }

    public class MyDisposable
    {
        private string _path;
        public FileStream FileStream => File.OpenRead(_path);
        public MyDisposable(string path) => _path = path;
    }
}
