using System.Collections.Generic;
using System.IO;
using EulerPoker54.Core;

namespace EulerPoker54.Console
{
    public class RealFileSystem : IFileSystem
    {
        public IEnumerable<string> ReadAllLines(string pokerHandsFile)
        {
            return File.ReadAllLines(pokerHandsFile);
        }
    }
}