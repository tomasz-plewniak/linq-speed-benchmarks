using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;

namespace LinqSpeedDemo;

public class ListMaximumBenchmark
{
    private List<int> _data = [];
    
    [GlobalSetup]
    public void Setup()
    {
        _data = Enumerable.Range(0, 100_000).ToList();
    }
    
    [Benchmark(Baseline = true)]
    public int Linq()
    {
        return _data.Max();
    }

    [Benchmark]
    public void ForLoop()
    {
        var max = _data[0];
        for (var i = 1; i < _data.Count; i++)
        {
            max = Math.Max(max, _data[i]);
        }
    }

    [Benchmark]
    public void Span()
    {
        ReadOnlySpan<int> span = CollectionsMarshal.AsSpan(_data);
        int max = span[0];
        for (int i = 1; i < span.Length; i++)
        {
            max = Math.Max(max, span[i]);
        }
    }
}