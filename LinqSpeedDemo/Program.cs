// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using LinqSpeedDemo;

BenchmarkRunner.Run<ListMaximumBenchmark>();
BenchmarkRunner.Run<LazySequenceMaximumBenchmark>();