using System.Collections.Generic;

namespace EulerPoker54.Core
{
    public interface IFileSystem
    {
        IEnumerable<string> ReadAllLines(string pokerHandsFile);
    }
}