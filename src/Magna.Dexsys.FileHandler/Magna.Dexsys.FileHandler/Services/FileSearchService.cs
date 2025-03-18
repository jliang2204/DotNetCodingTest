using Magna.Dexsys.FileHandler.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Magna.Dexsys.FileHandler.Services;
public class FileSearchService
{
    public IReadOnlyList<FileDetails> FilesLocated => _filesLocated.AsReadOnly();

    private readonly List<FileDetails> _filesLocated = [];

    /// <summary>
    /// Populate the instance's FilesLocated member with a collection of
    /// files which contain the partialContent value anywhere in the 
    /// file.
    /// </summary>
    /// <param name="directory">Directory containing files to search</param>
    /// <param name="partialContent">Data to search for in files</param>
    /// <returns>Return the number of files located</returns>
    /// <exception cref="NotImplementedException"></exception>
    public int LocateFilesContainingContent(string directory, string partialContent)
    {
        throw new NotImplementedException();
    }
}
