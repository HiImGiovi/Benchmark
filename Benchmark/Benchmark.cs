using System.Diagnostics;
using System.Runtime.CompilerServices;
namespace SGBenchmark
{
    /// <summary>
    /// Helper class to run benchmark test in Debug/Benchmark configuration only.
    /// </summary>
    public class Benchmark
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="outputFilePath">The path of the file in which the benchmark test has to be logged.</param>
        public Benchmark(string outputFilePath)
        {
            this.OutputFilePath = outputFilePath;
        }

        /// <summary>
        /// The output file path.
        /// </summary>
        public string OutputFilePath { get; set; }

        /// <summary>
        /// Time tracking class.
        /// </summary>
        private Stopwatch stopwatch = new Stopwatch();

        /// <summary>
        /// Runs a benchmark test of the <paramref name="action"/> when config is set to Debug/Benchmark, else just runs the <paramref name="action"/>.
        /// </summary>
        /// <param name="name">The name of the benchmark test logged in the output file <see cref="OutputFilePath"/>.</param>
        /// <param name="action">The code to run.</param>
        /// <param name="sourceCodeFilePath">The path of the source code from which the benchmark is called.</param>
        /// <param name="methodName">The function name from which the benchmark is called.</param>
        /// <param name="lineNumber">The line number of the source code from which the benchmark is called.</param>
        public void RunBenchmark(string name, Action action, [CallerFilePath] string sourceCodeFilePath = @"", [CallerMemberName] string methodName = "Main",[CallerLineNumber] int lineNumber = 0)
        {
#if DEBUG || BENCHMARK
            using (StreamWriter streamWriter = new StreamWriter(OutputFilePath, true))
            {
                this.stopwatch.Start();
                action();
                this.stopwatch.Stop();
                streamWriter.WriteLine($"[{DateTime.Now}]\t'{name}' called from '{sourceCodeFilePath}' function '{methodName}' at line '{lineNumber}' executed in {stopwatch.ElapsedMilliseconds}ms");
                this.stopwatch.Reset();
            }
        }
#else
            action();
#endif

    }

}