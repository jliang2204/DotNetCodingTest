using Magna.Dexsys.FileHandler.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
using System.Linq;
using System.Net.Mime;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Magna.Dexsys.FileHandler.Services;
public class FileSearchService {
    public IReadOnlyList<FileDetails> FilesLocated => _filesLocated.AsReadOnly();

    private readonly List<FileDetails> _filesLocated = [];

    /// <summary>
    /// Populate the instance's FilesLocated member with a collection of
    /// files which contain the partialContent value anywhere in the 
    /// file.
    /// </summary>
    /// <param name="directory">Directory containing files to search</param>
    /// <param name="searchValue">Data to search for in files</param>
    /// <returns>Return the number of files located</returns>
    /// <exception cref="NotImplementedException"></exception>
    public int LocateFilesContainingSearchValue(string directory, string searchValue) {
        _filesLocated.Clear();
        List<FileDetails> localFilesLocated = [];
        try {
            Parallel.ForEach(Directory.EnumerateFiles(directory), (filePath) => { 
                string content = File.ReadAllText(filePath);
                if(content.Contains(searchValue)) {
                    lock(localFilesLocated) {
                        localFilesLocated.Add(new FileDetails(filePath, Path.GetFileName(filePath), content.Length, content));
                    }
                }
              });
              
              lock(_filesLocated) {
                _filesLocated.AddRange(localFilesLocated);
              }

            
        } catch(Exception e) {
            throw new IOException("Error", e);
        }

        return _filesLocated.Count;
    }
}
