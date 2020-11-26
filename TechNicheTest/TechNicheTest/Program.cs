using System.Diagnostics;
using TechNicheTest.FileSystem;

namespace TechNicheTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Trace.Listeners.Add(new TextWriterTraceListener("Logs/errors.log"));
            Trace.AutoFlush = true;
            
            FileHandling.PrintMaterials();
        }
    }
}