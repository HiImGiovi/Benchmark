using SGBenchmark;

Benchmark benchmark = new Benchmark(@"D:\Dev\custom-dlls\tests-output\Benchmark-output.txt");

benchmark.RunBenchmark("Event 1", () =>
{
    Console.WriteLine("Event 1");
});

benchmark.RunBenchmark("Event 2", () =>
{
    Console.WriteLine("Event 2");
});