using Magna.Dexsys.FileHandler.Models;
using Magna.Dexsys.FileHandler.Services;
using System.Diagnostics;

namespace Magna.Dexsys.FileHandler.Cli;

public class Program
{
    private const string fileLocation = "C:\\temp\\generatedFiles";
    private const string searchValue = "OLD";

    public static void Main(string[] args)
    {
        int testCount = 0;
        int testLimit = 10;

        for (; testCount >= 0; testLimit++)
        {
            Test(searchValue);
        }

        Console.ReadLine();
    }

    private static void Test(string searchValue)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        FileSearchService searchService = new();
        searchService.LocateFilesContainingSearchValue(fileLocation, searchValue);
        
        foreach (FileDetails item in searchService.FilesLocated)
        {
            Console.WriteLine(item.Name, item.Content);
        }

        Console.WriteLine($"Completed in {stopwatch.ElapsedMilliseconds}");
    }
}
