using System;
using Library;
using Xunit;

namespace Tests
{
    public class LibraryTests
    {
        [Fact]
        public void TestThing() 
        {
            Console.WriteLine("dotnet core on a mac (in docker) ftw!");
            Assert.Equal(43, new Thing().Get(19, 23));
        }
    }
}
