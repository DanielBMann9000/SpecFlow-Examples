using System.Collections.Generic;
using System.IO;
using EulerPoker54.Core;

namespace EulerPoker54.Tests.Unit
{
    public class FakeFileSystem : IFileSystem
    {
        public Dictionary<string, string> Files { get; private set; }
        public FakeFileSystem()
        {
            this.Files = new Dictionary<string, string>();
        }

        public IEnumerable<string> ReadAllLines(string file)
        {
            return new List<string> { Files[file] };
        }
    }

}
